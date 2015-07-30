using System;

class LernMoment { }
class LernMomentCSharp : LernMoment { }
class LernMomentC : LernMoment { }

/// <summary>
/// Dieser LernMoment C# führt dich in die Grundlagen von Kovarianz ein.
/// </summary>
class LernMoment_KovarianteFelder
{	
	static void Main()
	{
		LernMoment[] deineMomente = new LernMomentCSharp[10];

		for(int i=0; i < 10; i++)
		{
			deineMomente[i] = new LernMomentCSharp();
		}

		// C# und die CLR sehen das erstellen von Feldern als kovariante Aktion an.
		// Daher gibt es auch keinen Fehler oder Warnung bei folgender Zuweisung:
		//deineMomente[5] = new LernMomentC();

		// Das Problem ist nur, dass hinter deineMomente tatsächlich ein Feld vom Typ
		// LernMomentCSharp steht. Somit verstößt die obige Zuweisung gegen die Kovarianz.
		// Dies kann allerdings erst zur Laufzeit festgestellt werden. Daher gibt es
		// eine Exception, wenn du die obige Zeile in diesem Programm verwendest, anstatt
		// sie aus zu kommentieren.

		foreach(var lernMoment in deineMomente)
		{
			Console.WriteLine(lernMoment.ToString());
		}
	}
}
