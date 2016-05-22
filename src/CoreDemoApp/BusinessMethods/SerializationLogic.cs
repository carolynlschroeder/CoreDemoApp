using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoreDemoApp.BusinessMethods
{
    public class SerializationLogic<T>
    {

        public static string Serialize(T m)
        {
            return JsonConvert.SerializeObject(m);
        }

        public static T Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
