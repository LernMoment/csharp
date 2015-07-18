using System;

delegate int RechenOperation(int a, int b);

class LernMoment
{
	static void Main()
	{
    	RechenOperation multipliziere = (x, y) => x * y;
    	int resultat = multipliziere(4, 5);

    	Console.WriteLine("Resultat ist: " + resultat);
	}
}
