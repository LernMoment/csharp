# Lernmoment in CSharp - XML Dokumentationskommentare, Tags die du für Intellisense verwenden solltest

Es gibt verschiedene Möglichkeiten wie du Dokumentationskommentare, also solche die mit `\\\ ` starten, verwenden kannst. Sicherlich eine der hilfreichsten ist, dass einige Informationen in Intellisense angezeigt werden. Welche Informationen angezeigt werden hängt davon ab, welche Tags du verwendest. Mehr als 3 der wichtigsten Tags brauchst du bezüglich Intellisense nicht. 

Den `<summary>` Tag kannst du an Typen, wie beispielsweise Klassen und Interfaces, und an ihren Membern verwenden. Dieser Tag ist gedacht um einen kurzen Überblick des Typen oder Members zu geben. Sowohl MonoDevelop wie auch VisualStudio verwenden die Informationen aus diesem Tag in ihrer Intellisense. Hier ein Beispiel anhand einer Klasse:

```c#
/// <summary>
/// Eine Beispielklasse um die veschiedenen Tags der Dokumentationskommentare
/// auszuprobieren.
/// </summary>
/// <remarks>
/// Weitere Informationen können in dem <c>remarks</c> Tag eingefügt werden.
/// Diese werden aber nicht per Intellisense angezeigt.
/// </remarks>
public class DocTagKlasse {}
```

Der zweite Tag heißt `<param>` und ist gedacht um Parameter in einem Konstruktor oder einer Methode zu beschreiben. Für jeden Parameter wird der Tag einmal verwendet. Er hat ein Attribut `name` welches den Parameternamen beinhaltet. Auch dieser Tag wird von Intellisense in MonoDevelop und VisualStudio gleich verwendet. Die Information aus diesem Tag sind allerdings kontextsensitiv. Sie wird dir also nur angezeigt, wenn du gerade dabei bist den Parametern eines Konstruktors oder einer Methode einen Wert zu übergeben.

Der letzte Tag den Intellisense verwendet ist `<typeparam>`. Diesen kannst du einsetzen, wenn dein Typ oder Methode einen generischen Parameter verwendet. Dabei gilt zu beachten, dass auch hier die Information aus dem Tag nur im passenden Kontext angezeigt wird. Ausserdem habe ich in der aktuellen Version von MonoDevelop diese Information nicht in der Intellisense gefunden. Es scheint also, als ob es nur von VisualStudio unterstützt wird. Hier ein Beispiel welches die beiden Tags für Parameter zeigt:

```c#
/// <summary>
/// Zeigt die Verwendung des <c>typeparam</c> Tags. Dieses ist der letzte der
/// 3 verfügbaren Tags die von Intellisense verwendet werden.
/// </summary>
/// <returns>Feld mit der <paramref name="anzahlElemente"/> - wird nicht von Intellisense angezeigt!</returns>
/// <param name="anzahlElemente">Anzahl elemente.</param>
/// <typeparam name="T">Auch der <c>typeparam</c> Tag wird von Intellisense angezeigt.</typeparam>
public static T[] erstelleGenerischesFeld<T>(int anzahlElemente) { }
```

Wie genau du Dokumentationskommentare einsetzt ist sicherlich von deinem Projekt abhängig. Gerade in Kombination mit Intellisense finde ich es auch für kleine Projekte hilfreich an denen nur ich selbst arbeite. Allerdings versuche ich für Typen und Member selbst erklärende Namen zu finden. Dann kann ich den Kommentar auch mal weglassen.

Jetzt viel Spaß mit dem sauberen kommentieren deiner Klassen

Jan

## Merke

-	Die jeweilige Information aus einigen Tags in den XML Dokumentationskommentaren wird von Intellisense verwendet.
-	Den `<summary>` Tag kannst du an allen Typen und Membern einsetzen.
-	Auch der `<param>` Tag wird von Intellisense unterstützt. Du verwendest für Parameter in Konstruktoren und Methoden.
-	Der `<typeparam>` Tag ist für generische Typen gedacht. Er wird momentan nicht von Intellisense in MonoDevelop unterstützt.
-	Wenn du aussagekräftige Namen verwendest, kannst du dir den ein oder anderen Kommentar ersparen.

## Lernquiz

Verwende folgende Fragen um das gelernte von heute zu festigen:

-	Wie leitest du einen XML Dokumentationskommentar (unabhängig vom verwendeten Tag) ein?
-	Welche beiden Tags werden von Intellisense in VisualStudio und MonoDevelop verwendet?
-	Wie ist die genau Syntax um den Parameter `anzahl` einer Methode zu dokumentieren?

Am besten du schaust dir morgen und dann nochmal in ein paar Tagen die vorherigen Fragen an und beantwortest sie ohne den Text vorher gelesen zu haben.

## Weitere Informationen

-	Das komplette Beispielprogramm zu diesem LernMoment findest du [hier](https://github.com/LernMoment/csharp-fortgeschrittene/tree/master/DocTags)
-	Eine Beschreibung der anderen Tags die noch zur Verfügung stehen findest du [hier](https://msdn.microsoft.com/de-de/library/5ast78ax(v=vs.120).aspx)
