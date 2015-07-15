# Lernmoment in CSharp - NuGet Pakete restaurieren, wie du automatisch fehlende Pakete laden lässt

Mit [NuGet](http://www.nuget.org) kannst du sehr einfach zusätzliche Bibliotheken in dein Entwicklungsprojekt integrieren. Dabei ist es sogar egal, ob du Visual Studio oder MonoDevelop verwendest. Für die Funktion "Package Restore" kommst du sogar ohne Entwicklungsumgebung aus. Du brauchst lediglich die `nuget.exe` für die Kommandozeile.

Wenn du externe Bibliotheken (z.B. [NUnit](http://nunit.org) zum testen oder [WiX Toolset](http://wixtoolset.org) zum erstellen von MSIs) in deinem C#-Projekt verwendest, dann hast du dir vielleicht schon mal die Frage gestellt was mache ich mit den Assemblies.

Diese Frage stellt sich eher nicht, wenn du alleine immer auf einem Rechner entwickelst, aber wenn du einen weiteren Rechner oder gar viele Kollegen hast, dann solltest du darüber nachdenken. Die Assemblies dieser Bibliotheken lokal auf allen Rechnern von Hand zu installieren ist nicht so sinnvoll. Was machst du zum Beispiel, wenn du eine neuere Version verwenden willst?

NuGet kommt dir zur Hilfe. Hast du einmal eine externe Bibliothek (in NuGet-Sprache handelt es sich dabei um ein Paket) in dein Visual Studio / MonoDevelop Projekt integriert, wirst du ein oder mehrere `packages.config` Dateien in deinem Projekt finden. Diese zeigen NuGet welche Pakete in welchen Versionen dein Projekt verwendet.

Diese Dateien sind auch alles was du in deine Versionsverwaltung zusammen mit dem Quellcode legen musst. Sämtliche Assemblies und was sonst noch zu dem von dir verwendeten Paket gehört, wird automatisch bei jedem Build in Visual Studio (bzw. beim öffnen des Projekts in MonoDevelop) durch NuGet geladen. Wenn du also einmal deine Pakete konfiguriert hast, werden sie automatisch auf jedem anderen Rechner geladen, wenn sie nicht vorhanden sind. 

Dabei wird auch auf die Versionsnummern geachtet. Wenn dein Kollege also eine andere Version von NUnit bereits verwendet, dann wird trotzdem die passende geladen, wenn er dein Projekt das erstemal öffnet bzw. übersetzt.

Wenn dein Projekt gültige `packages.config` enthält, dann kannst du auch per Kommandozeile die Pakete laden lassen. Dafür muss `nuget.exe` im Pfad sein. Dann brauchst du nur `nuget.exe restore` im root-Verzeichnis deines Projekts / Solution aufrufen. Nun werden die benötigt Pakete geladen. Dies kann wichtig sein, weil weder XBuild noch MSBuild das automatische laden von NuGet-Paketen unterstützen.

In Visual Studio gibt es wenige Einstellungen mit denen du das "Package Restore" Verhalten beeinflussen kannst. In den Optionen von Visual Studio gibt es einen allgemeinen Bereich für den "Package Manager". Dort findest du Einstellungen um beispielsweise NuGet zu verbieten automatisch fehlende Pakete zu laden.

Jetzt erstmal viel Spaß mit dem automatischen laden von externen Assemblies

Jan

## Merke

-	Externe Bibliotheken die du über NuGet in dein Projekt eingefügt hast, stehen in einer oder mehreren `packages.config` Datei(en).
-	Es reicht die `packages.config` Datei in die Versionsverwaltung zu legen. Die benötigten Pakete werden dann automatisch geladen.
-	Stelle sicher, dass du alle `.nupkg` Dateien und den Inhalt der `packages` Verzeichnisse nicht in die Versionsverwaltung legst.
-	Das exakte Verhalten bezüglich "Package Restore" wird über die allgemeinen Einstellungen im Bereich "Package Manager" in den Visual Studio Optionen beeinflusst.
-	Gerade in größeren Projekten solltest du darauf achten, dass feste Versionen der NuGet Bibliotheken im `packages.config` verwendet werden.

## Lernquiz

Verwende folgende Fragen um das gelernte von heute zu festigen:

-	Was bedeutet "Package Restore" im Kontext von NuGet?
-	Welche Datei(en) gehören in die Versionsverwaltung um "Package Restore" verwenden zu können?
-	Welches Kommando kannst du in der Kommandozeile verwenden um NuGet die Pakete für dein Projekt / deine Solution laden zu lassen?

Am besten du schaust dir morgen und dann nochmal in ein paar Tagen die vorherigen Fragen an und beantwortest sie ohne den Text vorher gelesen zu haben.

## Weitere Informationen

-	Weitere Details wie sich NuGet beim Package Restore in Visual Studio und MSBuild verhält, findest du [hier](https://docs.nuget.org/consume/package-restore)
-	[Hier](https://github.com/github/gitignore/blob/master/VisualStudio.gitignore) findest du ein Beispiel für eine `.gitignore` Datei die die eigentlichen NuGet Pakete ignoriert. So kommen nur `packages.config` in dein Git-Verzeichnis
-	Um die NuGet Pakete im TFS zu ignorieren, musst du auch ein paar Dinge machen. Das ist [hier](https://docs.nuget.org/consume/NuGet-Config-Settings) beschrieben.
