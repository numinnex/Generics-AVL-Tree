namespace GenericsBinaryTree.BinaryTree
{
    public class Tree<T>
    {
        public Node<T> Root { get; set; } = null;




        public IComparer<T> Comparer { get; }

        public Tree()
        {
            Root = null;
            Comparer = Comparer<T>.Default;
        }
        //public Tree(Node<T>? root) :this(root, Comparer<T>.Default)
        //{

        //}
        public Tree(Node<T> root, IComparer<T> comparer)
        {
            Root = root;
            Comparer = comparer;
        }
        public Tree(IEnumerable<T> values) : this(values, Comparer<T>.Default)
        {

        }
        public Tree(IEnumerable<T> values, IComparer<T> comparer)
        {
            Comparer = comparer;
            Root = Utility.CreateFromMultiple(values.Select(v => new Node<T>(v)), comparer);
        }


        public Node<T>? Search(T data)
        {
            Node<T> current = Root;
            while (current != null)
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

            Insert(Root, data);
        }

        public void Insert(Node<T> node, T value)
        {
            int compared = Comparer.Compare(node.Data, value);

            if (compared < 0)
            {
                if (node.Right == null)
                    node.Right = new Node<T>(node, value);
                else
                    Insert(node.Right, value);
            }
            else if (compared > 0)
            {
                if (node.Left == null)
                    node.Left = new Node<T>(node, value);
                else
                    Insert(node.Left, value);
            }
            else
                throw new Exception("Item exists");

            Rebalance(node);

        }
        public void Rebalance(Node<T> node)
        {
            if (node == null)
                return;
            if (node.Left == null && node.Right == null)
                return;

            var leftHeight = node.Left?.Depth() ?? 0;
            var rightHeight = node.Right?.Depth() ?? 0;

            var balanceFactor = leftHeight - rightHeight;

            if (balanceFactor >= 2)
            {
                leftHeight = node.Left?.Left?.Depth() ?? 0;
                rightHeight = node.Left?.Right?.Depth() ?? 0;

                if (leftHeight > rightHeight)
                {
                    rightRotate(node);
                }
                else
                {
                    leftRotate(node.Left);
                    rightRotate(node);
                }
            }
            else if (balanceFactor <= -2)
            {
                leftHeight = node.Right?.Left?.Depth() ?? 0;
                rightHeight = node.Right?.Right?.Depth() ?? 0;

                if (rightHeight > leftHeight)
                    leftRotate(node);

                else
                {
                    rightRotate(node);
                    leftRotate(node);

                }
            }

        }
        private void rightRotate(Node<T> node)
        {
            Node<T> prevRoot = node;
            Node<T> leftRightChild = prevRoot.Left.Right;

            var newRoot = node.Left;

            prevRoot.Left.Parent = prevRoot.Parent;



            if (prevRoot.Parent != null)
            {
                if (prevRoot.Parent.Left == prevRoot)
                {
                    prevRoot.Parent.Left = prevRoot.Left;
                }
                else
                    prevRoot.Parent.Right = prevRoot.Left;
            }

            newRoot.Right = prevRoot;
            prevRoot.Parent = newRoot;

            newRoot.Right.Left = leftRightChild;

            if (newRoot.Right.Left != null)
                newRoot.Right.Left.Parent = newRoot.Right;

            if (prevRoot == Root)
                Root = newRoot;

        }
        private void leftRotate(Node<T> node)
        {
            var prevRoot = node;
            var rightLeftChild = prevRoot.Right.Left;

            var newRoot = node.Right;

            prevRoot.Right.Parent = prevRoot.Parent;

            if (prevRoot.Parent != null)
            {
                if (prevRoot.Parent.Left == prevRoot)
                    prevRoot.Parent.Left = prevRoot.Right;
                else
                    prevRoot.Parent.Right = prevRoot.Right;
            }
            newRoot.Left = prevRoot;
            prevRoot.Parent = newRoot;

            newRoot.Left.Right = rightLeftChild;

            if (newRoot.Left.Right != null)
                newRoot.Left.Right.Parent = newRoot.Left;

            if (prevRoot == Root)
                Root = newRoot;


        }

        public void Replace(Node<T> node, Node<T>? replacer)
        {
            if (node.Parent == null)
            {
                Root = replacer;
            }
            else if (node == node.Parent.Left)
                node.Parent.Left = replacer;
            else
                node.Parent.Right = replacer;

            if (replacer != null)
            {
                replacer.Parent = node.Parent;
            }
        }

    }


}
