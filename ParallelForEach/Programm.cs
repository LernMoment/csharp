using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Zeigt dir was capturing variable bedeutet
/// </summary>
class BeispielParallelForEach
{
	static void Main()
	{
		// Das Ergebnis kannst du übrigens mit der Gaußschen Summenformel überprüfen
		// (n*n + n)/2 https://de.wikipedia.org/wiki/Gaußsche_Summenformel
		SummenformelSequentiell();
		Console.WriteLine("Jetzt das ganze parallel:");
		SummenformelParallel();
	}

	static void SummenformelSequentiell()
	{
		//Alle Zahlen von 1 - 10000000 generieren 
		var zahlen = Enumerable.Range(1, 10000000); 
		long summe = 0;

		foreach(var zahl in zahlen)
		{
			summe += zahl;
		}

		Console.WriteLine("Die Summe aller Zahlen von 1-10000000 ist: {0}", summe);		
	}

	static void SummenformelParallel()
	{
		//Alle Zahlen von 1 - 10000000 generieren 
		var zahlen = Enumerable.Range(1, 10000000); 
		long summe = 0;

		Parallel.ForEach<int, long>
		( 
        	zahlen,
        	() => 0L,
        	(zahl, loopState, zwischenSumme) =>
        	{ 
            	zwischenSumme += zahl;                      //Bilde lokale zwischenSumme - pro Thread 
            	return zwischenSumme; 
        	}, 
        	zwischenSumme => Interlocked.Add(ref summe, zwischenSumme)
		);
		Console.WriteLine("Die Summe aller Zahlen von 1-10000000 ist: {0}", summe);		
	}
}
