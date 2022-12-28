using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree_135
{
    class Node
    {
        public string info;
        public Node leftchild;
        public Node rightchild;

        //Constructor for the Node class
        public Node(string i, Node l, Node r)
        {
            info = i;
            leftchild = l;
            rightchild = r;
        }
    }
    /*A node class consist of three things, 
     * the information, referances to the right child and left child*/ 
    class Program
    {
        public Node ROOT;
        public Program()
        {
            ROOT = null; /*Initializing ROOT to null*/
        }
        public void search(string element, ref Node parent, ref Node currentNode)
        {
            /*This function searchs the currentNode of the specified Node 
             * as well as the currentNode of its parents */
            currentNode = ROOT;
            parent = null;
            while ((currentNode != null) && (currentNode.info != element))
            {
                parent = currentNode;
                if (string.Compare(element, currentNode.info) < 0)
                    currentNode = currentNode.leftchild;
                else
                    currentNode = currentNode.rightchild;
            }

        }
        public void insert(string element)/* Insert a node in the binary search tree */
        {
            Node tmp, parent = null, currentNode = null;
            search(element, ref parent, ref currentNode);
            if(currentNode != null)/*Chech if the node to be inserted already inserted or not*/
            {
                Console.WriteLine("Duplicate words not allowed");
                return;
            }
            else//if the specified node is not present
            {
                tmp = new Node(element, null, null);//creates a node
                if(parent == null)//if the trees is empty
                {
                    ROOT = tmp;

                }
                else if (string.Compare(element, parent.info) < 0)
                {
                    parent.leftchild = tmp;
                }
                else
                {
                    parent.rightchild = tmp;
                }
            }

        }
        public void inorder(Node ptr)
        {
            if(ROOT == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            if(ptr != null)
            {
                inorder(ptr.leftchild);
                Console.WriteLine(ptr.info + "");
                inorder(ptr.rightchild);
            }
        }
        public void preorder(Node ptr)
        {
            if (ROOT == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            if (ptr != null)
            {
                Console.WriteLine(ptr.info + "");
                preorder(ptr.leftchild); 
                preorder(ptr.rightchild);
            }
        }
        public void postorder(Node ptr)//performs the postorder traversal of the tree
        {
            if (ROOT == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            if (ptr != null)
            {
                postorder(ptr.leftchild);
                postorder(ptr.rightchild);
                Console.WriteLine(ptr.info + "");
            }
        }
        static void Main(string[] args)
        {
            Program x = new Program();
            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1. Implement insert option");
                Console.WriteLine("2. Perform inorder traversal");
                Console.WriteLine("3. Perform preorder traversal");
                Console.WriteLine("4. Perform postorder traversal");
                Console.WriteLine("5. Exit");
                Console.Write("\nEnter your choice (1-5): ");
                char ch;
                ch = Convert.ToChar(Console.ReadLine());
                Console.WriteLine();
                switch (ch)
                {
                    case '1':
                        {
                            Console.Write("Enter a word: ");
                            string word = Console.ReadLine();
                            Console.WriteLine();
                            x.insert(word);
                        }
                        break;
                    case '2':
                        {
                            x.inorder(x.ROOT);
                        }
                        break;
                    case '3':
                        {
                            x.preorder(x.ROOT);
                        }
                        break;
                    case '4':
                        {
                            x.postorder(x.ROOT);
                        }
                        break;
                    case '5':
                        return;
                        
                    default:
                        {
                            Console.WriteLine("Invalid option");
                        }
                        break;


                }

            }
        }
    }
}
