using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class TreeNode
    {
        public TreeNode RightChild;
        public TreeNode LeftChild;
        public int Value;

        public bool DoesRightChildHaveValueOf(int value)
        {
            bool isItRigthChild = false;
            if (RightChild != null)
            {
                if (RightChild.Value == value)
                {
                    isItRigthChild = true;
                }
            }

            return isItRigthChild;
        }

        public void SetChild(TreeNode currentNode)
        {
            if (Value < currentNode.Value)
            {
                RightChild = currentNode;
            }
            else
            {
                LeftChild = currentNode;
            }
        }
    }

    class Tree
    {
        TreeNode rootNode;
        int lengthOfTree = 0;

        public int[] InOrderTraverse()
        {
            int[] array = new int[lengthOfTree];
            int index = 0;
            InOrderTraverseRecursion(rootNode, array, ref index);

            return array;
        }

        private void InOrderTraverseRecursion(TreeNode current, int[] array, ref int index)
        {
            if (current == null)
            {
                return;
            }
            else
            {
                InOrderTraverseRecursion(current.LeftChild, array, ref index);
                array[index] = current.Value;
                index++;
                Console.WriteLine(current.Value);

                InOrderTraverseRecursion(current.RightChild, array, ref index);
            }

        }

        public void PreOrderTraverse()
        {
            PreOrderRecursion(rootNode);
        }

        private void PreOrderRecursion(TreeNode current)
        {
            if (current == null)
            {
                return;
            }
            else
            {
                Console.WriteLine(current.Value);
                PreOrderRecursion(current.LeftChild);
                PreOrderRecursion(current.RightChild);
            }
        }

        public void Insert(int value)
        {
            TreeNode newNode = new TreeNode();
            newNode.Value = value;

            if (rootNode == null)
            {

                rootNode = newNode;
            }
            else
            {
                InsertRecursion(rootNode, value);
            }
            lengthOfTree++;
        }

        private void InsertRecursion(TreeNode currentNode, int value)
        {
            TreeNode newNode = new TreeNode();
            newNode.Value = value;

            if (value > currentNode.Value)
            {
                if (currentNode.RightChild == null)
                {
                    currentNode.RightChild = newNode;
                }
                else
                {
                    InsertRecursion(currentNode.RightChild, value);
                }
            }
            else
            {
                if (currentNode.LeftChild == null)
                {
                    currentNode.LeftChild = newNode;
                }
                else
                {
                    InsertRecursion(currentNode.LeftChild, value);
                }
            }
        }

        public void Delete(int value)
        {
            TreeNode currentNodeWithValueToDelete = GetNodeWithValue(rootNode, value);

            TreeNode parentNode = GetParentNodeRecursion(null, rootNode, currentNodeWithValueToDelete.Value);
            if (currentNodeWithValueToDelete.LeftChild == null && currentNodeWithValueToDelete.RightChild == null)
            {
                DeleteLeaf(parentNode, rootNode, value);
            }
            else if ((currentNodeWithValueToDelete.LeftChild == null && currentNodeWithValueToDelete.RightChild != null) || (currentNodeWithValueToDelete.RightChild == null && currentNodeWithValueToDelete.LeftChild != null))
            {
                DeleteChildWithOneChild(currentNodeWithValueToDelete, parentNode);

            }
            else
            {
                DeleteChildWithTwoChildren(parentNode, currentNodeWithValueToDelete, value);
            }

            lengthOfTree--;
        }



        private TreeNode GetNodeWithValue(TreeNode currentNode, int value)
        {
            TreeNode result;

            if (value == currentNode.Value)
            {
                result = currentNode;
            }
            else
            {
                if (value > currentNode.Value)
                {
                    result = GetNodeWithValue(currentNode.RightChild, value);
                }
                else
                {
                    result = GetNodeWithValue(currentNode.LeftChild, value);
                }
            }

            return result;
        }

        private void DeleteLeaf(TreeNode parent, TreeNode currentNode, int valueToDelete)
        {
            if (parent == null)
            {
                currentNode = null;

            }
            else
            {

                bool doesRightNeedToBeDeleted = parent.DoesRightChildHaveValueOf(valueToDelete);

                if (doesRightNeedToBeDeleted)
                {
                    parent.RightChild = null;
                }
                else
                {
                    parent.LeftChild = null;
                }
            }

        }

        private void DeleteChildWithOneChild(TreeNode currentNode, TreeNode parent)
        {
            if (parent == null)
            {
                if (currentNode.RightChild != null)
                {
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    currentNode = currentNode.LeftChild;
                }
            }
            else
            {
                if (currentNode.RightChild != null)
                {
                    parent.SetChild(currentNode.RightChild);
                }
                else
                {
                    parent.SetChild(currentNode.LeftChild);
                }
            }


        }

        private void DeleteChildWithTwoChildren(TreeNode parent, TreeNode current, int value)
        {
            TreeNode theSmalestFromRightSide = GetTheSmalest(current);


            theSmalestFromRightSide.LeftChild = current.LeftChild;

            if (current.RightChild == theSmalestFromRightSide)
            {
                current.RightChild = theSmalestFromRightSide.RightChild;
            }
            else
            {
                TreeNode parentOfTheSmalest = GetParentNodeRecursion(parent, current, theSmalestFromRightSide.Value);
                if (theSmalestFromRightSide.RightChild != null)
                {
                    parentOfTheSmalest.LeftChild = theSmalestFromRightSide.RightChild;
                    theSmalestFromRightSide.RightChild = current.RightChild;
                }
                else
                {
                    theSmalestFromRightSide.RightChild = current.RightChild;
                    parentOfTheSmalest.LeftChild = null;
                }
             

            }

            if (parent == null)
            {
               rootNode = theSmalestFromRightSide;
            }
            else
            {
                parent.SetChild(theSmalestFromRightSide);
            }
        }


        private TreeNode GetTheSmalest(TreeNode currentNode)
        {
            currentNode = currentNode.RightChild;

            while (currentNode.LeftChild != null)
            {
                currentNode = currentNode.LeftChild;
            }
            return currentNode;
        }

        private TreeNode GetParentNodeRecursion(TreeNode currentParent, TreeNode currentNode, int valueToDelete)
        {
            if (currentNode == null)
            {
                throw new ArgumentNullException(nameof(currentNode));
            }

            if (currentNode.Value == valueToDelete)
            {
                return currentParent;
            }
            else
            {
                if (valueToDelete > currentNode.Value)
                {

                    return GetParentNodeRecursion(currentNode, currentNode.RightChild, valueToDelete);

                }
                else
                {
                    return GetParentNodeRecursion(currentNode, currentNode.LeftChild, valueToDelete);
                }
            }
        }
    }
}

