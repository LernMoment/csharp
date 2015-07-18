# Lernmoment in CSharp - Lambda Ausdrücke erstellen, 

Lambda Ausdrücke bieten dir die Möglichkeit Anonyme Methoden und Delegates in einer sehr kurzen Schreibweise zu erstellen. Ich finde diese Schreibweise etwas gewöhnungsbedürftig. Da sie aber eine sehr ausdrucksstarke Möglichkeit bietet kurze Methoden zu erstellen (z.B. als Prädikate oder für die asynchrone Ausführung) und sie insbesondere für LINQ intensiv benutzt wird, solltest du ihre Syntax beherrschen.

Die Basis der Lambda Ausdrücke ist der `=>` Operator. Dieser Operator wird auch Lambda-Operator genannt. Hier ein Beispiel (das komplette und lauffähige Beispiel findest du [hier](tbd)):

```c#
// Deklariere ein Delegate
delegate int RechenOperation(int a, int b);

// verwende Lambda um dem delegate eine Anonyme Methode zuzuweisen.
RechenOperation multipliziere = (x, y) => x * y;

// rufe das delegate auf, um es auszuprobieren
int resultat = multipliziere(4, 5);
```

Der im Beispiel verwendete Lambda Ausdruck ist folgender:

```c#
(x, y) => x * y;
```

Wie du siehst gibt es links vom Lambda-Operator die Parameterliste. In ihr deklarierst du welche Parameter übergeben werden sollen. Da die Parameter in diesem Fall ohne Datentypen deklariert sind, verwendet C# implizit typisierte Datentypen. Je nachdem in welchem Kontext der Lambda-Ausdruck verwendet wird, versucht C# den richtigen Datentypen zu ermitteln. Du kannst auch explizit Datentypen angeben. Dann sieht das Beispiel von oben so aus:

```c#
(int x, int y) => x * y;
```

Weiterhin ist für Lambda-Ausdrücke definiert, dass wenn rechts vom Lambda-Operator nur eine `return` Anweisung steht, die geschweiften Klammern und das `return` weggelassen werden können. Der vorherige Lambda-Ausdruck ist also eine verkürzte Form von:

```c#
(int x, int y) => { return x * y; }
```

Willst du einen Lambda-Ausdruck erstellen der mehrere Anweisungen enthält, dann sind die geschweiften Klammern absolut notwendig.

Wenn dein Lambda-Ausdruck nur einen Parameter benötigt, kannst du sogar noch die runden Klammern weglassen. Anders ist es, wenn du gar keinen Parameter benötigst, dann sind die runden Klammern Pflicht:

```c#
// Lambda mit nur einem Parameter
x => x * x;

// Lambda ohne Parameter
() => 4 * 5;
```

Jetzt viel Spaß mit der Erkundung kleinsten Methoden

Jan

## Merke

-	`=>` ist der Lambda-Operator.
-   Die Anweisungen die ausgeführt werden sollen, stehen rechts bom Lambda-Operator in geschweiften Klammern.
-   Verwendest du keinen oder mehr als einen Parameter, dann brauchst du links vom Lambda-Operator runde Klammern.
-   Die Parameter für einen Lambda-AusDruck können explizit oder implizit typisiert sein.
-   Wenn dein Lambda-Ausdruck nur aus einem `return` Ausdruck besteht, kannst du die geschweiften Klammern wie auch das `return` weglassen.

## Lernquiz

Verwende folgende Fragen um das gelernte von heute zu festigen:

-	Wie ist der kürzeste Lambda-Ausdruck um zwei Zahlen (egal welcher Datentyp) zu multiplizieren?
-   Was musst du bei einem Lambda-Ausdruck ohne Parameter beachten?
-   Was brauchst du rechts vom Lambda-Operator, wenn du mehrere Anweisungen hast?

Am besten du schaust dir morgen und dann nochmal in ein paar Tagen die vorherigen Fragen an und beantwortest sie ohne den Text vorher gelesen zu haben.

## Weitere Informationen

-	- Das komplette Beispielprogramm zu diesem LernMoment findest du [hier](https://github.com/LernMoment/csharp-fortgeschrittene/tree/master/LambdaErstellen)

