using System;

namespace LernMoment.DocTag
{
	/// <summary>
	/// Eine Beispielklasse um die veschiedenen Tags der Dokumentationskommentare
	/// auszuprobieren.
	/// </summary>
	/// <remarks>
	/// Weitere Informationen können in dem <c>remarks</c> Tag eingefügt werden.
	/// Diese werden aber nicht per Intellisense angezeigt.
	/// </remarks>
	public class DocTagKlasse
	{
		/// <summary>
		/// Für den Konstruktor kann ebenfalls <c>summary</c> verwendet werden.
		/// </summary>
		/// <param name="tag">Mit dem <c>param</c> Tag können Parameter beschrieben werden.</param>
		public DocTagKlasse (string tag)
		{
		}

		/// <summary>
		/// Bei Eigenschaften gibt es auch den <c>summary</c> Tag
		/// </summary>
		/// <value>Diesen Tag verstehe ich nicht so wirklich.</value>
		public string LernMoment {
			get;
			set;
		}

		/// <summary>
		/// Zeigt die Verwendung des <c>typeparam</c> Tags. Dieses ist der letzte der
		/// 3 verfügbaren Tags die von Intellisense verwendet werden.
		/// </summary>
		/// <returns>Feld mit der <paramref name="anzahlElemente"/></returns>
		/// <param name="anzahlElemente">Anzahl elemente.</param>
		/// <typeparam name="T">Auch der <c>typeparam</c> Tag wird von Intellisense angezeigt.</typeparam>
		public static T[] erstelleGenerischesFeld<T>(int anzahlElemente) {
			return new T[anzahlElemente];
		}
	}
}

