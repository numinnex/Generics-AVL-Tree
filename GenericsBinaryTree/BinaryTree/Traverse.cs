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
            if (tree != null)
            {
                PostOrderTraversal(tree.Left, onVisit);
                PostOrderTraversal(tree.Right, onVisit);
                onVisit(tree); 
            }

        }
        public static void PreOrderTraversal<T>(this Node<T> tree, Action<Node<T>> onVisit)
        {
            if (tree != null)
            {
                onVisit(tree);
                PreOrderTraversal(tree.Left, onVisit);
                PreOrderTraversal(tree.Right, onVisit);
                
            }

        }
        public static void InOrderTraversal<T>(this Node<T> tree, Action<Node<T>> onVisit)
        {
            if (tree != null)
            {
               
                InOrderTraversal(tree.Left, onVisit);
                onVisit(tree);
                InOrderTraversal(tree.Right, onVisit);
            }

        }

    }
}
