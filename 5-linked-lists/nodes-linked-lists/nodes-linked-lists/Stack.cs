using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nodes_linked_lists
{
    public class CustomStack<T>
    {
        //last is the same as the first in the context of a normal linked list.
        //the last one is te first one (the one which is more far away from Null)
        public Nodes<T> Top { get; set; }
        public int SizeCustomStack { get; set; }
        public CustomStack()
        {
            Top = null;
            SizeCustomStack = 0;
        }

        public Nodes<T> GetTop()
        {

            return Top;
        }

        public void SetTop(Nodes<T> newTop)
        {
            Top = newTop;
        }

        //add
        public void Push(T data)
        {
            Nodes<T> newTop = new Nodes<T>(data);
            newTop.Next = Top;
            Top = newTop;
            SizeCustomStack++;
            Console.WriteLine("Added Top Succesfully");
        }

        //
        public void Pop()
        {
            if(Top == null)
            {
                Console.WriteLine("List is Empty");
                return;
            }else
            {
                Top = Top.Next;
                SizeCustomStack--;
                Console.WriteLine("Deleted Top Succesfully");
            }
        }
    }
}
