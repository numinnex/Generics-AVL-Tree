using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsBinaryTree.BinaryTree
{
    public static class Traverse
    {
        public static void PostOrderTraversal<T>(this Node<T> tree, Action<Node<T>> onVisit)
        {
            PostOrderTraversal(tree.Left, onVisit);
            PostOrderTraversal(tree.Right, onVisit);
            onVisit(tree);

        }
    }
}
