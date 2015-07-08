#Lernmoment in C# - Async StreamReader, mach doch was anderes während ich lese

Heute bin ich zufällig über die Klasse `StreamReader` gestolpert. Du hast sie vielleicht schon mal zum lesen aus Dateien oder ähnliches benutzt. Ich habe sie vielleicht auch schon mal benutzt, aber konnte mich nicht erinnern. Was mich allerdings wirklich beeindruckt hat, sind die neuen Async-Methoden.

Seit mittlerweile 3 Jahren gibt es .NET 4.5. In dieser Version wurden die Schlüsselwörter `async / await` eingeführt. Sie sollen eine sehr einfache Methode zur asynchronen Programmierung bereitstellen.

Auch die Klasse `StreamReader` wurde erweitert um dieses neue Konzept zu unterstützen. Insgesamt wurden 4 zusätzliche Async-Methoden hinzugefügt. Die Methode `ReadLineAsync` will ich dir heute in einem Beispiel vorstellen:

```c#
static async Task GetWebContentAsync()
{
  WebClient myClient = new WebClient();
  Stream response = myClient.OpenRead("http://www.contoso.com/index.htm");
  
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
```

Wie du siehst habe ich hier eine einfache Abfrage einer Webseite gemacht. Das wirklich spannende passiert dabei im Kopf der `while` Schleife. Dort siehst du den Aufruf der `ReadLineAsync` Methode mit einem vorangestelltem `await`.

Genau an dieser Stelle passiert einiges an Magie bzw. der Compiler macht einiges was du bisher machen musstest. Durch das `await` wird die Methode `GetWebContentAsync` unterbrochen, bis `ReadLineAsync` den String von der Webseite geholt hat. 

Jetzt erstmal viel Spaß beim kombinieren und delegieren.

Jan

**Merke:**

-	

**Lernquiz:** Verwende folgende Fragen um das gelernte von heute zu festigen:

-	

Am besten du schaust dir morgen und dann nochmal in ein paar Tagen die vorherigen Fragen an und beantwortest sie ohne den Text vorher gelesen zu haben.

**Weitere Informationen:**

-	Den kompletten Quellcode zum heutigen Lernmoment findest du [hier](https://github.com/LernMoment/csharp-fortgeschrittene/tree/master/MulticastDelegateErstellen).
-	
