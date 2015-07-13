# Lernmoment in CSharp - Anonyme Methoden, vereinfache deinen Quellcode mit etwas unbekanntem

Bestimmt hast du anonyme Methoden schon einmal verwendet. Als Bestandteil von Lambda-Ausdrücken oder der Definition von Delegates machen sie sich gut.

Eine anonyme Methode heißt anonym, weil sie keinen Namen hat. In folgendem Beispiel wird eine anonyme Methode verwendet um das Delegate "ZeilenDrucker" zu definieren:

```lang:c#
// Deklarieren des Delegates
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

        // Den Delegate mit anonymer Methode aufrufen
        druckZeile("Hallo Anonyme Methoden!");
        druckZeile("Alternativ: Moin Anonyme Methoden!");
    }
}
```

Eine anonyme Methode besteht aus einer optionalen Parameterliste, einem Methodenrumpf und einem abschließenden Semikolon. Dabei wird der Methodenrumpf einfach innerhalb eines anderen Methodenrumpfs definiert. Deshalb braucht es auch das Semikolon um den Rumpf der anonymen Methode zu beenden.

Wichtig ist, dass die anonyme Methode und das Delegate separat zusehen sind. Wie du siehst, wird das Delegate mit einem string-Parameter `s` definiert. Die anonyme Methode verwendet aber einen anderen Parameternamen, nämlich `text`. Trotzdem kann die anonyme Methode dem Delegate einfach zugewiesen werden.

Es gibt noch ein paar weitere Besonderheiten, die du kennen solltest:

-	Variablen und Parameter die in der Methode außerhalb der anonymen Methode definiert sind, sind auch innerhalb der anonymen Methode sichtbar. Das siehst du im Beispiel bei der lokalen Variable `zeilennummer`.
-	Zu dem vorherigen, gibt es die Ausnahme, dass `ref` und `out` Parameter von außerhalb nicht in einer anonymen Methode verwendet werden können. Dazu gibt es noch ein weiteres Beispiel (siehe unten).
-	Parameter die in der Parameterliste der anonymen Methode definiert sind, können nicht außerhalb der anonymen Methode verwendet werden. Dies macht auch irgendwie nicht so wirklich Sinn, oder?
-	Es gibt einen Weg, wie anonyme Methoden direkt ausgeführt werden können. Dies macht allerdings wenig Sinn. Daher werden anonyme Methoden eigentlich immer übergeben bzw. als Delegate ausgeführt.

Weitere Besonderheiten bei den anonymen Methoden folgen in einem späteren LernMoment. Jetzt erstmal viel Spaß mit Methoden ohne Namen

Jan

## Merke

-	Anonyme Methoden sind gut für kurze Funktionen, die du sofort verwenden möchtest.
-	Typische Anwendungen sind die Übergabe einer anonymen Methode an einen `Task` (z.B. Task Parallel Library) oder als `Predicate` (z.B. in der statischen `Find<T>` Methode).
-	Sie haben keinen Namen und werden immer sofort definiert. Es gibt also keine Deklaration.
-	Du kannst sowohl einen Rückgabewert verwenden wie auch eine Parameterliste.
-	Die anonyme Methode kann auf Variablen und Parameter außerhalb ihres Kontext zugreifen.

## Lernquiz
Verwende folgende Fragen um das gelernte von heute zu festigen:

-	Wo definierst du eine anonyme Methode?
-	Wie wird die Definition abgeschlossen?
-	Wie werden anonyme Methoden ausgeführt?
-	Auf welche Parameter und Variablen kannst du innerhalb des Rumpfes einer anonymen Methode zugreifen?

Am besten du schaust dir morgen und dann nochmal in ein paar Tagen die vorherigen Fragen an und beantwortest sie ohne den Text vorher gelesen zu haben.

## Weitere Informationen

-	Den kompletten Quellcode zum heutigen Lernmoment findest du [hier](tbd).
-	Weitere Beispiele und Erklärungen findest du [hier](https://msdn.microsoft.com/de-de/library/0yw3tz5k.aspx).

