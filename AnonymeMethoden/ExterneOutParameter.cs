using System;

// Deklarieren eines Delegates
delegate string Generator();

class LernMoment
{
    static void Main()
    {
        string generierterText;

        Erzeuger(out generierterText);

        Console.WriteLine(generierterText);
    }

    static void Erzeuger(out string text)
    {
        Generator g = delegate ()
        {
            // in einer anonymen Methode kann nicht auf externe out oder ref 
            // Parameter zugegriffen werden. Versuch mal diese Zeile anstelle
            // der return Anweisung:
            // text = "Ein erzeugter Text!";
            return "Ein erzeugter Text!";
        };

        text = g();
    }
}