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
        public static int Depth<T>(this Node<T> tree)
        {

            if (tree == null)
                return -1;
            else
            {
                int x = Depth(tree.Left);
                int y = Depth(tree.Right);
                if (x > y)
                    return (x + 1);
                else
                    return (y + 1);
            }
        }
        public static void UpdateCount<T>(this Node<T> node)
        {
            while(node != null)
            {
                int leftCount = node.Left?.Count ?? 0;
                int rightCount = node.Right?.Count ?? 0;

                node.Count = leftCount + rightCount + 1;

                node = node.Parent;
            }
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
            if (node.Right != null)
                return node.Right.Minimum();

            Node<T>? current = node.Parent;

            while (current != null && node == current.Right)
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

