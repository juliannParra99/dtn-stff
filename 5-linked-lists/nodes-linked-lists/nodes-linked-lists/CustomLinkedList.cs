using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nodes_linked_lists
{
    public class CustomLinkedList<T>
    {
        public Nodes<T>? First { get; set; }
        public int ListSize { get; set; }

        public CustomLinkedList()
        {
            First = null;
            ListSize = 0;
        }

        //add new one First
        public void AddFirst(T data)
        {
            Nodes<T> node = new Nodes<T>(data);
            node.Next = First;
            First = node;
            ListSize++;
            Console.WriteLine("First one inserted correctly");
        }

        public void AddLast(T data)
        {
            if (First == null)
            {
                AddFirst(data);
                return;
            }
            else
            {
                Nodes<T> current = First;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                Nodes<T> newElement = new Nodes<T>(data);
                current.Next = newElement;
                ListSize++;
                Console.WriteLine("Last one inserted correctly");
            }
        }

        public void AddPosition(T data, int position)
        {
            if (position < 0 || position > ListSize)
            {
                Console.WriteLine("Position is out of the list range ");
                return;
            }
            else if (position == 0)
            {
                AddFirst(data);
                return;
            }
            else if (position == ListSize)
            {
                AddLast(data);
            }
            else
            {
                Nodes<T> current = First;
                int i = 0;
                while (i < position - 1)
                {
                    current = current.Next;
                    i++;
                }
                Nodes<T> newNode = new Nodes<T>(data);
                newNode.Next = current.Next;
                current.Next = newNode;
                ListSize++;
                Console.WriteLine("Element inserted in position " + position);
            }
        }

        public void ShowCustumLinkedList()
        {
            Nodes<T> current = First;
            if (current == null)
            {
                Console.WriteLine("List is Empty");
                return;
            }
            else
            {
                while (current != null)
                {
                    Console.WriteLine(current.Data);
                    current = current.Next;
                }
            }
        }

        public void DeleteFirst()
        {
            Nodes<T> current = First;
            if (First == null)
            {
                Console.WriteLine("The list is empty");
                return;
            }
            else
            {
                First = current.Next;
                current = null;
                ListSize--;
                Console.WriteLine("First eliminated");
            }
        }

        public void DeleteLast()
        {
            Nodes<T> current = First;

            if (current == null)
            {
                Console.WriteLine("The list is empty");
                return;
            }
            else
            {
                Nodes<T> previous = current;
                while (current.Next != null)
                {
                    previous = current;
                    current = current.Next;
                }
                current = null;
                previous.Next = null;
                ListSize--;
                Console.WriteLine("Last eliminated");
            }
        }

        public void DeletePosition(int position)
        {
            Nodes<T> current = First;
            if (current == null)
            {
                Console.WriteLine("The list is empty");
                return;
            }
            else if (position < 0 || position > ListSize)
            {
                Console.WriteLine("Position is out of the list range ");
                return;
            }
            else if (position == 0)
            {
                DeleteFirst();
                return;
            }
            else if (position == ListSize - 1)
            {
                DeleteLast();
                return;
            }
            else
            {
                Nodes<T> previous = First;
                for (int i = 0; i < position - 1; i++)
                {
                    previous = previous.Next;
                }

                current = previous.Next;
                previous.Next = current.Next;
                current = null;
                ListSize--;
                Console.WriteLine("Element eliminated in position " + position);
            }
        }
    }
}
