using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linked_List
{
    class linked
    {
        class Node
        {
            public Node NextNode;
            public int Value;

        }
        class LinkedList
        {
            Node rootNode = null;

            public void Add(int value)
            {
                Node newNode = new Node();
                newNode.Value = value;

                if (rootNode == null)
                {
                    rootNode = newNode;
                }
                else
                {
                    Node lastNode = FindLastNode(rootNode);
                    lastNode.NextNode = newNode;
                }
            }

            public void Remove()
            {
                Node lastNode = FindLastButOne(rootNode);
                lastNode.NextNode = null;
            }

            public void RemoveAt(int index)
            {
                Node nodeBeforeRemovable = FindNodeBefore(rootNode, index);
                Node nodeToRemove = FindAtIndex(rootNode, index);
                nodeBeforeRemovable.NextNode = nodeToRemove.NextNode;
            }

            public int Get(int index)
            {
                int value = 0;

                Node nodeByIndex = FindAtIndex(rootNode, index);
                value = nodeByIndex.Value;

                return value;

            }

            public void Clear()
            {
                while (rootNode.NextNode != null)
                {
                    Remove();
                }

                Node node = new Node();
                rootNode = node;

            }

            private Node FindNodeBefore(Node rootNode, int index)
            {
                Node node = rootNode;


                for (int i = 0; i < index - 2; i++)
                {
                    node = node.NextNode;
                }

                return node;

            }

            public int GetLength()
            {
                int length = 0;
                Node currentNode = rootNode;

                while (currentNode.NextNode != null)
                {
                    currentNode = currentNode.NextNode;
                    length++;
                }
                length++;
                return length;

            }

            private Node FindAtIndex(Node rootNode, int index)
            {
                Node nodeAtIndex = rootNode;

                for (int i = 0; i < index - 1; i++)
                {
                    nodeAtIndex = nodeAtIndex.NextNode;
                }

                return nodeAtIndex;

            }

            private Node FindLastButOne(Node rootNode)
            {
                Node current = rootNode;
                Node lastButOne = new Node();

                while (current.NextNode != null)
                {
                    lastButOne = current;
                    current = current.NextNode;
                }
                return lastButOne;

            }


            private Node FindLastNode(Node rootNode)
            {


                Node current = rootNode;

                while (current.NextNode != null)
                {
                    current = current.NextNode;
                }
                return current;


            }

        }

        static void Main(string[] args)
        {

            LinkedList linkedList = new LinkedList();
            linkedList.Add(5);
            linkedList.Add(14);
            linkedList.Add(34);
            linkedList.Remove();

            
            //linkedList.set_Name("sdfgdsf")
            Console.WriteLine(linkedList.Get(2));
            linkedList.Add(10);
            linkedList.RemoveAt(3);

            int[] arr = new int[3];

            int b = arr[2];
            arr[1] = 53;
        }
    }
}
