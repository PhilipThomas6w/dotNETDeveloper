using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationApp;

// 3. Create an ISerialiser interface
public interface ISerializer
{
    bool SerializeObject<T>(string filePath, T obj);

    T DeserializeObject<T>(string filePath);

}
