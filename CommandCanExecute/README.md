# Lernmoment in CSharp - Command.CanExecute, wie du mit 3 Schritten deinem Benutzer die Bedienung erleichterst

Egal welche, von den vielen Möglichkeiten zur Oberflächenerstellung in C# du verwendest, es ist immer wichtig, dass sie möglichst einfach für deinen Benutzer zu bedienen ist. Es macht also Sinn, Funktionen die gerade nicht verfügbar sind, auch gar nicht erst durch den Benutzer ausführen zu lassen.

Wenn du [WPF](https://msdn.microsoft.com/de-de/library/aa970268(v=vs.110).aspx) und den MVVM (Model-View-ViewModel) Ansatz verwendest, dann kann dir das `ICommand` Interface behilflich sein. In diesem Interface gibt es die `CanExecute` Methode und das `CanExecuteChanged` Event.

Diese beiden sind für dich der richtige Ansatzpunkt, wenn du zum Beispiel einen Button deaktivieren willst während eine Berechnung, ein Dateizugriff, oder eine andere längere Aktion ausgeführt wird. Folgend findest du die 3 Schritte, um genau solch ein Beispiel zu realisieren.

### Schritt 1 - Command im ViewModel erstellen

Es gibt verschiedene Möglichkeiten, wie du das `ICommand` Interface implementierst. Du könntest das `RoutedCommand` verwenden, deine eigene Implementierung oder eine von vielen Beispielimplementierungen im Netz. Mit dem letzteren Ansatz habe ich das Beispiel für diesen LernMoment realisiert.

```lang:c#
private RelayCommand dateiSpeichernCommand = null;

public ICommand DateiSpeichernCommand
{
    get
    {
        return dateiSpeichernCommand;
    }
}
```

Es macht allerdings keinen Sinn `null` zurückzugeben. Das wirst du in Schritt 2 ändern.

### Schritt 2 - Deine `CanExecute` Methode dem Command übergeben

Dem `RelayCommand` kannst du neben der eigentlichen Aktion die ausgeführt werden soll auch ein Methode übergeben, welche ausgeführt wird, wenn überprüft wird ob das `Command` momentan ausgeführt werden kann. Sofern deine Implementierung von `ICommand` den `CommandManager` verwendet, wird WPF unter bestimmten Bedingungen die Methode automatisch aufrufen. Dies kann relative häufig geschehen.

Du könntest deine `CanExecute` Methode zum Beispiel so übergeben:

```lang:c#
private RelayCommand dateiSpeichernCommand = null;
private bool istSpeichernAktiv = false;

public ICommand DateiSpeichernCommand
{
    get
    {
        if (dateiSpeichernCommand == null)
        {
            dateiSpeichernCommand = new RelayCommand(() => this.Speichern(), () => istSpeichernAktiv == false);
        }

        return dateiSpeichernCommand;
    }
}

private void Speichern()
{
    istSpeichernAktiv = true;
    MessageBox.Show("Speichere jetzt!");
    istSpeichernAktiv = false;
}
```

Die `CanExecute` Methode kann sehr einfach sein. In diesem Beispiel ist es nur der Vergleich einer Variablen mit einer Konstanten. Nachdem die Variable (`istSpeichernAktiv`) vor dem eigentlichen Speichern gesetzt und dannach zurück gesetzt wird, gibt `CanExecute` in dieser Zeit an, dass das `DateiSpeichernCommand` nicht ausgeführt werden kann.

Warum wird nun aber der Button in dieser Zeit deaktiviert? Das folgt im dritten und letzten Schritt.

### Schritt 3 - Den Button mit deinem Command verbinden

Nachdem du das `DateiSpeichernCommand` nun komplett im `MainViewModel` aufgesetzt hast, brauchst du nur noch WPF mitteilen, dass dein Button dieses `Command` benutzen soll. Das machst du im XAML des Views, der zu deinem ViewModel gehört:

```lang:xaml
<Button Content="Speichern" Command="{Binding DateiSpeichernCommand}"/>
```

Beim Aufbau des Views wird WPF den Button nun mit deinem `DateiSpeichernCommand` verknüpfen. Das hat zur Folge, dass der Button einen EventHandler auf dem `CanExecuteChanged` Event registriert. Immer wenn dieses Event ausgelöst wird, dann ruft der Button die `CanExecute` Methode auf und setzt seine `IsEnabled` Eigenschaft entsprechend.

Jetzt viel Spaß mit der Verbesserung deiner Oberfläche

Jan

## Merke

-	Controls die momentan nicht vom Benutzer benutzt werden können, oder sollen, solltest du deaktivieren. So vereinfachst du die Bedienung der Oberfläche.
-	Achtung: sich ständig an und ausschaltende Controls können den Benutzer auch verwirren. Überleg dir also, ob das Verhalten für den Benutzer nachvollziehbar ist.
-	WPF nimmt dir den Großteil der Arbeit ab, wenn du `ICommand` verwendest.
-	Das Resultat der `CanExecute` Methode wird verwendet um die `IsEnabled` Eigenschaft vieler Controls zu setzen.
-	Damit die WPF-Magie funktioniert, musst deine Implementierung vom `ICommand.CanExecuteChanged` Event, die ihm übergebenen EventHandler an `CommandManager.RequerySuggested` weiterleiten. Sonst wird dein `CanExecute` nicht automatisch aufgerufen.

## Lernquiz

Verwende folgende Fragen um das gelernte von heute zu festigen:

-	Warum kann es Sinn machen Controls auszuschalten, wenn ihre Funktion aktuell nicht verfügbar ist?
-	Wie heißt das Interface und die für diese Funktion relevante Methode?
-	Was musst du tun um ein Kommando im ViewModel mit einem Control im View zu verbinden?

Am besten du schaust dir morgen und dann nochmal in ein paar Tagen die vorherigen Fragen an und beantwortest sie ohne den Text vorher gelesen zu haben.

## Weitere Informationen

-	Das komplette Beispielprogramm zu diesem LernMoment findest du [hier](tbd)
