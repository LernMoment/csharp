using System;

/// <summary>
/// Ein Singleton basierend auf Lazy<T>
/// </summary>
sealed class MeinSingleton
{
	private static readonly Lazy<MeinSingleton> dieInstanz = new Lazy<MeinSingleton>(() => new MeinSingleton());

	public static MeinSingleton Instanz { get {return dieInstanz.Value;}}

	private MeinSingleton()
	{
		// Keinen öffentlichen Standardkonstruktor erlauben.
	}

	public void SagHallo()
	{
		Console.WriteLine("Hallo da draußen!");
	}
}


/// <summary>
/// Zeigt wie das Singleton verwendet werden kann
/// </summary>
class UebungSingletonImplementieren
{
	static void Main()
	{
		MeinSingleton halloSager = MeinSingleton.Instanz;

		halloSager.SagHallo();
	}
}
