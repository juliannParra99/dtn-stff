using TriangleMaxPathAssessment;

Console.WriteLine("=== Triangle Solver - Maximum Path ===\n");

// Set up file path
string filePath = Path.Combine("..", "..", "..", "triangle.txt");

// Check if file exists
if (!File.Exists(filePath))
{
    Console.WriteLine($"Error: File not found at {Path.GetFullPath(filePath)}");
    Console.WriteLine("Please verify that triangle.txt is in the project folder.");
    return;
}

try
{
    Console.WriteLine($"File found: {Path.GetFullPath(filePath)}");
    Console.WriteLine($"File size: {new FileInfo(filePath).Length} bytes\n");

    TriangleSolver solver = new TriangleSolver();
    int result = solver.GetMaximumTotal(filePath);

    Console.WriteLine($"\n FINAL RESULT: {result}");
    Console.WriteLine("\nThe maximum sum path from top to bottom is: " + result);
}
catch (FormatException ex)
{
    Console.WriteLine($" Format error: {ex.Message}");
    Console.WriteLine("\nPlease verify that triangle.txt has the correct format:");
    Console.WriteLine("- Each line should contain numbers separated by spaces");
    Console.WriteLine("- Row 1 should have 1 number, row 2 should have 2 numbers, etc.");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($" File not found: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($" Unexpected error: {ex.Message}");
    Console.WriteLine($"Error type: {ex.GetType().Name}");
    Console.WriteLine($"Stack trace: {ex.StackTrace}");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();