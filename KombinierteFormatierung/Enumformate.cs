using System;

/// <summary>
/// Zeigt dir die wichtigsten Formatierungszeichenfolgen für Enums
/// </summary>
class LernMoment
{
	[Flags]
	enum Farbe : byte
	{
		Schwarz = 0,
		Rot = 1,
		Gruen = 2,
		Blau = 4,
		Weiss = 8
	}

	enum KombinierteFarben : byte
	{
		None = 0,
		Gelb = 4,
		Pink = 8
	}

	static void Main()
	{
		var meineFarbe = Farbe.Blau | Farbe.Weiss;
		var kombiFarbe = KombinierteFarben.Gelb | KombinierteFarben.Pink;

		Console.WriteLine("Meine ausgewählte Farbe als Zeichenfolge ist: {0:G}", meineFarbe);
		Console.WriteLine("Meine ausgewählte Farbe als Ganzzahl ist: {0:D}", meineFarbe);
		Console.WriteLine("Meine ausgewählte Farbe in Hexadezimal: 0x{0:x}", meineFarbe);
		Console.WriteLine("Meine kombinierte Farbe mit Formatierungszeichen 'G' ist: {0}", kombiFarbe.ToString("G"));
		Console.WriteLine("Meine kombinierte Farbe mit Formatierungszeichen 'F' ist: {0}", kombiFarbe.ToString("F"));
	}
}
