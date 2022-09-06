namespace GenericsBinaryTree.BinaryTree
{
    public static class ExtendNodeClass
    {
        public static Node<T> Maximum<T>(this Node<T> tree)
        {
            Node<T> current = tree;
            while (current.Right != null)
            {
                current = current.Right;
            }
            return current;
        }

        public static Node<T> Minimum<T>(this Node<T> tree)
        {
            Node<T> current = tree;
            while (current.Left != null)
            {
                current = current.Left;
            }
            return current;
        }

        public static Node<T> Successor<T>(this Node<T> node)
        {
            if(node.Right != null)
                return node.Right.Minimum();

            Node<T>? current = node.Parent;

            while(current != null && node == current.Right)
            {
                node = current;
                current = current.Parent;
            }

            return current;

        }
        public static Node<T> Predecessor<T>(this Node<T> node)
        {
            if (node.Left != null)
            {
                return node.Left.Maximum();
            }

            Node<T>? current = node.Parent;

            while (current != null && node == current.Left)
            {
                node = current;
                current = current.Parent;
            }

            return current;
        }
    }
}

