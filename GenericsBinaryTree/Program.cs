using GenericsBinaryTree.BinaryTree;

namespace GenericsBinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Node<int> root = new(4);
            Tree<int> tree = new Tree<int>();
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert(4);
            tree.Insert(5);
            tree.Insert(6);

            //tree.Root.PreOrderTraversal((Item) => Console.WriteLine(Item.Data));

            var output = tree.Root.InOrderTraversal();

            foreach (var item in output)
            {
                Console.WriteLine(item.Data);
            }

            Console.ReadLine();
        }
    }
}