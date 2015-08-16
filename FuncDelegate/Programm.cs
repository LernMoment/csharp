using System;
using System.Collections.Generic;
using System.Linq;

class LernMoment
{
	public LernMoment(string name, DateTime erschienenAm)
	{
		Name = name;
		ErschienenAm = erschienenAm;
	}

	public string Name { get; private set; }
	public DateTime ErschienenAm { get; private set; }
}

/// <summary>
/// Zeigt dir wie du einen der vordefinierten Func-Delegates verwendest
/// </summary>
class Programm
{
	static void Main()
	{
		var erfolgsMomente 
			= new List<LernMoment> {new LernMoment("Func", new DateTime(2015, 08, 17)),
									new LernMoment("Var", new DateTime(2015, 07, 26)),
									new LernMoment("Lambda", new DateTime(2015, 07, 29)),
									new LernMoment("Predicate", new DateTime(2015, 07, 31))};

		Func<LernMoment, bool> momentImAugust = moment => moment.ErschienenAm.Month == 8;

		foreach(LernMoment moment in erfolgsMomente.Where(momentImAugust))
		{
			Console.WriteLine("LernMoment - {0}, ist erschienen am {1}", 
				moment.Name, moment.ErschienenAm);
		}
	}
}
