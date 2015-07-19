# Lernmoment in CSharp - Predicate Delegate, wie du spezifische Abfragen in generischen Algorithmen verwendest

Vielleicht ist dir das Schlüsselwort `Predicate<T>` schon mal unter gekommen. Es handelt sich dabei um ein vordefiniertes Delegate, welches immer ein `bool` zurück gibt. Die genau Definition lautet wie folgt:

> Es handelt sich dabei um eine Methode, die einen Satz von Kriterien definiert und überprüft, ob das übergebene Objekt diese erfüllt.
> -- <cite>[MSDN](https://msdn.microsoft.com/de-de/library/bfcke1bz(v=VS.110).aspx)</cite>

Das `Prediacte<T>` wurde in C# 2.0 zusammen mit zusätzlichen Algorithmen der Klassen `Array` und `List<T>` eingeführt. Obwohl spätestens seit C# 4.0 hauptsächlich andere Konstrukte verwendet werden, ist `Predicate<T>` noch nicht (ganz) veraltet und wird auch in WPF vielfach verwendet. Grund genug, dass du weißt, wie du es verwendest.

Es handelt sich um ein ganz normales Delegate mit fest definiertem Rückgabewert und Parameter:

```c#
public delegate bool Predicate<in T>(T obj)
```

Du könntest zum Beispiel ein Predicate Delegate definieren welches untersucht, ob ein Objekt mehr als 500 Wörter hat. Dabei muss für folgendes Beispiel das Objekt vom Typ `LernMoment` sein und eine Eigenschaft mit dem Name `AnzahlWoerter` haben:

```c#
// folgende Liste sollte noch mit Werten gefüllt werden (siehe Quellcode zu diesem LernMoment)
var lernMomente = new List<LernMoment>();

// erstellen eines Predicate Delegates
Predicate<LernMoment> mehrAls500Woerter = (LernMoment lm) => { return lm.AnzahlWoerter > 500; };

// verwenden eines Predicate Delegate
var gefundenerLM = lernMomente.Find(mehrAls500Woerter);
```

Das Beispiel oben verwendet einen ganz normalen Lambda-Ausdruck und kann somit noch wesentlich kürzer geschrieben werden. Wichtig ist nur, dass dir klar ist, dass der Typ von `List<T>` und dem `Predicate<T>` übereinstimmen müssen. Besser gesagt, sie werden automatisch übereinstimmen, weil die `Find` Methode so lange Objekte aus der Liste in das Predicate Delegate steckt, bis es `true` zurück gibt.

Jetzt viel Spaß mit dem schreiben von Abfragen die du generischen Algorithmen übergeben kannst

Jan

## Merke

-	Predicate Delegates werden nur in einigen Bereichen von C# bzw. .NET verwendet. Insbesondere sind hier `Array`, `List<T>` und einige Klassen in WPF zu nennen.
-	Es handelt sich dabei um ein normales Delegate, welches als Rückgabewert `bool` hat und nur einen Parameter vom generischen Typ hat.
-	Du kannst Lambda-Ausdrücke, anonyme Methoden und auch normale Methoden als Predicate Delegate verwenden.
-	Das Predicate Delegate muss `true` zurück liefern, wenn seine Kriterien erfüllt sind.

## Lernquiz

Verwende folgende Fragen um das gelernte von heute zu festigen:

-	Was ist das besondere am Predicate Delegate im Vergleich zu "normalen" Delegates?
-	Von welchem Typ sind Objekte die Algorithmen einer `List<int>` in das Predicate Delegate geben?
-	Gibt es etwas zu beachten, wenn du einen Lambda-Ausdruck in einem Predicate Delegate verwendest?

Am besten du schaust dir morgen und dann nochmal in ein paar Tagen die vorherigen Fragen an und beantwortest sie ohne den Text vorher gelesen zu haben.

## Weitere Informationen

-	- Das komplette Beispielprogramm zu diesem LernMoment findest du [hier](https://github.com/LernMoment/csharp-fortgeschrittene/tree/master/PredicateDelegate)

