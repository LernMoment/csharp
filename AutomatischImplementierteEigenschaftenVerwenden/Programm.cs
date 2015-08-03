using System;

class UnveraenderlicheKlasse
{
	public int IntEigenschaft { get; }
	public double Kehrwert => 1/((double)IntEigenschaft);

	public UnveraenderlicheKlasse(int wert)
	{
		IntEigenschaft = wert;
	}
}

class EineKlasse
{
	public double DoubleEigenschaft { get; set; } = 0.0238095238095238f;
	public double Kehrwert => 1 / DoubleEigenschaft;
}

/// <summary>
/// Beispiel zeigt ...
/// </summary>
class LernMoment
{
	static void Main()
	{
		UnveraenderlicheKlasse unveraenderlich = new UnveraenderlicheKlasse(42);

		Console.WriteLine("Unveraenderliche Klasse:");
		Console.WriteLine("Die IntEigenschaft wurde mit {0} initialisiert.", unveraenderlich.IntEigenschaft);
		Console.WriteLine("Der Kehrwert davon ist {0}", unveraenderlich.Kehrwert.ToString());

		EineKlasse veraenderlich = new EineKlasse();
		Console.WriteLine();
		Console.WriteLine("Eine Klase:");
		Console.WriteLine("Die DoubleEigenschaft wurde mit {0} initialisiert.", veraenderlich.DoubleEigenschaft);
		Console.WriteLine("Der Kehrwert davon ist {0}", veraenderlich.Kehrwert.ToString());
		veraenderlich.DoubleEigenschaft = 0.01;
		Console.WriteLine("Die DoubleEigenschaft wurde auf {0} geaendert.", veraenderlich.DoubleEigenschaft);
		Console.WriteLine("Der Kehrwert davon is {0}, obwohl es eine Eigenschaft nur mit getter ist!", veraenderlich.Kehrwert);
	}
}
