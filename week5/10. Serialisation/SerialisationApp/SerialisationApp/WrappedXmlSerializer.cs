using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationApp;

public class WrappedXmlSerializer : ISerializer
{
    public T DeserializeObject<T>(string filePath)
    {
        FileStream fileStream = File.OpenRead(filePath);
        XmlSerializer reader = new(typeof(T));
        T obj = (T)reader.Deserialize(fileStream);
        fileStream.Close();
        return obj;
    }

    public bool SerializeObject<T>(string filePath, T obj)
    {
        try
        {
            FileStream fileStream = File.Create(filePath);
            XmlSerializer writer = new(typeof(T));
            writer.Serialize(fileStream, obj);
            fileStream.Close();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
}