namespace Boardgames.DataProcessor.Utilities;

using System.Text;
using System.Xml.Serialization;
using System.Xml;

public class XmlHelper
{
    public T Deserialize<T>(string inputXml, string rootName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

        StringReader reader = new StringReader(inputXml);

        T supplierDtos = (T)xmlSerializer.Deserialize(reader)!;

        return supplierDtos;
    }
    public IEnumerable<T> DeserializeCollection<T>(string inputXml, string rootName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), xmlRoot);

        StringReader reader = new StringReader(inputXml);

        T[] supplierDtos = (T[])xmlSerializer.Deserialize(reader)!;

        return supplierDtos;
    }
    public string Serialize<T>(T obj, string rootName)
    {
        StringBuilder sb = new StringBuilder();

        XmlRootAttribute xmlRoot =
            new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer =
            new XmlSerializer(typeof(T), xmlRoot);

        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        StringWriter stringWriter = new StringWriter(sb);

        using XmlWriter writer =
            XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true });

        xmlSerializer.Serialize(writer, obj, namespaces);

        return sb.ToString().TrimEnd();
    }
    public string Serialize<T>(T[] obj, string rootName)
    {
        StringBuilder sb = new StringBuilder();

        XmlRootAttribute xmlRoot =
            new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer =
            new XmlSerializer(typeof(T[]), xmlRoot);

        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        StringWriter stringWriter = new StringWriter(sb);

        using XmlWriter writer =
            XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true });

        xmlSerializer.Serialize(writer, obj, namespaces);

        return sb.ToString().TrimEnd();
    }
}
