# Lernmoment in CSharp - Command.CanExecute, wie du mit 3 Schritten deinem Benutzer die Bedienung erleichterst

Egal welche, von den vielen Möglichkeiten zur Oberflächenerstellung in C# du verwendest, es ist immer wichtig, dass sie möglichst einfach für deinen Benutzer zu bedienen ist. Es macht also Sinn, Funktionen die gerade nicht verfügbar sind, auch gar nicht erst durch den Benutzer ausführen zu lassen.

Wenn du [WPF](https://msdn.microsoft.com/de-de/library/aa970268(v=vs.110).aspx) und den MVVM (Model-View-ViewModel) Ansatz verwendest, dann kann dir das `ICommand` Interface behilflich sein. In diesem Interface gibt es die `CanExecute` Methode.

Über diese Methode kann WPF heraus finden ob ein Kommando momentan ausgeführt werden kann oder nicht. Wenn du zum Beispiel etwas aus der Oberfläche heraus speichern möchtest, dieses aber länger dauert, könnte dein ViewModel ein asynchrones `SpeichernCommand` anbieten. 

In dessen `Execute` Methode definierst du was wie gespeichert werden soll. In der `CanExecute` Methode sagst du, dass `Execute` nicht nochmal aufgerufen werden sollte, so lange es läuft.

Die Syntax der `CanExecute` Methode im `ICommand` Interface ist so:

```lang:cs
bool CanExecute(Object parameter)
```

Wenn du die Methode implementierst, gibst du also immer ein bool zurück. Der Aufrufer will ja wissen ob das `ICommand` momentan ausgeführt werden kann oder nicht. Den `parameter` kannst du erstmal ignorieren. Bei Bedarf könntest du einen Parameter übergeben, aber das ist wieder ein neuer LernMoment.

Hier die 3 Schritte um ein Bedienelement zu aktivieren / deaktivieren je nachdem ob die Funktion gerade verfügbar ist, oder nicht:

1.	`ICommand` mit einer passenden `CanExecute` Methode implementieren:

```lang:cs
class SpeichernCommand : ICommand
{
    private bool istSpeichernAktiv = false;

    public bool CanExecute(object parameter)
    {
        // Das Kommando kann ausgeführt werden, wenn gerade nicht gespeichert wird.
        return istSpeichernAktiv == false;
    }

    // Execute Methode und CanExecuteChanged Event sind im Beispiel realisiert
}
```

2.	Das neu definierte Kommando im ViewModel verfügbar machen:

```lang:cs
private SpeichernCommand dateiSpeichernCommand = null;

public ICommand DateiSpeichernCommand
{
    get
    {
        if (dateiSpeichernCommand == null)
        {
            dateiSpeichernCommand = new SpeichernCommand();
        }

        return dateiSpeichernCommand;
   }
}
```

3.	Das Kommando und das Bedienelement verbinden

```lang:xml
<Button Content="Speichern" Command="{Binding DateiSpeichernCommand}" />
```

Der letzte Schritt in Kombination mit der Implementierung von `CanExecuteChanged` (siehe [Quellcode](#links)) sind die "Magie", die es WPF ermöglichen automatisch deine `CanExecute` Methode aufzurufen, wenn sich an der Oberfläche etwas ändert. Zu dieser Magie mehr in einem weiteren LernMoment.

Jetzt viel Spaß mit der Verbesserung deiner Oberfläche

Jan

## Merke

-	Bedienelemente die momentan nicht benutzt werden können, oder sollen, solltest du deaktivieren. So vereinfachst du die Bedienung der Oberfläche.
-	Achtung: sich ständig an und ausschaltende Bedienelemente können den Benutzer auch verwirren. Überleg dir also, ob das Verhalten für den Benutzer nachvollziehbar ist.
-	WPF nimmt dir den Großteil der Arbeit ab, wenn du `ICommand` verwendest.
-	Das Resultat der `CanExecute` Methode wird verwendet um die `IsEnabled` Eigenschaft vieler Bedienelemente zu setzen.
-	Kommandos immer wieder selber zu implementieren ist auf die Dauer zu kompliziert. Es gibt Alternativen [siehe unten](#links).

## Lernquiz

Verwende folgende Fragen um das gelernte von heute zu festigen:

-	Warum kann es Sinn machen Bedienelemente auszuschalten, wenn ihre Funktion aktuell nicht verfügbar ist?
-	Wie heißt das Interface und die für diese Funktion relevante Methode?
-	Was musst du tun damit ein Bedienelement dein Kommando im ViewModel verwendet und sich automatisch aktiviert/deaktiviert?

Am besten du schaust dir morgen und dann nochmal in ein paar Tagen die vorherigen Fragen an und beantwortest sie ohne den Text vorher gelesen zu haben.

## Weitere Informationen {#links}

-	Das komplette Beispielprogramm zu diesem LernMoment findest du [hier](tbd)
-	Um nicht immer `ICommand` implementieren zu müssen, kannst du eine Standardimplementierung mit Delegates oder ähnliches verwenden. Wie zum Beispiel das [RelayCommand](https://msdn.microsoft.com/en-us/magazine/dd419663.aspx). Leider gibt es keine gute Erklärung auf Deutsch.
-	Das [RoutedCommand](https://msdn.microsoft.com/de-de/library/system.windows.input.routedcommand(v=vs.110).aspx), welches direkt im Framework definiert ist, kannst du auch verwenden. Es ist allerdings etwas komplizierter. Dafür kann es auch mehr.
