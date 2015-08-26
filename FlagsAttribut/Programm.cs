using System;

/// <summary>
/// Zeigt dir wie du mit [Flags] Enums als Bitfelder verwendest
/// </summary>
class FlagsAttributLernMoment
{
	enum DeviceConnectionStatus : byte
	{
		Available = 0,
		Connected = 1,
		Disconnected = 2
	}

	[Flags]
	enum DeviceErrorStatus : byte
	{
		None = 0,
		HardwareError = 1,
		Hardware_CommunicationError = 2,
		Hardware_TemperatureTooHigh = 4,
		Hardware_MemoryCrcError = 8,
		WatchdogError = 16,
		SoftwareError = 32
	}

	[Flags]
	enum AccessRights : byte
	{
		None	= 0,
		Read	= 1 << 0, // 1
		Write	= 1 << 1, // 2

		ReadWrite = Read | Write
	}

	static void Main()
	{
		// DeviceConnectionStatus ist ohne [Flags] definiert. Eine Variable diesen
		// Typs hat also immer nur einen der definierten Werte.
		DeviceConnectionStatus connectionStatus = DeviceConnectionStatus.Available;
		Console.WriteLine("Aktueller Verbindungsstatus: {0}", connectionStatus);

		// Du kannst einer Enum auch einen Wert zuweisen der nicht für sie definiert
		// ist. Dann bekommst du aber auch keine passende Beschreibung.
		// Du musst auch schon einen richtigen Cast anwenden, damit der Compiler nicht
		// meckert.
		connectionStatus = (DeviceConnectionStatus)3; 
		Console.WriteLine("Aktueller Verbindungsstatus ohne gültige Beschreibung: {0}", connectionStatus);

		DeviceErrorStatus error = DeviceErrorStatus.HardwareError 
									| DeviceErrorStatus.Hardware_CommunicationError 
									| DeviceErrorStatus.WatchdogError;

		Console.WriteLine("Ist das Flag HardwareError gesetzt? {0}", error.HasFlag(DeviceErrorStatus.HardwareError));
		Console.WriteLine("Ist das Flag SoftwareError gesetzt? {0}", error.HasFlag(DeviceErrorStatus.SoftwareError));
	}
}
