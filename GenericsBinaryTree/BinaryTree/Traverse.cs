using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsBinaryTree.BinaryTree
{
    public static class Traverse
    {
        public static void DepthFirstSearch<T>(this Node<T>? node , Action <Node<T>>? onEnter , Action<Node<T>>? onPass, Action<Node<T>>? onExit)
        {


            onEnter.Invoke(node);
            DepthFirstSearch(node.Left, onEnter,onPass, onExit);
            onPass.Invoke(node);
            DepthFirstSearch(node.Right, onEnter, onPass, onExit);
            onExit.Invoke(node);

        }

        public static void PostOrderTraversal<T>(this Node<T> tree, Action<Node<T>> onVisit)
        {
            if (tree != null)
            {
                PostOrderTraversal(tree.Left, onVisit);
                PostOrderTraversal(tree.Right, onVisit);
                onVisit(tree); 
            }

        }

        public static IEnumerable<Node<T>> PostOrderTraversal<T>(this Node<T> tree)
        {
            Stack<Node<T>> stack = new();
            Stack<Node<T>> stack2 = new();

            if (tree == null)
                yield break;

            stack.Push(tree);

            while(stack.Count > 0)
            {
                Node<T> current = stack.Pop();
                stack2.Push(current);

                if(current.Left != null)
                    stack.Push(current.Left);
                if (current.Right != null)
                    stack.Push(current.Right);
            }
            foreach (var node in stack2)
            {
                yield return node;
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
        public static IEnumerable<Node<T>> PreOrderTraversal<T>(this Node<T> tree)
        {
            if (tree == null)
                yield break;

            Stack<Node<T>> stack = new();
            stack.Push(tree);


            while(stack.Count > 0)
            {
                Node<T> current = stack.Pop();
                yield return current;

                if (current.Right != null)
                    stack.Push(current.Right);
                if (current.Left != null)
                    stack.Push(current.Left);
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
        public static  IEnumerable<Node<T>> InOrderTraversal<T>(this Node<T> tree)
        {
            if (tree == null)
                yield break;

            Stack<Node<T>> stack = new();
            Node<T> current = tree;

            while(current != null || stack.Count > 0)
            {
                while(current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                current = stack.Pop();

                yield return current;

                current = current.Right;
            }
            

        }

    }
}
