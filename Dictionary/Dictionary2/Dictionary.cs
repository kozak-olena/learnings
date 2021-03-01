using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary2
{


    class DictionaryBucketNode
    {
        public string key;
        public string value;
    }


    class Dictionary
    {
        private LinkedList[] _array;

        public int index = 0;
        private int sizeOfArray = 5;
        private int growthCoefficient = 2;
        private int sizeOfList = 5;

        public Dictionary()
        {
            LinkedList[] newArray = new LinkedList[sizeOfArray];
            _array = newArray;

        }

        private int GetIndex(string key)
        {
            int keyHash = key.GetHashCode();
            index = Math.Abs(keyHash % sizeOfArray);

            return index;
        }

        private void Rehashing()
        {
            sizeOfArray = 1 + sizeOfArray * growthCoefficient;
            LinkedList[] newArray = new LinkedList[sizeOfArray];

            for (int i = 0; i < _array.Length; i++)
            {
                LinkedList newLinkedList = _array[i];
                if (newLinkedList != null)
                {
                    for (int j = 0; j < _array[i].GetLength(); j++)
                    {
                        DictionaryBucketNode currentDictionaryBucketNode = newLinkedList.GetDictionaryBucketNode(j);

                        int keyHash = currentDictionaryBucketNode.key.GetHashCode();
                        int newIndex = Math.Abs(keyHash % sizeOfArray);

                        if (newArray[newIndex] == null)
                        {
                            LinkedList linkedList = new LinkedList();
                            linkedList.Add(currentDictionaryBucketNode);
                            newArray[newIndex] = linkedList;
                        }
                        else
                        {
                            newArray[newIndex].Add(currentDictionaryBucketNode);
                        }
                    }
                }


            }

            _array = newArray;

        }

        public void Add(string key, string value)
        {
            DictionaryBucketNode dictionaryBucketNode = new DictionaryBucketNode();
            dictionaryBucketNode.key = key;
            dictionaryBucketNode.value = value;

            GetIndex(key);
            bool isItFull = IsLinkedListFull(index, dictionaryBucketNode);

            if (isItFull)
            {
                Rehashing();
                GetIndex(key);
                if (_array[index] == null)
                {
                    LinkedList linkedList = new LinkedList();
                    linkedList.Add(dictionaryBucketNode);
                    _array[index] = linkedList;

                }
                else
                {
                    _array[index].Add(dictionaryBucketNode);
                }

            }
            else
            {
                GetIndex(key);
                if (_array[index] == null)
                {
                    LinkedList linkedList = new LinkedList();
                    linkedList.Add(dictionaryBucketNode);
                    _array[index] = linkedList;

                }
                else
                {
                    _array[index].Add(dictionaryBucketNode);
                }

            }


        }

        public string Get(string key)
        {
            int keyHash = key.GetHashCode();
            int newIndex = Math.Abs(keyHash % sizeOfArray);
            LinkedList linkedList = new LinkedList();
            linkedList = _array[newIndex];
            if (linkedList != null)
            {
                int sizeOfLinkedList = linkedList.GetLength();

                for (int i = 0; i < sizeOfLinkedList; i++)
                {
                    DictionaryBucketNode currentDictionaryBucketNode = linkedList.GetDictionaryBucketNode(i);

                    if (currentDictionaryBucketNode.key == key)
                    {
                        return currentDictionaryBucketNode.value;
                    }



                }

            }

            throw new KeyNotFoundException();
        }

        private bool IsLinkedListFull(int index, DictionaryBucketNode dictionaryBucketNode)
        {
            bool isLinkedListFull = false;
            if (_array[index] != null)
            {
                int length = _array[index].GetLength();
                if (length == sizeOfList)
                {
                    isLinkedListFull = true;
                }
            }



            return isLinkedListFull;
        }



    }

}

