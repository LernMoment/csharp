using System;

/// <summary>
/// Zeigt dir was capturing variable bedeutet
/// </summary>
class BeispielCapturingVariable
{
	static Action dasDelegate;

	static void Main()
	{
		ZeigeErstenGrundsatz();
		ZeigeZweitenGrundsatz();

		int dieMagischeZahl = 42;

		Func<int, int, int> multipliziereZahlen = (zahl1, zahl2) => zahl1 * zahl2;

		dieMagischeZahl = 10;

		Console.WriteLine( multipliziereZahlen(dieMagischeZahl, 25) );
	}

	static void ZeigeZweitenGrundsatz()
	{
		InitialisiereDasDelegate();

		// die lokale Variable aus der vorherigen Methode lebt solange,
		// wie das Delegate, welches sie verwendet.
		dasDelegate();
	}

	static void InitialisiereDasDelegate()
	{
		int eineLokaleZahl = 5;

		dasDelegate = () => Console.WriteLine("Wert der captured variable: {0}", eineLokaleZahl);
	}

	static void ZeigeErstenGrundsatz()
	{
		int dieMagischeZahl = 42;

		Func<int, int> multipliziereMitMagischerZahl = zahl => zahl * dieMagischeZahl;

		dieMagischeZahl = 10;

		Console.WriteLine( multipliziereMitMagischerZahl(2) );
	}
}
