# Lernmoment in CSharp - Automatisiere deine Installationsaufgaben, installierst du noch, oder entwickelst du schon?

Wieviel Zeit hast du bisher dieses Jahr damit verbracht deine Rechner zu installieren? Je nachdem welche Aufgaben du hast, wirst du verschiedene Entwicklungs-, Test-, Build- und sonstige Rechner in deiner Verantwortung haben. Diese brauchen bestimmte Programme, damit du auf ihnen deine Software entwickeln, bauen und testen kannst.

Für C# sind das Programme wie VisualStudio oder MonoDevelop, aber auch viele zusätzliche Programme wie dein Lieblingsbrowser, ein Editor und vielleicht eine Menge Tools wie 7zip oder VirtualBox.

Die manuelle Installation eines Entwicklungsrechners dauert bestimmt auch bei dir mindestens 1 Tag. Häufig brauchst du wahrscheinlich auch 2 oder 3 Tage. Das liegt unter anderem daran, dass du alle diese Schritte ausführst:

1.	Überlegen welche Programme du aktuell auf deinem Rechner installiert hast
2.	Feststellen welche Versionen der Programme du verwendest und ob es Sinn macht auf neuere Versionen umzusteigen
3.	Zusätzliche Informationen wie Lizenzschlüssel oder besondere Konfigurationen suchen
4.	Alle benötigten Programme suchen und die entsprechenden Setups auf deinen Rechner laden
5.	Nun alles installieren und unzählige Dialoge bearbeiten (gibst du den Lizenzschlüssel eigentlich immer beim erstenmal richtig ein?)
6.	Die wichtigsten Konfigurationen der wichtigsten Programme vom alten auf den neuen Rechner übertragen, wenn das möglich ist

Was passiert eigentlich, wenn du einen neuen Kollegen bekommst? Habt ihr ein Dokument in dem beschrieben ist was alles für einen Entwicklungsrechner zu installieren ist? Ist das Dokument noch auf dem aktuellen Stand?

Eine wirklich nachhaltige Lösung für dieses Problem ist die Automation der Installationsaufgabe. Es gibt mittlerweile einige Werkzeuge, die eine Beschreibungsdatei analysieren können und dann die Installation für dich übernehmen. Der Vorteil ist, dass du eine solche Beschreibungsdatei in deine Versionsverwaltung legen kannst und kontinuierlich aktualisieren kannst. Vorbei die Tage des Suchens nach der richtigen Setup-Datei.

Ein Werkzeug welches du mal ausprobieren kannst, ist [Boxstarter](http://boxstarter.org). Insbesondere [Chocolatey](https://chocolatey.org), der verwendete Paketmanager, hat noch ein paar offene Punkte (z.B. fehlen häufig aktuelle Versionen der Programme). Das Konzept ist aber genial. 

Ich habe dazu mal ein Beispiel für dich vorbereitet ([C# Umgebung mit Beta Software](https://gist.githubusercontent.com/suchja/ba7cd5e6607feaead5c4/raw/f03cf835c22f3a7e3eb33d74ee3611b207f8b0da/boxstarter-cs-beta-devenv)). Wenn du einen Rechner oder Virtuelle Maschine hast in der du auch Beta Software installieren magst, brauchst du nur auf den Link in dem Kommentar zu dem Gist klicken und die Installation beginnt.

Jetzt erstmal viel Spaß mit deiner reproduzierbaren Installation

Jan

## Merke

-	Auch wenn du nur wenige mal im Jahr einen Rechner installierst, es braucht sehr viel Zeit.
-	Gerade Entwicklungs-, Build- und Testrechner haben ähnliche Anforderungen bezüglich der zu installierenden Software.
-	Die automatische Installation dieser Rechner mit einem Werkzeug und einer Beschreibungsdatei hat viele Vorteile
  -	Reproduzierbarkeit der Installation
  -	Du benötigst keine weitere Dokumentation
  -	Die Beschreibungsdatei in der Versionsverwaltung deines Projekt zusammen mit Quellcode liegen.

## Lernquiz

Verwende folgende Fragen um das gelernte von heute zu festigen:

-	Warum benötigt die Installation eines Entwicklungsrechners einiges an Zeit?
-	Was sind Vorteile der Automation der Installation?
-	Was sind Nachteile der Automation der Installation? -> Bin ich in diesem LM nicht drauf eingegangen. Musst du selbst heraus finden.

Am besten du schaust dir morgen und dann nochmal in ein paar Tagen die vorherigen Fragen an und beantwortest sie ohne den Text vorher gelesen zu haben.

## Weitere Informationen

Zum heutigen LernMoment habe ich keine weiteren Quellen. Die Links sind bereits im Text enthalten.
