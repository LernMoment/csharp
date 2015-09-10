using System;
using System.Collections.Generic;

/// <summary>
/// Klasse die teilweise mit einem Object Initializer initialisiert werden kann.
/// </summary>
public class LernMoment
{
	public string EmailAuthor;

	public string Name {get; private set;}

	public List<string> tags;

	public LernMoment(string name)
	{
		Name = name;
	}

	public override string ToString()
	{
		string strOut = string.Format("LernMoment: {0,-20} | Author: {1, -20} | Tags: ", Name, EmailAuthor);
		foreach(var tag in tags)
		{
			strOut += tag + ", ";
		}
		strOut = strOut.Remove(strOut.LastIndexOf(','));
		return strOut;
	}
}

/// <summary>
/// Zeigt dir wie du Object Initializer verwendest.
/// </summary>
class BeispielObjectInitializer
{
	static void Main()
	{
		var meinLernMoment = new LernMoment("Object Initializer")
		{
			EmailAuthor = "jan@lernmoment.de",
			tags = new List<string> {"Syntax", "Initialisierung"}
		};

		Console.WriteLine(meinLernMoment);
	}
}
