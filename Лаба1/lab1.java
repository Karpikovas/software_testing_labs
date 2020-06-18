import java.util.*;
import java.lang.*;
import java.io.*;

class Reduce
{
	public static void ReduceFraction(int a, int b) {
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
		System.out.println(a / c + " " + b / c);
	}
	
	public static void main (String[] args) throws java.lang.Exception
	{
		int a, b;
		Scanner s = new Scanner(System.in); 
 
        a = s.nextInt();
        b = s.nextInt();
        
		ReduceFraction(a, b);
	}
}