using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TreeSort
{
    public class Trade
    {
        public DateTime Time;
        public int Price;
    }

    public class Node
    {
        public Trade item;
        public Node leftc;
        public Node rightc;
        public override string ToString()
        {
            return "{" + item + "}";
        }

        public void display()
        {
            Console.Write("[");
            Console.Write(item.Time.ToShortTimeString() + " " + item.Price.ToString());
            Console.Write("]");
            Console.WriteLine();
        }
    }

    public class Tree
    {
        public Node root;
        public Tree()
        {
            root = null;
        }
        public Node ReturnRoot()
        {
            return root;
        }
        public void Insert(Trade trade)
        {
            Node newNode = new Node();
            newNode.item = trade;
            if (root == null)
                root = newNode;
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (trade.Price < current.item.Price)
                    {
                        current = current.leftc;
                        if (current == null)
                        {
                            parent.leftc = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightc;
                        if (current == null)
                        {
                            parent.rightc = newNode;
                            return;
                        }
                    }
                }
            }
        }

        public void Preorder(Node Root)
        {
            if (Root != null)
            {
                Root.display();
                Preorder(Root.leftc);
                Preorder(Root.rightc);
            }
        }
        public void Inorder(Node Root)
        {
            if (Root != null)
            {
                Inorder(Root.leftc);
                Root.display();
                Inorder(Root.rightc);
            }
        }
        public void Postorder(Node Root)
        {
            if (Root != null)
            {
                Postorder(Root.leftc);
                Postorder(Root.rightc);
                Root.display();
            }
        }
        
        public void print(Node root)
        {
            print("", true, root);
        }

        private void print(String prefix, bool isTail, Node curNode)
        {
            if (curNode == null)
            {
                return;
            }
            print(prefix + (isTail ? "    " : "│   "), curNode.leftc == null, curNode.leftc);
            Console.WriteLine(prefix + (isTail ? "   " : "├── ") + curNode.item.Price.ToString());
            print(prefix + (isTail ? "    " : "│   "), curNode.rightc == null, curNode.rightc); 
            
            
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Tree theTree = new Tree();
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 20; i++)
            {
                Trade t = new Trade() { Price = r.Next(1, 100), Time = DateTime.Now };
                theTree.Insert(t);
            }
            //theTree.Insert(20);
            //theTree.Insert(25);
            //theTree.Insert(45);
            //theTree.Insert(15);
            //theTree.Insert(67);
            //theTree.Insert(43);
            //theTree.Insert(80);
            //theTree.Insert(33);
            //theTree.Insert(67);
            //theTree.Insert(99);
            //theTree.Insert(91);
            Console.WriteLine("Inorder Traversal : ");
            DateTime start = DateTime.Now;
            theTree.Inorder(theTree.ReturnRoot());
            DateTime end = DateTime.Now;
            Console.WriteLine(end - start);
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine("Preorder Traversal : ");
            start = DateTime.Now;
            theTree.Preorder(theTree.ReturnRoot());
            end = DateTime.Now;
            Console.WriteLine(end - start);
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine("Postorder Traversal : ");
            start = DateTime.Now;
            theTree.Postorder(theTree.ReturnRoot());
            end = DateTime.Now;
            Console.WriteLine(end - start);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            theTree.print(theTree.ReturnRoot());
            Console.WriteLine(" ");
            Console.ReadLine();
        }
    }
}
/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class BinaryTree
    {
        static void Main(string[] args)
        {
            List<TreeNode> tn = new List<TreeNode>();
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 100; i++)
			{
                InsertNode(r.Next);			 
			}
            for (int i = 0; i < tn.Count(); i++)
            {
                tn[i].print();
            }
            Console.ReadLine();
        }

        public class TreeNode
        {
            public int data;
            public List<TreeNode> children;

            public TreeNode(int data, List<TreeNode> children)
            {
                this.data = data;
                this.children = children;
            }

            public void InsertNode(int data)
            {
                if (this.data == null){
                    this.data = data;
                    this.children = new List<TreeNode>();
                }
            }

            public void print()
            {
                print("", true);
            }

            private void print(String prefix, bool isTail) {
                Console.WriteLine(prefix + (isTail ? "└── " : "├── ") + data.ToString());
                for (int i = 0; i < children.Count() - 1; i++) {
                    children[i].print(prefix + (isTail ? "    " : "│   "), false);
                }
                if (children.Count() > 0) {
                    children[children.Count() - 1].print(prefix + (isTail ?"    " : "│   "), true);
                }
            }
        }
    }
}*/
