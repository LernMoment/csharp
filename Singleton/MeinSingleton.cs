using System;
using System.Collections.Generic;

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
/// 
/// </summary>
class UebungSingletonImplementieren
{
	static void Main()
	{
		MeinSingleton halloSager = MeinSingleton.Instanz;

		halloSager.SagHallo();
	}
}
