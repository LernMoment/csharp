using System;

namespace LernMoment.DocTag
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			DocTagKlasse test = new DocTagKlasse ("Tags für XML Dokumentationskommentare");
			test.LernMoment = "DocTag";
			var feld = DocTagKlasse.erstelleGenerischesFeld<string> (10);
            int[] anderesFeld = DocTagKlasse.erstelleGenerischesFeld<int>(5);

			Console.WriteLine ("Dieses Programm zeigt die Verwendung von Dokumentationskommentaren in einer IDE!");
			Console.ReadLine ();
		}
	}
}
