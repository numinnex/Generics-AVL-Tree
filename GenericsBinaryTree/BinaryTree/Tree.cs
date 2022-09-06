using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GenericsBinaryTree.BinaryTree
{
    public class Tree<T>
    {
        public Node<T> Root { get; set; }

        public IComparer<T> Comparer { get; }

        public Tree(Node<T> root) :this(root, Comparer<T>.Default)
        {

        }
        public Tree(Node<T> root, IComparer<T> comparer)
        {
            Root = root;
            Comparer = comparer;
        }

        public Node<T>? Search(T data)
        {
            Node<T> current = Root;
            while(current != null)
            {
                int compared = Comparer.Compare(data, current.Data);

                if (compared < 0)
                    current = current.Left;
                else if (compared > 0)
                    current = current.Right;
                else
                    return current;

            }

            return current;
        }

        public Node<T> Maximum()
        {
            return Root?.Maximum();
        }

        public Node<T> Minimum()
        {
            return Root?.Minimum();
        }

        public void Insert(Node<T> node)
        {
            Node<T> parent = null;
            Node<T> current = Root;

            while(current != null)
            {
                parent = current;
                int compared = Comparer.Compare(node.Data, current.Data);

                if (compared < 0)
                    current = current.Left;
                else if (compared > 0)
                    current = current.Right;
                else
                    throw new ArgumentException($"A node with this value {node.Data} already exists!");
            }

            node.Parent = parent;

            if (parent == null)
                Root = node;
            else if (Comparer.Compare(node.Data, parent.Data) < 0)
                parent.Left = node;
            else
                parent.Right = node;

        }
        public void Replace(Node<T> node , Node<T>? replacer)
        {
            if (node.Parent == null)
            {
                Root = replacer;
            }
            else if (node == node.Parent.Left)
                node.Parent.Left = replacer;
            else
                node.Parent.Right = replacer;

            if(replacer != null)
            {
                replacer.Parent = node.Parent;
            }
        }

    }

}
