// See https://aka.ms/new-console-template for more information
using SlidingWindow;
Console.WriteLine("Hello, World!");

var myArray = new int[] { 1,2,3,4,5,6,7,8,9};
var myArray2 = new int[] { 1, 2, 3, 4, 5};

ImplementationAlgo algo = new ImplementationAlgo();
int result = algo.maxSum(myArray, 3);
int result2 = algo.maxSum(myArray2, 4);
Console.WriteLine("Result 1:" + result);
Console.WriteLine("Result 2:" + result2);