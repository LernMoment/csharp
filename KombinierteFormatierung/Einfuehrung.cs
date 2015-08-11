using System;
using System.Globalization;

/// <summary>
/// Zeigt dir wie du Strings mit der kombinierten Formatierung verwendest
/// </summary>
class LernMoment
{
	static void Main()
	{
		string name = "Kombinierte Formatierung";
		DateTime datum = new DateTime(2015, 08, 12, 09, 30, 00);
		Console.WriteLine("LernMoment '{0}', erschienen am {1:D}, um {1:t}", name, datum);

		// MERKE:
		// Formatbezeichner 'D' für langes Datum
		// Formatbezeichner 't' für kurze Uhrzeit
	}
}
