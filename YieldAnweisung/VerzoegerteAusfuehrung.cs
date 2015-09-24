using System;
using System.Collections.Generic;

class Zahl
{
	public int Wert {get; set;}

	public Zahl()
	{
		Wert = 0;
	}
}

/// <summary>
/// 
/// </summary>
class BeispielVerzoegerteAusfuehrung
{
	static void Main()
	{
		SofortigeAusfuehrung();
		EifrigeAusfuehrung();
		TraegeAusfuehrung();
	}

	static void SofortigeAusfuehrung()
	{
		Console.WriteLine("Sofortige Ausfuehrung");
		IEnumerable<Zahl> eifrig = ZahlenreiheQuadrierenSofort(10);

		// Versuch den Wert erst zu aendern ...
		foreach(var zahl in eifrig)
		{
			zahl.Wert += 1;
		}
		// ... und dann auszugeben
		foreach(var zahl in eifrig)
		{
			Console.WriteLine(zahl.Wert);
		}
	}

	static IEnumerable<Zahl> ZahlenreiheQuadrierenSofort(int maxIndex)
	{
    	var result = new Zahl[maxIndex];
    	for(int i = 0; i < maxIndex; i++)
    	{
        	result[i] = new Zahl() {Wert = Quadriere(i)};
    	}
    	Console.WriteLine("Zahlenreihe erstellt!");
    	return result;
	}

	static void EifrigeAusfuehrung()
	{
		Console.WriteLine("Verzoegerte und EIFRIGE Ausfuehrung");
		IEnumerable<Zahl> eifrig = ZahlenreiheQuadrierenEifrig(10);

		// Versuch den Wert erst zu aendern ...
		foreach(var zahl in eifrig)
		{
			zahl.Wert += 1;
		}
		// ... und dann auszugeben
		foreach(var zahl in eifrig)
		{
			Console.WriteLine(zahl.Wert);
		}
	}

	static IEnumerable<Zahl> ZahlenreiheQuadrierenEifrig(int maxIndex)
	{
    	var result = new Zahl[maxIndex];
    	for(int i = 0; i < maxIndex; i++)
    	{
        	result[i] = new Zahl() {Wert = Quadriere(i)};
    	}
    	Console.WriteLine("Zahlenreihe erstellt!");
    	foreach(var value in result)
    	{
        	yield return value;
    	}
	}

	static void TraegeAusfuehrung()
	{
		Console.WriteLine("Verzoegerte und TRAEGE Ausfuehrung");
		IEnumerable<Zahl> traege = ZahlenreiheQuadrierenTraege(10);

		// Versuch den Wert erst zu aendern ...
		foreach(var zahl in traege)
		{
			zahl.Wert += 1;
		}
		// ... und dann auszugeben
		foreach(var zahl in traege)
		{
			Console.WriteLine(zahl.Wert);
		}
	}

	static IEnumerable<Zahl> ZahlenreiheQuadrierenTraege(int maxIndex)
	{
    	Console.WriteLine("Erstelle Zahlenreihe!");
    	for(int i = 0; i < maxIndex; i++)
    	{
        	yield return new Zahl() {Wert = Quadriere(i)};
    	}
	}

	static int Quadriere(int zahl)
	{
		return zahl * zahl;
	}
}
