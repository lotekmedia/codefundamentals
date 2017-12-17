using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleSB
{
    public class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public TreeNode Parent { get; set; }
        public int Size { get; set; }
        public int LeftSize { get; set; }
        public int RightSize { get; set; }
        private bool insertedLeft = true;

        public void Display()
        {
            Console.Write("[");
            Console.Write(this.Data);
            Console.Write("]");
            Console.WriteLine();
        }

        public TreeNode(int data)
        {
            Data = data;
            Size = 1;
            LeftSize = -1;
            RightSize = 1;
        }

        public void SetLeftChild(TreeNode left)
        {
            Left = left;

            if (left != null)
            {
                left.Parent = this;
            }
        }

        public void SetRightChild(TreeNode right)
        {
            Right = right;

            if (right != null)
            {
                right.Parent = this;
            }
        }

        public void InsertInOrder(int data)
        {
            if (data <= Data)
            {
                if (Left == null)
                {
                    SetLeftChild(new TreeNode(data));
                }
                else
                {
                    Left.InsertInOrder(data);
                    insertedLeft = false;
                }
            }
            else
            {
                if (Right == null)
                {
                    SetRightChild(new TreeNode(data));
                }
                else
                {
                    Right.InsertInOrder(data);
                    insertedLeft = true;
                }
            }
            if (insertedLeft)
            {
                LeftSize++;
            }
            else
            {
                RightSize++;
            }
            Size++;
        }

        public TreeNode Find(int data)
        {
            if (data == Data)
            {
                return this;
            }
            else if (data <= Data)
            {
                return Left != null ? Left.Find(data) : null;
            }
            else if (data > Data)
            {
                return Right != null ? Right.Find(data) : null;
            }

            return null;
        }

        public void Print()
        {
            Console.WriteLine(String.Format("Size: {0}, Left Size: {1}, Right Size: {2}", Size, LeftSize, RightSize));
            Print("", true, this);
        }

        private void Print(String prefix, bool isTail, TreeNode curNode)
        {
            if (curNode == null)
            {
                return;
            }
            Print(prefix + (isTail ? "    " : "│   "), curNode.Left == null, curNode.Left);
            Console.WriteLine(prefix + (isTail ? "   " : "├── ") + curNode.Data.ToString());
            Print(prefix + (isTail ? "    " : "│   "), curNode.Right == null, curNode.Right);
        }

        public void Preorder(TreeNode Root)
        {
            if (Root != null)
            {
                Root.Display();
                Preorder(Root.Left);
                Preorder(Root.Right);
            }
        }

        public void Inorder(TreeNode Root)
        {
            if (Root != null)
            {
                Inorder(Root.Left);
                Root.Display();
                Inorder(Root.Right);
            }
        }

        public void Postorder(TreeNode Root)
        {
            if (Root != null)
            {
                Postorder(Root.Left);
                Postorder(Root.Right);
                Root.Display();
            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int data = 50;
            TreeNode theTree = new TreeNode(data);
            for (int i = 0; i < 20; i++)
            {
                data = r.Next(1, 100);
                theTree.InsertInOrder(data);
            }
            theTree.Inorder(theTree);
            Console.WriteLine();
            theTree.Preorder(theTree);
            Console.WriteLine();
            theTree.Postorder(theTree);
            Console.WriteLine();
            theTree.Print();
            Console.WriteLine();
            var result = theTree.Find(74) == null ? "Not Found" : theTree.Find(74).Data.ToString();
            Console.WriteLine(result);
            Console.ReadLine();
            System.Environment.Exit(0);
        }
    }
}
