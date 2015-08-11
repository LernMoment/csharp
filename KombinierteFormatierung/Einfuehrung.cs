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

		// Einfach nur den Wert eines Objektes in den String einfügen:
		Console.WriteLine("LernMoment '{0}0{1}'! ergibt:", "{", "}");
		Console.WriteLine("LernMoment '{0}'!", name);
		Console.WriteLine();

		// Die Formatzeichenfolge wird mit : getrennt vom Index angegeben
		Console.WriteLine("LernMoment '{0}0{1}', erschienen am {0}1:D{1} ergibt:", "{", "}");
		Console.WriteLine("LernMoment '{0}', erschienen am {1:D}", name, datum);
		Console.WriteLine();

		// Ein Objekt merhfach verwenden mit verschiedenen Formatierungen
		Console.WriteLine("LernMoment '{0}0{1}', erschienen am {0}1:D{1}, um {0}1:t{1} ergibt:", "{", "}");
		Console.WriteLine("LernMoment '{0}', erschienen am {1:D}, um {1:t}", name, datum);
		Console.WriteLine();

		LokalisierungMitStringFormat();
	}

	static void LokalisierungMitStringFormat()
	{
		string name = "Kombinierte Formatierung";
		DateTime datum = new DateTime(2015, 08, 12, 09, 30, 00);
		string landesspezifischFormatiert;

		// Definieren welche Kultur verwendet werden soll (z.B. de-DE, fr-FR, en-US).
		// CultureInfo implementiert IFormatProvider welches für die landesspezifische 
		// Formatierung benötigt wird.
		CultureInfo deutsch = new CultureInfo("de-DE");

		Console.WriteLine("String.Format kann einen IFormatProvider verwenden.");
		Console.WriteLine("Damit kannst du explizit eine Landeseinstellung vorgeben.");

		// Neben dem IFormatProvider, verwendet String.Format eine übliche kombinierte Formatierung
		landesspezifischFormatiert = String.Format(deutsch, "LernMoment '{0}', erschienen am {1:D}", name, datum);
		Console.WriteLine(landesspezifischFormatiert);
	}
}
