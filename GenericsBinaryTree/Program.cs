using GenericsBinaryTree.BinaryTree;

namespace GenericsBinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Node<int> root = new(4);


            



            Tree<int> tree = new Tree<int>(new int[] { 1, 2, 3, 4, 5 });

            tree.Root.PreOrderTraversal((Item) => Console.WriteLine(Item.Data));
            Console.WriteLine(tree.Root.Depth());

            Console.ReadLine();
        }
    }
}