using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SerializationApp;
public class WrappedJsonConvert: ISerializer
{
    public T DeserialiseObject<T>(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        T obj = JsonConvert.DeserializeObject<T>(jsonString);

        return obj;
    }

    public bool SerializeObject<T>(string filePath, T obj)
    {
        try
        {
            string jsonString = JsonConvert.SerializeObject(obj);
            File.WriteAllTextASync(filePath, jsonString);
            JsonConvert writer = new(typeof(T));
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
}
