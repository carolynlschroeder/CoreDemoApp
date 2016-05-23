using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoreDemoApp.BusinessMethods
{
    public class SerializationLogic<T>
    {

        public static byte[] Serialize(T m)
        {
            if (m == null)
                return null;

            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            bf.Serialize(ms, m);

            return ms.ToArray();

        }

        public static T Deserialize(byte[] bytes)
        {
            var memStream = new MemoryStream();
            var bf= new BinaryFormatter();
            memStream.Write(bytes, 0, bytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            T m = (T)bf.Deserialize(memStream);

            return m;

        }
    }
}
