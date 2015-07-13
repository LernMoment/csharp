using System;

// Deklarieren eines Delegates
delegate void ZeilenDrucker(string s);

class LernMoment
{
    static void Main()
    {
    	int zeilennummer = 0;

        // Instanz des Delegates erstellen mit einer Anonymen Methode
        ZeilenDrucker druckZeile = delegate (string text)
        {
            zeilennummer++;
            Console.WriteLine(zeilennummer + ": " + text);
        };

        // Parameter einer anonymen Methode können nur innerhalb der anonymen
        // Methode verwendet werden. Versuch mal das Programm zu kompilieren,
        // nachdem du die Kommentarzeichen an der folgenden Zeile gelöscht
        // hast:
        // Console.WriteLine(text);

        // Den Delegate mit anonymer Methode aufrufen
        druckZeile("Hallo Anonyme Methoden!");
        druckZeile("Alternativ: Moin Anonyme Methoden!");
    }
}