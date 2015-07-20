using System;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// Zeigt, wie du einfach Dateien liest und beschreibst
/// </summary>
class LernMoment
{
	static void Main()
	{
		var tageMitLernMomenten = FindeTageMitLernMomentenIn(07, 2015);
		string dateiName = "LernMomente-im-Juli-2015.txt";

		// erstellt die Datei oder überschreibt sie, wenn sie bereits existiert!
		File.WriteAllLines(dateiName, tageMitLernMomenten);

		Console.WriteLine("Folgende Zeilen wurden aus der Datei {0} gelesen.", dateiName);
		foreach(string zeile in File.ReadLines(dateiName))
		{
			Console.WriteLine(zeile);
		}
	}

	static IEnumerable<string> FindeTageMitLernMomentenIn(int monat, int jahr)
	{
		var tageMitLernMomen = new List<string>();
		DateTime ersterTag = new DateTime(jahr, monat, 1);
		int anzahlTageImMonate = DateTime.DaysInMonth(jahr, monat);

		for(int i=0; i < anzahlTageImMonate; i++)
		{
			DateTime tag = ersterTag.AddDays(i);

			// LernMomente erscheinen nur an Werktagen 
			if( (tag.DayOfWeek != DayOfWeek.Sunday) 
				&& (tag.DayOfWeek != DayOfWeek.Saturday) )
			{
				tageMitLernMomen.Add(tag.ToLongDateString());
			}
		}

		return tageMitLernMomen;
	}
}
