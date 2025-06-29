using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleMaxPathAssessment
{
    public  class TriangleSolver
    {
        public int GetMaximumTotal(string filePath)
        {
            Console.WriteLine($"Reading file: {filePath}");

            // Read and parse the triangle
            int[][] triangle = ReadTriangleFromFile(filePath);

            Console.WriteLine($"Triangle loaded successfully: {triangle.Length} rows");
            Console.WriteLine($"First row: {string.Join(" ", triangle[0])}");
            Console.WriteLine($"Last row has {triangle[triangle.Length - 1].Length} numbers");

            // Use dynamic programming from bottom to top
            return CalculateMaxPath(triangle);
        }

        private int[][] ReadTriangleFromFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                Console.WriteLine($"Lines read from file: {lines.Length}");

                // Filter empty lines and clean spaces
                var validLines = lines
                    .Select((line, index) => new { line = line.Trim(), index })
                    .Where(x => !string.IsNullOrWhiteSpace(x.line))
                    .ToArray();

                Console.WriteLine($"Valid lines after filtering: {validLines.Length}");

                int[][] triangle = new int[validLines.Length][];

                for (int i = 0; i < validLines.Length; i++)
                {
                    var lineData = validLines[i];

                    // Split by spaces and filter empty elements
                    string[] numberStrings = lineData.line
                        .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    Console.WriteLine($"Row {i + 1}: {numberStrings.Length} numbers");

                    triangle[i] = new int[numberStrings.Length];

                    for (int j = 0; j < numberStrings.Length; j++)
                    {
                        string numberStr = numberStrings[j].Trim();

                        if (string.IsNullOrEmpty(numberStr))
                        {
                            throw new FormatException($"Empty string found at row {i + 1}, position {j + 1}");
                        }

                        if (!int.TryParse(numberStr, out triangle[i][j]))
                        {
                            throw new FormatException($"Could not convert '{numberStr}' to number at row {i + 1}, position {j + 1}");
                        }
                    }

                    // Validate it's a valid triangle (each row should have i+1 elements)
                    if (triangle[i].Length != i + 1)
                    {
                        Console.WriteLine($"Warning: Row {i + 1} has {triangle[i].Length} elements, expected {i + 1}");
                    }
                }

                return triangle;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                Console.WriteLine($"Error type: {ex.GetType().Name}");
                throw;
            }
        }

        private int CalculateMaxPath(int[][] triangle)
        {
            if (triangle == null || triangle.Length == 0)
                return 0;

            int rows = triangle.Length;
            Console.WriteLine($"Calculating maximum path for triangle with {rows} rows");

            // Create DP table (dynamic programming)
            // dp[i][j] represents the maximum sum from position (i,j) to bottom
            int[][] dp = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                dp[i] = new int[triangle[i].Length];
            }

            // Initialize the last row
            for (int j = 0; j < triangle[rows - 1].Length; j++)
            {
                dp[rows - 1][j] = triangle[rows - 1][j];
            }

            // Fill DP table from second-to-last row upwards
            for (int i = rows - 2; i >= 0; i--)
            {
                for (int j = 0; j < triangle[i].Length; j++)
                {
                    // From position (i,j) you can go to (i+1,j) or (i+1,j+1)
                    int downLeft = dp[i + 1][j];
                    int downRight = dp[i + 1][j + 1];

                    dp[i][j] = triangle[i][j] + Math.Max(downLeft, downRight);
                }
            }

            // The result is at the top of the triangle
            int result = dp[0][0];
            Console.WriteLine($"Maximum path calculated: {result}");
            return result;
        }

        // Helper method to show first rows of the triangle
        public void ShowTrianglePreview(int[][] triangle, int maxRows = 10)
        {
            Console.WriteLine("\nFirst rows of the triangle:");
            int rowsToShow = Math.Min(maxRows, triangle.Length);

            for (int i = 0; i < rowsToShow; i++)
            {
                // Add spaces for triangular format
                string spaces = new string(' ', (maxRows - i - 1) * 2);
                Console.Write(spaces);

                Console.WriteLine(string.Join("  ", triangle[i]));
            }

            if (triangle.Length > maxRows)
            {
                Console.WriteLine($"... and {triangle.Length - maxRows} more rows");
            }
        }
    }
}
