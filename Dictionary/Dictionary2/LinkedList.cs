using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary2
{
    class LinkedList
    {
        private class Node
        {
            public Node NextNode;
            public DictionaryBucketNode Value;
        }

        Node rootNode = null;

        public void Add(DictionaryBucketNode dictionaryBucketNode)
        {
            Node newNode = new Node();
            newNode.Value = dictionaryBucketNode;

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

        public DictionaryBucketNode GetDictionaryBucketNode(int newIndex)
        {

            DictionaryBucketNode dictionaryBucketNode = new DictionaryBucketNode();

            Node nodeAtIndex = rootNode;

            for (int i = 0; i < newIndex; i++)
            {
                nodeAtIndex = nodeAtIndex.NextNode;
            }

            dictionaryBucketNode = nodeAtIndex.Value;

            return dictionaryBucketNode;
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

        private Node FindAtIndex(Node rootNode, int newIndex)
        {
            Node nodeAtIndex = rootNode;

            for (int i = 0; i < newIndex; i++)
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
}
