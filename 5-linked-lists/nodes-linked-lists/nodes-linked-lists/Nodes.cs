using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nodes_linked_lists
{
    public class Nodes<T>
    {
        public T? Data { get; set; }
        public Nodes<T>? Next { get; set; }

        public Nodes(T data)
        {
        Data = data;
        Next = null;
        }

    }
}
