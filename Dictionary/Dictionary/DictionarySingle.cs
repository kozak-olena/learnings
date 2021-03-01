using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{

    class DictionaryBucket
    {
        public string key;
        public string value;
    }

    class Dictionary
    {
        private DictionaryBucket[] _array;

        public int index = 0;
        private int sizeOfArray = 10;
        private int growthCoefficient = 2;

        public Dictionary()
        {
            DictionaryBucket[] newArray = new DictionaryBucket[sizeOfArray];
            _array = newArray;

        }

        public void Add(string key, string value)
        {

            AddToArray(key, value);

        }

        private void GetIndex(string key)
        {

            int keyHash = key.GetHashCode();
            index = Math.Abs(keyHash % sizeOfArray);


        }

        public string Get(string key)
        {
            string value = "there is no such value";

            GetIndex(key);

            for (int i = index; i < _array.Length; i++)
            {
                if (_array[i].key == key)
                {
                    value = _array[i].value;
                    break;
                }
            }


            return value;

        }

        private DictionaryBucket[] Rehashing(string key)
        {

            sizeOfArray = _array.Length * growthCoefficient;

            DictionaryBucket[] newArray = new DictionaryBucket[sizeOfArray];
            GetIndex(key);

            for (int i = 0; i < _array.Length; i++)
            {
                int keyHash = _array[i].key.GetHashCode();
                int newIndex = Math.Abs(keyHash % sizeOfArray);

                while (newArray[newIndex] != null)
                {
                    newIndex++;
                }

                if (newIndex == sizeOfArray)
                {
                    for (int j = 0; i < _array.Length; i++)
                    {
                        if (_array[i] == null)
                        {
                            newIndex = i;

                        }
                    }
                }
                newArray[newIndex] = _array[i];

            }

            _array = newArray;

            return _array;
        }




        private bool IsAllIndexesChecked()
        {
            bool isAllIndexesChecked = true;

            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == null)
                {
                    isAllIndexesChecked = false;
                    index = i;

                }
            }

            return isAllIndexesChecked;

        }


        private void GetIndexIfValueIsNotNull(string key)
        {
            while (_array[index] != null)
            {
                index++;
                if (index == _array.Length)
                {
                    bool isAllIndexesChecked = IsAllIndexesChecked();

                    if (isAllIndexesChecked)
                    {
                        _array = Rehashing(key);

                        GetIndex(key);
                    }

                }
            }

        }

        private void AddToArray(string key, string value)
        {
            DictionaryBucket dictionaryBucket = new DictionaryBucket();
            dictionaryBucket.key = key;
            dictionaryBucket.value = value;

            GetIndex(key);

            if (_array[index] == null)
            {
                _array[index] = dictionaryBucket;
            }
            else
            {
                GetIndexIfValueIsNotNull(key);

                _array[index] = dictionaryBucket;

            }

        }
    }

}

