using FindArrayAssessment;
using GPI.Test;

Console.WriteLine("Find Array Assessment: ");

IFindArray finder = new MyFindArray();

Console.WriteLine("First example:");
Console.WriteLine(finder.FindArray(new[] { 4, 9, 3, 7, 8 }, new[] { 3, 7 }));
Console.WriteLine("Second example:");
Console.WriteLine(finder.FindArray(new[] { 1, 3, 5 }, new[] { 1 }));
Console.WriteLine("Third example:");
Console.WriteLine(finder.FindArray(new[] { 7, 8, 9 }, new[] { 8, 9, 10 }));  