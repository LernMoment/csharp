using System;
using System.Collections.Generic;

enum Tag
{
	Syntax = 0,
	File = 1,
	Delegate = 2,
	Serialisierung = 3,
	TPL = 4,
	Parallelisierung = 5
}

/// <summary>
/// Zeigt dir die wichtigsten Formatierungszeichenfolgen für Enums
/// </summary>
class LernMoment
{
	public LernMoment(string name, string author, DateTime veroeffentlicht, IEnumerable<Tag> zugewieseneTags)
	{
		this.Name = name;
		this.Author = author;
		this.VeroeffentlichtAm = veroeffentlicht;
		this.Tags = zugewieseneTags;
	}

	private List<Tag> tags;
	public IEnumerable<Tag> Tags
	{
		get { return tags; }
		private set { tags = new List<Tag>(value); }
	}

	public string Name { get; private set; }

	public DateTime VeroeffentlichtAm { get; private set; }

	public string Author { get; private set; }

	public static IEnumerable<LernMoment> ErstelleTestCollection()
	{
		var result = new List<LernMoment>();

		var ersterLernMoment = new LernMoment("Die Klasse File", 
												"Jan Suchotzki", 
												new DateTime(2015, 07, 26), 
												new Tag[]{Tag.Syntax, Tag.File});

		result.Add(ersterLernMoment);

		var zweiterLernMoment = new LernMoment("Von Prozessen zu Tasks", 
												"Jan Suchotzki", 
												new DateTime(2015, 08, 20), 
												new Tag[]{Tag.Syntax, Tag.TPL, Tag.Parallelisierung});

		result.Add(zweiterLernMoment);

		return result;
	}
}

class TabellarischeAusgabe
{
	static void Main()
	{
		IEnumerable<LernMoment> momente = LernMoment.ErstelleTestCollection();

		Console.WriteLine();
		KopfzeileAusgeben();
		foreach(LernMoment lm in momente)
		{
			LernMomentAusgeben(lm);
		}

		Console.WriteLine();
	}

	static void KopfzeileAusgeben()
	{
		Console.WriteLine("{0, -40}{1, -25}{2, -25}", "Name", "Veroeffentlicht am", "Tags");
		Console.WriteLine(string.Empty.PadLeft(90, '─'));
	}

	static void LernMomentAusgeben(LernMoment lm)
	{
		string tags = "{";
		foreach(var tag in lm.Tags)
		{
			tags += tag + ", ";
		}
		tags = tags.Remove(tags.LastIndexOf(','));
		tags += "}";

		Console.WriteLine("{0, -40}{1, -25:ddd dd MMMM yyyy}{2, -25}", lm.Name, lm.VeroeffentlichtAm, tags);
	}
}