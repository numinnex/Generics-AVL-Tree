using GenericsBinaryTree.BinaryTree;

namespace GenericsBinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Node<int> root = new(4);


            



            Tree<int> tree = new Tree<int>();
            tree.Insert(40);
            tree.Insert(20);
            tree.Insert(10);
            tree.Insert(25);
            tree.Insert(30);
            tree.Insert(22);
            tree.Insert(50);
            tree.Delete(10);
            tree.Delete(40);



            tree.Root.PreOrderTraversal((Item) => Console.WriteLine(Item.Data));
            Console.WriteLine($"Height - {tree.Root.Depth()}");

            Console.ReadLine();
        }
    }
}