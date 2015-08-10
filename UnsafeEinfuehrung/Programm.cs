using System;

/// <summary>
/// Beispiel zeigt die Verwendung des Schlüsselwortes unsafe
/// </summary>
class LernMoment
{
	static void Main()
	{
        int var = 20;

        unsafe
        {
        	int* p = &var;
        	Console.WriteLine("Der Wert der Variable ist: {0} ",  var);
        	Console.WriteLine("Der Wert der Variable, auf die der Zeiger zeigt: {0} ",  p->ToString());
        	Console.WriteLine("Die Adresse der Variable ist: {0}",  (uint)p);
        }

        Console.ReadKey();
	}
}
