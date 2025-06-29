using System;
using System.Collections.Generic;
using nodes_linked_lists;

namespace nodes_linked_lists
{
    class Program
    {
        static void Main(string[] args)
        {
            var profesors = new List<Profesor>
            {
                new Profesor { name = "julian", age = 26, dni = 4135654 },
                new Profesor {name = "parrix", age = 99, dni = 3333},
                new Profesor {name  = "pato", age = 40, dni = 22222},
                new Profesor {name = "solo", age =15, dni = 12345},
                new Profesor {name = "curly", age = 24, dni = 929292}
            };

            Console.WriteLine("Profesores cargados: " + profesors.Count);
            foreach (var profe in profesors)
            {
                Console.WriteLine($"Nombre: {profe.name}, Edad: {profe.age}, DNI: {profe.dni}");
            }

            // Tu código original
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
            numericList.ShowCustumLinkedList();
            Console.WriteLine("---List sorted---");
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

            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine("--- STACK---");
            CustomStack<int> newStack = new CustomStack<int>();
            newStack.Push(1);
            newStack.Push(2);
            newStack.Push(3);
            Console.WriteLine("Top: " + newStack.Top.Data);
            newStack.Pop();
            Console.WriteLine("Top: " + newStack.Top.Data);

            Console.WriteLine("--- QUEUE---");
            CustomQueue<int> newQueue = new CustomQueue<int>();
            newQueue.Enqueue(10);
            newQueue.Enqueue(20);
            newQueue.Enqueue(30);
            Console.WriteLine("First in queue (Head): " + newQueue.Head.Data);
            Console.WriteLine("Last in queue (Tail): " + newQueue.Tail.Data);

            int removed = newQueue.Dequeue();
            Console.WriteLine("Removed from queue: " + removed);

            if (newQueue.Head != null)
                Console.WriteLine("New Head: " + newQueue.Head.Data);
            else
                Console.WriteLine("Queue is now empty.");
        }
    }

    public class Profesor
    {
        public string name { get; set; }
        public int age { get; set; }
        public int dni { get; set; }
    }
}
