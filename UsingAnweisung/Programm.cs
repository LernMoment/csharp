using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Beispiel zeigt ...
/// </summary>
class LernMoment
{
	static void Main()
	{
		Console.WriteLine("Erstelle zwei Dateien!");

		using (StreamWriter logWriter = new StreamWriter("LernMomentLog.txt"),
					textWriter = new StreamWriter("LernMoment.txt")) 
		{
			logWriter.WriteLine("LernMoment wurde erstellt!");
			textWriter.WriteLine("Hier ist der tolle LernMoment!");
		}

		Task dateiTask = DateiLesenUndAusgeben("LernMomentLog.txt");
		
		while(!dateiTask.IsCompleted)
    	{
    		Console.Write(";o ");
    		Thread.Sleep(10);
    	}
	}

	static async Task DateiLesenUndAusgeben(string dateiName)
	{
		Console.WriteLine("Beginne mit asynchronem Lesen von Datei: {0}", dateiName);

		using (var reader = new StreamReader(dateiName))
		{
			string result;
			while ((result = await reader.ReadLineAsync()) != null)
			{
				Console.WriteLine(result);
			}
		}
	}
}
