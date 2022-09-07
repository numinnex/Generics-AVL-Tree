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

        public Tree()
        {
            Root = null;
            Comparer = Comparer<T>.Default;
        }
        public Tree(Node<T>? root) :this(root, Comparer<T>.Default)
        {

        }
        public Tree(Node<T> root, IComparer<T> comparer)
        {
            Root = root;
            Comparer = comparer;
        }
        public Tree(IEnumerable<T> values) : this(values, Comparer<T>.Default)
        {

        }
        public Tree(IEnumerable<T> values , IComparer<T> comparer)
        {
            Comparer = comparer;
            Root = Utility.CreateFromMultiple(values.Select(v => new Node<T>(v)), comparer);
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

        public void Insert(T data)
        {
            if (Root == null)
            {
                Root = new Node<T>(null, data);
                return;
            }
                
            Insert(Root , data);
        }

        public void Insert(Node<T> node , T value)
        {
            int compared = Comparer.Compare(node.Data, value);

            if(compared < 0)
            {
                if (node.Right == null)
                    node.Right = new Node<T>(node ,value);
                else
                    Insert(node.Right, value);
            }    
            else if(compared > 0)
            {
                if (node.Left == null)
                    node.Left = new Node<T>(node, value);
                else
                    Insert(node.Left, value);
            }
            else
                throw new Exception("Item exists");

            //Balancing.Rebalance(node);

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
