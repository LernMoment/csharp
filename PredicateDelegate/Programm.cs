using System;
using System.Collections.Generic;

class LernMoment
{
	public string Name { get; set; }
	public int AnzahlWoerter { get; set; }

	public LernMoment(string name, int anzahlWoerter)
	{
		Name = name;
		AnzahlWoerter = anzahlWoerter;
	}
}

class PredicateDelegateBeispiel
{
	static void Main()
	{
		var lernMomentListe = new List<LernMoment>();
		lernMomentListe.AddRange( new LernMoment[] { 
			new LernMoment("Predicate Delegate", 500),
			new LernMoment("Nuget", 150),
			new LernMoment("Command CanExecute", 25)});

		Console.WriteLine("Gebe eine Zahl zwischen 26 und 500 ein:");
		string eingabe = Console.ReadLine();
		int eingegebeneZahl = Int32.Parse(eingabe);

		LernMoment lernMomentMitWenigerAls100Woertern = lernMomentListe.Find(x => x.AnzahlWoerter < eingegebeneZahl);

		Console.WriteLine("Ein LernMoment mit weniger als {1} Woertern ist: {2}, er enthaelt {0} Woerter.",
			lernMomentMitWenigerAls100Woertern.AnzahlWoerter, eingegebeneZahl, lernMomentMitWenigerAls100Woertern.Name);
	}

}
