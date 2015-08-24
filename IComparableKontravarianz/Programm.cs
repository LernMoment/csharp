using System;
using System.Collections.Generic;
using System.Linq;

class LernMoment : IComparable<LernMoment>
{
	public LernMoment(string name, DateTime erschienenAm)
	{
		Name = name;
		ErschienenAm = erschienenAm;
	}

	public string Name { get; private set; }
	public DateTime ErschienenAm { get; private set; }

	public int CompareTo(LernMoment other)
    {
        // If other is not a valid object reference, this instance is greater.
        if (other == null) return 1;

        return ErschienenAm.CompareTo(other.ErschienenAm);
    }
}

class LernMomentCSharp : LernMoment, IComparable<LernMomentCSharp>
{
	public LernMomentCSharp(string name, DateTime erschienenAm) : base(name, erschienenAm)
	{}

	public int CompareTo(LernMomentCSharp other)
    {
        if (other == null) return 1;

        return Name.CompareTo(other.Name);
    }
}

/// <summary>
/// Zeigt dir wie du IComparable<T> implementierst und Kontravarianz anwendest
/// </summary>
class Programm
{
	static void Main()
	{
		var erfolgsMomente 
			= new List<LernMomentCSharp> {new LernMomentCSharp("Func", new DateTime(2015, 08, 17)),
									new LernMomentCSharp("Var", new DateTime(2015, 07, 26)),
									new LernMomentCSharp("Lambda", new DateTime(2015, 07, 29)),
									new LernMomentCSharp("Predicate", new DateTime(2015, 07, 31))};

		Console.WriteLine("LernMomentCSharp hat seine eigene CompareTo-Methode (basierend auf Name):");
		erfolgsMomente.Sort();
		LernMomenteAusgeben(erfolgsMomente);

		Console.WriteLine("Kontravarianz - Nun mit CompareTo aus der Basisklasse (basierend auf ErschienenAm):");
		IComparer<LernMoment> basisVergleicher = Comparer<LernMoment>.Default;
		erfolgsMomente.Sort(basisVergleicher);
		LernMomenteAusgeben(erfolgsMomente);
	}

	static void LernMomenteAusgeben(IEnumerable<LernMoment> lernMomente)
	{
		foreach(var moment in lernMomente)
		{
			Console.WriteLine("LernMoment - {0}, ist erschienen am {1}", 
				moment.Name, moment.ErschienenAm);
		}		
	}
}
