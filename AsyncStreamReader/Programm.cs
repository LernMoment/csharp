using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

class Program {
  static void Main() {
  	// um einen Task abbrechen zu können, brauchst du einen Token
  	CancellationTokenSource cTokenSource = new CancellationTokenSource();
  	CancellationToken cToken = cTokenSource.Token;

  	// nun startest du die Tasks. Den den du abbrechen willst, gibst du den Token mit
  	Task webTask = GetWebContentAsync();
  	Task indicateProgressTask = Task.Run(() => IndicateProgress(cToken), cToken);

  	// hier wartest du, bis der arbeitende Task fertig ist und dann wird der progress Task 
  	// abgebrochen
  	webTask.Wait();
  	cTokenSource.Cancel();

  	// Schließlich wartest du noch, dass auch der progress Task beendet ist.
  	indicateProgressTask.Wait();
  }

  static void IndicateProgress(CancellationToken ct)
  {
  	while(!ct.IsCancellationRequested)
  	{
  		Console.Write(";o ");
  		Thread.Sleep(100);
  	}

  	Console.WriteLine("FERTIG!");
  }

  static async Task GetWebContentAsync()
  {
	WebClient myClient = new WebClient();
	Stream response = await myClient.OpenReadTaskAsync("http://www.contoso.com/index.htm");
	
	using (var reader = new StreamReader(response))
	{
		string line;
		while((line = await reader.ReadLineAsync()) != null)
        {
        	Console.WriteLine();
            Console.WriteLine(line);
        }

        reader.Close();
    }

	response.Close();
  }

}
