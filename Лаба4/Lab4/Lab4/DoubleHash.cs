using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lab4
{
    unsafe class DoubleHash
    {
        public const int TABLE_SIZE = 20;
        public const int PRIME = 7;


        int[] hashTable;
        int curr_size;

	    public bool isFull()
        {
            return (curr_size == TABLE_SIZE);
        }

        int hash1(int key)
        {
            return (key % TABLE_SIZE);
        }


        int hash2(int key)
        {
            return (PRIME - (key % PRIME));
        }

        public DoubleHash()
        {
            hashTable = new int[TABLE_SIZE];
            curr_size = 0;
            for (int i = 0; i < TABLE_SIZE; i++)
                hashTable[i] = -1;
        }

        public void insert(int key)
        {

            if (isFull())
                return;

            int index = hash1(key);

            if (hashTable[index] != -1)
            {
                int index2 = hash2(key);
                int i = 1;

                for (; ;)
                {
                    int newIndex = (index + i * index2) %
                        TABLE_SIZE;

                    if (hashTable[newIndex] == -1)
                    {
                        hashTable[newIndex] = key;
                        break;
                    }
                    i++;
                }
            }

            else
                hashTable[index] = key;
            curr_size++;
        }


        public string get()
        {
            string result = "";
            for (int i = 0; i < TABLE_SIZE; i++)
            {
                if (hashTable[i] != -1)
                    result += i + " --> " + hashTable[i] + Environment.NewLine;
                else
                    result += i + Environment.NewLine;
            }
            return result;
        }



    }
}
