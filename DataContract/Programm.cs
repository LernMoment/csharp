using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Runtime.Serialization;
using System.Collections.Generic;

/// <summary>
/// Klasse für die ein Datenvertrag definiert ist.
/// </summary>
[DataContract]
public class LernMoment
{
	[DataMember(Name = "Email-Adressse des Autors")]
	private string emailAuthor;

	[DataMember(IsRequired = true)]
	public string Name {get; set;}

	[DataMember]
	public List<string> tags;

	public LernMoment()
	{
		emailAuthor = "jan@lernmoment.de";
		Name = "Objekte mühelos serialisieren mit Datenverträgen.";
		tags = new List<string>() {"Syntax", "Files", "Serialization"};
	}
}

/// <summary>
/// Zeigt dir wie du DataContracts verwendest.
/// </summary>
class BeispielDataContract
{
	static void Main()
	{
		var moment = new LernMoment();
		moment.Name += " Das hat nichts mit Mobilfunk zutun!";
		moment.tags.Add("kein Delegate");

		Speichern("lernmoment.xml", moment);
		var gelesenerMoment = Lesen("lernmoment.xml");

		Console.WriteLine("Der gelesene LernMoment hat folgenden Namen: {0}", gelesenerMoment.Name);
		Console.WriteLine("Der gelesene LernMoment hat folgende Tags:");
		gelesenerMoment.tags.ForEach(i => Console.WriteLine("{0}", i));
	}

	static LernMoment Lesen(string filename)
	{
		LernMoment result;
        DataContractSerializer serializer = new DataContractSerializer(typeof(LernMoment));
        using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
        {
            using (var reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas()))
            {
                result = (LernMoment)serializer.ReadObject(reader, true);
            }
        }

        return result;
	}

    static void Speichern(string filename, LernMoment moment)
    {
        DataContractSerializer serializer = new DataContractSerializer(typeof(LernMoment));
        using (Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
        {
            using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(stream, Encoding.UTF8))
            {
                writer.WriteStartDocument();
                serializer.WriteObject(writer, moment);
            }
        }
    }
}
