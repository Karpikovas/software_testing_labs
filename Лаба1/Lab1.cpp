// Lab1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

void ReduceFraction(int a, int b) {
	int v = a;
	int g = b;
	int c;

	while (v != 0 && g != 0) {

		if (v > g) {
			v = v % v;
		}
		else {
			g = g % v;
		}
	}

	if (a == 0) {
		c = v;
		
	}
	else {
		c = g;
	}
	cout << a / c << " " << b / c << endl;
}

int main()
{
	int a, b;
	cin >> a >> b;
	ReduceFraction(a, b);
	system("pause");
	return 0;
}

