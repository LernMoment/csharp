using System;
using System.Globalization;

/// <summary>
/// Zeigt dir die wichtigsten Formatierungszeichenfolgen für Zahlen
/// </summary>
class LernMoment
{
	static void Main()
	{
		Waehrung();
		Nummern();
		Hexadezimal();
	}

	/// <summary>
	/// Formatbezeichner C - Zur Formatierung mit Währungsinformationen
	/// </summary>
	static void Waehrung()
	{
		int nichts = 0;
		int unbezahlbar = 1000000;

		// C - Währung mit Standardanzahl von Nachkommastellen
		Console.WriteLine("Ein LernMoment kostet dich {0}0:C{1}! ergibt:", "{", "}");
		Console.WriteLine("Ein LernMoment kostet dich {0:C}!", nichts);
		Console.WriteLine();

		// C0 - Währung ohne Nachkommastelle
		Console.WriteLine("Ein LernMoment bringt dir {0}0:C0{1} neue Ideen! ergibt:", "{", "}");
		Console.WriteLine("Ein LernMoment bringt dir {0:C0} neue Ideen!", unbezahlbar);
		Console.WriteLine();
	}

	/// <summary>
	/// Formatbezeichner N - Zur Formatierung von Ganzen Zahlen und Dezimalzahlen
	/// </summary>
	static void Nummern()
	{
		uint anzahlLernMomente = 18;
		int negativ = -12345;

		// N - Gibt jede Art von Zahl (positiv oder negativ) mit 2 Nachkommastellen aus.
		// Dabei werden Gruppentrennzeichen und Dezimaltrennzeichen nach der aktuellen
		// Lokalisierung verwendet.
		Console.WriteLine("Es sind bisher {0}0:N{1} LernMoment erschienen! ergibt:", "{", "}");
		Console.WriteLine("Es sind bisher {0:N} LernMomente erschienen!", anzahlLernMomente);
		Console.WriteLine();

		// N0 - Gibt Zahlen ohne Nachkommastelle aus
		Console.WriteLine("Die 0 in {0}0:N0{1} gibt an, dass keine Nachkommastellen ausgegeben werden.", "{", "}");
		Console.WriteLine("Eine negative Zahl ohne Nachkommastelle: {0}0:N0{1} ergibt:", "{", "}");
		Console.WriteLine("Eine negative Zahl ohne Nachkommastelle: {0:N0}", negativ);
		Console.WriteLine();

		// N6 - Gibt Zahlen mit 6 Nachkommastelle aus
		Console.WriteLine("Die 6 in {0}0:N6{1} gibt an, dass 6 Nachkommastellen ausgegeben werden.", "{", "}");
		Console.WriteLine("Pi mit 6 Nachkommastellen: {0}0:N6{1} ergibt:", "{", "}");
		Console.WriteLine("Pi mit 6 Nachkommastellen: {0:N6}", Math.PI);
		Console.WriteLine();
	}

	/// <summary>
	/// Formatbezeichner X - Zur Formatierung von Ganzen Zahlen im Hex-Format
	/// </summary>
	static void Hexadezimal()
	{
		int wenige = 10;
		int unbezahlbar = 1048575;

		// X - Gibt die Zahl als Hexadezimalzahl mit großen Buchstaben aus
		Console.WriteLine("Für einen LernMoment (inkl. allem) brauchst du 0x{0}0:X{1} Minuten! ergibt:", "{", "}");
		Console.WriteLine("Für einen LernMoment (inkl. allem) brauchst du 0x{0:X} Minuten!", wenige);
		Console.WriteLine();

		// x - Gibt die Zahl als Hexadezimalzahl mit kleinen Buchstaben aus
		Console.WriteLine("Ein LernMoment bringt dir 0x{0}0:x{1} neue Ideen! ergibt:", "{", "}");
		Console.WriteLine("Ein LernMoment bringt dir 0x{0:x} neue Ideen!", unbezahlbar);
		Console.WriteLine();

		// x7 - Gibt die Zahl als Hexadezimalzahl mit kleinen Buchstaben und mindestens 7 Ziffern aus
		Console.WriteLine("Ein LernMoment bringt dir 0x{0}0:x7{1} neue Ideen! ergibt:", "{", "}");
		Console.WriteLine("Ein LernMoment bringt dir 0x{0:x7} neue Ideen!", unbezahlbar);
		Console.WriteLine();
	}

}
