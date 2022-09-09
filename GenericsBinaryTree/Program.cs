using GenericsBinaryTree.BinaryTree;

namespace GenericsBinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Node<int> root = new(4);
            //test
            Tree<int> tree = new Tree<int>();

            tree.Insert(40);
            tree.Insert(20);
            tree.Insert(10);
            tree.Insert(25);
            tree.Insert(30);
            tree.Insert(22);
            tree.Insert(50);




            //tree.Root.PreOrderTraversal((Item) => Console.WriteLine(Item.Data));
            //Console.WriteLine();

            //var found = tree.Search(tree.Root, 30);
            //Node<int> test = new Node<int>(69);

            //tree.Replace(found, test);

            tree.Root.PostOrderTraversal((Item) => Console.WriteLine(Item.Data));
            Console.WriteLine($"Height - {tree.Root.Depth()}");




            Console.ReadLine();
        }
    }
}