# Lernmoment in C# - `var` Schlüsselwort, Beispiele für und wider impliziert typisierte lokale Variablen

Wenn ich bisher in einem Quellcode die Verwendung von `var` gesehen habe, dann konnte ich immer ein leichtes Unbehagen verspühren. Das liegt vielleicht daran, dass mir bisher noch nicht wirklich klar war, was die Verwendung des Schlüsselwortes bedeutet. Irgendwie hatte ich wohl den Eindruck, dass damit die Typisierung aufgehoben wird. Aber:

> Das var-Schlüsselwort weist den Compiler an, den Typ der Variable aus dem Ausdruck an der rechten Seite der Initialisierungsanweisung abzuleiten.
> -- <cite>[MSDN](https://msdn.microsoft.com/de-de/library/bb384061.aspx)</cite>

Wie du siehst, geht es nicht darum, die Typisierung aufzuheben. Vielmehr überlässt du es dem Compiler den besten Typ auszuwählen. Dies ist ein klarer Unterschied zu beispielsweise JavaScript! Nun aber zu den Beispielen.

Gerade bei anonymen Typen und LINQ-Abfragen kommst du ohne `var` nicht wirklich gut zurecht (dazu mehr in späteren LernMomenten). Ob du deren Einsatz brauchst oder für sinnvoll erachtest, bleibt dir überlassen. Hier noch Quellcode den ich in diesem Kontext interessant finde:

```lang:c#
// mit var - ohne Wissen von LINQ und anonymen Typen kann ich nicht erklären
// wie genau die Abfrage funktioniert.
// Allerdings kann ich erahnen, dass Name und Alter aller Kunden abgefragt wird.
var query = from c in customers select new {c.Name, c.Age};

// eine Möglichkeit ohne var - hier kann ich weder sagen, was passiert, noch wie
// es passiert. Für mich die schlechtere Variante.
IEnumerable<NameAndAge> query 
      = Enumerable.Select<Customers, NameAndAge>(customers, NameAndAgeExtractor);
```

Einen weiteren vermeintlichen Vorteil zeigt folgendes Beispiel:

```lang:c#
var resultat = apfel.VergleicheMit(birne);
Console.WriteLine("Apfel hat folgende Unterschiede zu Birne: " + resultat.ToString());
```

Wenn die Methode `VergleicheMit` ihren Rückgabewert ändert, z.B. durch ein Refactoring, brauchst du den aufrufenden Code nicht zu ändern. Für mich ist das kein gutes Beispiel für die Verwendung von `var`, weil ich es bevorzuge diese Stellen anzuschauen. Vielleicht macht die Ausgabe des neuen Rückgabetyps gar keinen Sinn mehr. Da finde ich es besser, dass der Compiler mir sagt, dass die Typen nicht zusammen passen und ich die Stellen von Hand ändere. Das ist natürlich zusätzlicher Aufwand.

Ein wichtiger Fall in dem die Verwendung von `var` wirklich Sinn macht, ist die Reduzierung von Redundanz. Schau dir folgendes Beispiel an:

```lang:c#
//explizite Definition ohne var
Dictionary<string, List<decimal>> rabatteProKunde = new Dictionary<string, List<decimal>>();

//implizite Definition mit var
var rabatteProKunde = new Dictionary<string, List<decimal>>();
```

Die Version ohne `var` bringt keinerlei zusätzliche Information oder Nutzen. Also verwende ich zukünftig `var` in solchen Fällen. Mit Ausnahme von anonymen Typen und LINQ, scheint mir Lesbarkeit das entscheidende Kriterium für die Verwendung von `var` zu sein. Du kannst mit diesem Schlüsselwort die Lesbarkeit sowohl positiv wie auch negativ beeinflussen.

Jetzt erstmal viel Spaß beim reflektieren wie du `var` besser einsetzen kannst als bisher.

Jan

## Merke
Die folgenden Punkte basieren auf dem [hervorragenden Artikel](http://blogs.msdn.com/b/ericlippert/archive/2011/04/20/uses-and-misuses-of-implicit-typing.aspx) von Eric Lippert: 

- Verwende `var`, wenn du anonyme Typen verwendest.
- Vermeide Redundanz und verwende `var`, wenn der Typ offensichtlich von der Initialisierung ist.
- Überlege ob du `var` verwendest, wenn der daraus entstehende Quellcode das "Was" in den Fokus setzt und das "Wie" verbirgt.
- Verwende *immer* beschreibende Variablennamen, egal ob due `var` einsetzt oder nicht. `zinssatz` ist besser als `dezimalWert`.

## Lernquiz

-	Legst du mit `var` eine nicht typisierte Variable an?
- Wie wird der Datentyp für eine mit `var` definierte Variable ermittelt?
- Welchen Einfluss hat `var` auf die Lesbarkeit des Quellcodes?
- Gibt es Fälle in denen du `var` verwenden musst?

Am besten du schaust dir morgen und dann nochmal in ein paar Tagen die vorherigen Fragen an und beantwortest sie ohne den Text vorher gelesen zu haben.

## Weitere Informationen

-	Zu diesem LernMoment gibt es keinen zusätzlichen Quellcode.
- Eine Einführung und (teilweise etwas komische) Beispiele findest du bei [MSDN](https://msdn.microsoft.com/de-de/library/bb384061.aspx)
- Eine super Erklärung, allerdings nur auf Englisch, gibt der [Artikel von Eric Lippert](http://blogs.msdn.com/b/ericlippert/archive/2011/04/20/uses-and-misuses-of-implicit-typing.aspx).
