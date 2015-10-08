using System;

/// <summary>
/// 
/// </summary>
sealed class LernMoment
{
	private readonly int id = 42;

	public LernMoment()
	{
		id = 43;
	}

	public int SagId()
	{
		return id;
	}
}


/// <summary>
/// 
/// </summary>
class UebungReadonlyVerwenden
{
	static void Main()
	{
		const LernMoment test = new LernMoment();

		Console.WriteLine("Die id ist: {0}", test.SagId());
	}
}
