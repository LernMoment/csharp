using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

class Program {
  static void Main() {
  	Task webTask = GetWebContentAsync();

  	while(!webTask.IsCompleted)
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
