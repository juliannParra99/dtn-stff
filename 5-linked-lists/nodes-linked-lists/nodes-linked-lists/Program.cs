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
numericList.ShowCustumLinkedList();
numericList.AddPosition(90, 2);
numericList.ShowCustumLinkedList();
numericList.DeleteFirst();
numericList.ShowCustumLinkedList();
numericList.DeleteFirst();
numericList.ShowCustumLinkedList();
//numericList.DeleteLast();
numericList.DeletePosition(1);
numericList.ShowCustumLinkedList();