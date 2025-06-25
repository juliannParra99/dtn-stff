using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nodes_linked_lists
{
    public class CustomQueue<T>
    {
        public Nodes<T> Head { get; set; }  // Front of the queue (first; same as in linked lists)
        public Nodes<T> Tail { get; set; }  // End of the queue (is the last one)
        public int SizeCustomQueue { get; set; }
        // Enqueue → add to Tail
        // Dequeue → remove from Head

        public CustomQueue()
        {
            Head = null;
            Tail = null;
            SizeCustomQueue = 0;
        }

        // Enqueue: Add to the end (Tail)
        public void Enqueue(T data)
        {
            Nodes<T> newNode = new Nodes<T>(data);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }
            SizeCustomQueue++;
            Console.WriteLine("Queue size updated (after Enqueue): " + SizeCustomQueue);
        }

        // Dequeue: Remove from the front (Head)
        public T Dequeue()
        {
            if (Head == null)
            {
                Console.WriteLine("Queue is empty");
                return default;
            }

            T value = Head.Data;
            Head = Head.Next;

            if (Head == null)
            {
                Tail = null;
            }

            SizeCustomQueue--;
            Console.WriteLine("Queue size updated (after Dequeue): " + SizeCustomQueue);
            return value;
        }
    }
}
