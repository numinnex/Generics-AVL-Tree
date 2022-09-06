using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsBinaryTree.BinaryTree
{
    public class Node<T>
    {
        public T Data { get; private set; }
        public Node(T data)
        {
            Data = data;
        }   

        public Node<T> ? Parent { get; set; }
        public Node<T>? Left { get; set; }
        public Node<T>? Right { get; set; }

    }


}
