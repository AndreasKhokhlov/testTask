using System;

namespace BinaryTree
{
    public class BinaryTree
    {

        public long? Data;
        public int value;
        public BinaryTree Left;
        public BinaryTree Right;
        public BinaryTree Parent;
        
        public void Insert(long data)
        {
            if (Data == null || Data == data)
            {
                Data = data;
                return;
            }
            if (Data > data)
            {
                if (Left == null) Left = new BinaryTree();
                Insert(data, Left, this);
            }
            else
            {
                if (Right == null) Right = new BinaryTree();
                Insert(data, Right, this);
            }
        }

       
        private void Insert(long data, BinaryTree node, BinaryTree parent)
        {

            if (node.Data == null || node.Data == data)
            {
                node.Data = data;
                node.Parent = parent;
                return;
            }
            if (node.Data > data)
            {
                if (node.Left == null) node.Left = new BinaryTree();
                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null) node.Right = new BinaryTree();
                Insert(data, node.Right, node);
            }
        }

        private void Insert(BinaryTree data, BinaryTree node, BinaryTree parent)
        {

            if (node.Data == null || node.Data == data.Data)
            {
                node.Data = data.Data;
                node.Left = data.Left;
                node.Right = data.Right;
                node.Parent = parent;
                return;
            }

            if (node.Data > data.Data)
            {
                if (node.Left == null) node.Left = new BinaryTree();
                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null) node.Right = new BinaryTree();
                Insert(data, node.Right, node);
            }
        }
    
        public BinaryTree Find(long data)
        {
            if (Data == data) return this;
            if (Data > data)
            {
                return Find(data, Left);
            }
            return Find(data, Right);
        }
   
        public BinaryTree Find(long data, BinaryTree node)
        {
            if (node == null) return null;

            if (node.Data == data) return node;
            if (node.Data > data)
            {
                return Find(data, node.Left);
            }
            return Find(data, node.Right);
        }

       
        public long CountElements()
        {
            return CountElements(this);
        }
       
        private long CountElements(BinaryTree node)
        {
            long count = 1;
            if (node.Right != null)
            {
                count += CountElements(node.Right);
            }
            if (node.Left != null)
            {
                count += CountElements(node.Left);
            }
            return count;
        }
        private BinaryTree _root;

        public BinaryTree()
        {
            _root = null;
        }

        public BinaryTree(object p1, object p2, int value)
        {
            this.value = value;
        }

        public void Add(int value)
        {
            _add(ref _root, value);
        }


        private void _add(ref BinaryTree node, int value)
        { 
       

            if (node == null)
            {
                node = new BinaryTree (null, null, value);
            }
            else
            {
                if (node.value >= value)
                {
                    _add(ref node.Left, value);
                }
                else
                {
                    _add(ref node.Right, value);
                }
            }
        }

        public void Print()
        {
            _print(_root);
        }
        private void _print(BinaryTree node)
        {
            if (node == null) return;
            _print(node.Left);
            Console.WriteLine(node.value);
            _print(node.Right);
        }
    }
    public class BinaryTreeExtensions
    {
        public static void Print(BinaryTree node)
        {
            if (node != null)
            {
                if (node.Parent == null)
                {
                    Console.WriteLine("ROOT:{0}", node.Data);
                }
                else
                {
                    if (node.Parent.Left == node)
                    {
                        Console.WriteLine("Left for {1}  --> {0}", node.Data, node.Parent.Data);
                    }

                    if (node.Parent.Right == node)
                    {
                        Console.WriteLine("Right for {1} --> {0}", node.Data, node.Parent.Data);
                    }
                }
                if (node.Left != null)
                {
                    Print(node.Left);
                }
                if (node.Right != null)
                {
                    Print(node.Right);
                    Console.ReadLine();
                }
            }
        }
    }
}
