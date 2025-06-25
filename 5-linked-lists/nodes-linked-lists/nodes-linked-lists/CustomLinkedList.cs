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

        public void SelectionSort(Comparison<T> comparison)
        {
            Nodes<T> current = First;
            if(current == null)
            {
                Console.WriteLine("List is empty");
                return;
            }else if(current.Next == null)
            {
                Console.WriteLine("List already sorted");
                return;
            }else
            {
                Nodes<T> i, j, min;
                for(i = First; i != null; i = i.Next)
                {
                    min = i;
                    for(j = i.Next; j != null; j = j.Next)
                    {
                        if(comparison(j.Data, min.Data) <0)
                        {
                            min = j;
                        }
                    }

                    if(min != i)
                    {
                        T? data = i.Data;
                        i.Data = min.Data;
                        min.Data = data;
                    }
                }

                Console.WriteLine("List sorted");
            }
        }

        public int ResultiIntComparison(int data1, int data2)
        {
            //return data1 - data2;
            return data1.CompareTo(data2);
        }

        //superficial copy; the data inside the list reference the same nodes
        // so if you change the original list, the copy gonna be affected
        public CustomLinkedList<T> ShallowCopyCustomLinkedList()
        {
            CustomLinkedList<T> newList = new CustomLinkedList<T>();
            Nodes<T> current = First;

            while (current != null)
            {
                newList.AddLast(current.Data);
                current = current.Next;
            }

            Console.WriteLine("List copied correctly");
            return newList;
        }

        //indepent from the original list; we must use a callback to duplicate the info
        public CustomLinkedList<T> DeepCopyCustomLinkedList(Func<T, T> cloneFunction)
        {
            CustomLinkedList<T> newList = new CustomLinkedList<T>();
            Nodes<T> current = First;

            if (current == null)
            {
                Console.WriteLine("List is empty");
                return null;
            }

            while (current != null)
            {
                // Usamos la función de clonación que pasás como parámetro
                T clonedData = cloneFunction(current.Data);
                newList.AddLast(clonedData);
                current = current.Next;
            }

            Console.WriteLine("Deep copy created correctly");
            return newList;
        }
    }


}
