using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Node<T>
    {
        public T Value { get; private set; }

        public List<Node<T>> Children { get; private set; }

        public int Status { get; set; }

        public Node(T value)
        {
            Children = new List<Node<T>>();
            Value = value;
            Status = 0;
        } 
    }
}
