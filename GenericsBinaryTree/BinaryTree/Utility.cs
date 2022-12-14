using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GenericsBinaryTree.BinaryTree
{
    public static class Utility
    {

        public static Node<T>? CreateFromMultiple<T>(IEnumerable<Node<T>> nodes , IComparer<T>? comparer = null)
        {
            comparer ??= Comparer<T>.Default;
            Node<T>[] NodesArray = nodes.ToArray();
            Array.Sort(NodesArray);

            Node<T>? root = CreateFromMultipleNodes(NodesArray);
            
            return root;    
        }

        private static Node<T>? CreateFromMultipleNodes<T>(IList<Node<T>> NodesArray)
        {
            return CreateFromMultipleNodes(NodesArray, 0 , NodesArray.Count - 1);
        }


        private static Node<T>? CreateFromMultipleNodes<T>(IList<Node<T>> NodesArray, int start , int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;
            Node<T> node = NodesArray[mid];

            node.Left = CreateFromMultipleNodes(NodesArray, start, mid - 1);
            if (node.Left != null)
                node.Left.Parent = node;


            node.Right = CreateFromMultipleNodes(NodesArray, mid + 1, end);
            if (node.Right != null)
                node.Right.Parent = node;


            return node;

        }

    }
}
