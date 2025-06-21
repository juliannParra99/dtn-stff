using nodes_linked_lists;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

CustomLinkedList<int> numericList = new CustomLinkedList<int>();
numericList.AddFirst(30);
numericList.ShowCustumLinkedList();
numericList.AddLast(40);
numericList.ShowCustumLinkedList();
numericList.AddLast(50);
numericList.ShowCustumLinkedList();
numericList.AddFirst(10);
numericList.AddFirst(100);
numericList.AddFirst(56);
numericList.AddFirst(400);
numericList.ShowCustumLinkedList();
numericList.AddPosition(90, 2);
numericList.SelectionSort(numericList.ResultiIntComparison);
//Other way to use the selection sort with lambda expression.
//numericList.SelectionSort((a, b) => a.CompareTo(b));
numericList.ShowCustumLinkedList();
Console.WriteLine("---List sorted---");
numericList.ShowCustumLinkedList();
numericList.ShowCustumLinkedList();
numericList.ShowCustumLinkedList();
numericList.DeleteFirst();
numericList.ShowCustumLinkedList();
numericList.DeleteFirst();
numericList.ShowCustumLinkedList();
numericList.DeleteLast();
numericList.DeletePosition(1);


Console.WriteLine("---Copy List example---");

CustomLinkedList<int> listCopy = numericList.ShallowCopyCustomLinkedList();
Console.WriteLine("---New list---");
numericList.ShowCustumLinkedList();
