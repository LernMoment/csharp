using System;

public delegate void DeinDelegate();

class Program {
  static void Main() {
    DeinDelegate combine = (DeinDelegate)Delegate.Combine(new DeinDelegate(StarteErstenSchritt), 
                                             new DeinDelegate(StarteZweitenSchritt));

    DeinDelegate plusGleich = StarteErstenSchritt;
    plusGleich += StarteZweitenSchritt;

    DeinDelegate vertauscht = new DeinDelegate(StarteZweitenSchritt) + new DeinDelegate(StarteErstenSchritt);

    // Multicast-Delegaten ausführen

    Console.WriteLine();
    Console.WriteLine("Ein Multicast Delegate erzeugt mit Delegate.Combine Methode:");
    combine();

    Console.WriteLine();
    Console.WriteLine("Ein Multicast Delegate erzeugt mit += Operator:");
    plusGleich();

    Console.WriteLine();
    Console.WriteLine("Ein Multicast Delegate wird in der Reihenfolge ausgeführt, in der die Delegates hinzugefuegt wurden.");
    Console.WriteLine("Hier also mal eine vertauschte Reihenfolge:");
    vertauscht();

    Console.ReadLine();
  }

  public static void StarteErstenSchritt() {
    Console.WriteLine("Es wird gerade der ERSTE Schritt ausgefuehrt.");
  }

  public static void StarteZweitenSchritt() {
    Console.WriteLine("Es folgt nun der ZWEITE Schritt.");
  }
}
