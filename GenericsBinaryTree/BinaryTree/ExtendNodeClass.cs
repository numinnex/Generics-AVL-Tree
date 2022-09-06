using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsBinaryTree.BinaryTree
{
    public static class ExtendNodeClass
    {
        public static Node<T> Maximum(this Node<T> tree)
        {
            Node<T> current = tree;
            while(current.Right != null)
            {
                current = current.Right;
            }
            return current;
        }
    }
}
