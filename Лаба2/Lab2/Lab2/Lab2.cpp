// Lab2.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
using namespace std;

// Hash table size 
#define TABLE_SIZE 20

// Used in second hash function. 
#define PRIME 7 

class DoubleHash
{
	// Pointer to an array containing buckets 
	int *hashTable;
	int curr_size;

public:

	// function to check if hash table is full 
	bool isFull()
	{

		// if hash size reaches maximum size 
		return (curr_size == TABLE_SIZE);
	}

	// function to calculate first hash 
	int hash1(int key)
	{
		return (key % TABLE_SIZE);
	}

	// function to calculate second hash 
	int hash2(int key)
	{
		return (PRIME - (key % PRIME));
	}

	DoubleHash()
	{
		hashTable = new int[TABLE_SIZE];
		curr_size = 0;
		for (int i = 0; i < TABLE_SIZE; i++)
			hashTable[i] = -1;
	}

	// function to insert key into hash table 
	void insert(int key)
	{
		// if hash table is full 
		if (isFull()) //{1}
			return;

		// get index from first hash 
		int index = hash1(key); //{2}

		// if collision occurs 
		if (hashTable[index] != -1) //{3}
		{
			// get index2 from second hash 
			int index2 = hash2(key); //{4}
			int i = 1; //{4}
			while (1) // {5}
			{
				// get newIndex 
				int newIndex = (index + i * index2) %
					TABLE_SIZE; // {6}

				// if no collision occurs, store 
				// the key 
				if (hashTable[newIndex] == -1) //{7}
				{
					hashTable[newIndex] = key;
					break;
				}
				i++; //{8}
			}
		}

		// if no collision occurs 
		else
			hashTable[index] = key;
		curr_size++;
	}

	// function to display the hash table 
	void get()
	{
		for (int i = 0; i < TABLE_SIZE; i++)
		{
			if (hashTable[i] != -1)
				cout << i << " --> "
				<< hashTable[i] << endl;
			else
				cout << i << endl;
		}
	}
};

// Driver's code 
int main()
{
	int a[] = { 19, 19, 27, 36, 10, 64, 10, 64, 64, 64, 64, 10, 27, 27, 27 };
	int n = sizeof(a) / sizeof(a[0]);

	// inserting keys into hash table 
	DoubleHash h;
	for (int i = 0; i < n; i++)
		h.insert(a[i]);

	// display the hash Table 
	h.get();

	system("pause");
	return 0;
}