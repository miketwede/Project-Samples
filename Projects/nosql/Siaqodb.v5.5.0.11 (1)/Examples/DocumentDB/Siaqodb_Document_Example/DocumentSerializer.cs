using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Sqo;

namespace Siaqodb_Document_Example
{
    internal class MyJsonSerializer : IDocumentSerializer
    {
        #region IDocumentSerializer Members
        public object Deserialize(Type type, byte[] objectBytes)
        {
            string jsonStr = Encoding.UTF8.GetString(objectBytes);
            return JsonConvert.DeserializeObject(jsonStr.TrimEnd('\0'), type);
        }
        public byte[] Serialize(object obj)
        {
            string jsonStr = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return Encoding.UTF8.GetBytes(jsonStr);
        }
        #endregion

    }
    public class ProtoBufSerializer : IDocumentSerializer
    {

        #region IDocumentSerializer Members

        public object Deserialize(Type type, byte[] objectBytes)
        {
            using (MemoryStream ms = new MemoryStream(objectBytes))
            {
                return ProtoBuf.Serializer.NonGeneric.Deserialize(type, ms);
            }
        }

        public byte[] Serialize(object obj)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                ProtoBuf.Serializer.NonGeneric.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        #endregion
    }
    public class BSONSerializer : IDocumentSerializer
    {
        #region IDocumentSerializer Members
        readonly JsonSerializer serializer = new JsonSerializer();
        public object Deserialize(Type type, byte[] objectBytes)
        {
            using (MemoryStream ms = new MemoryStream(objectBytes))
            {
                var jsonTextReader = new BsonReader(ms);
                return serializer.Deserialize(jsonTextReader, type);
            }
        }

        public byte[] Serialize(object obj)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                BsonWriter writer = new BsonWriter(ms);
                serializer.Serialize(writer, obj);

                return ms.ToArray();
            }
        }

        #endregion
    }
    public class MsgPackSerializer : IDocumentSerializer
    {
        #region IDocumentSerializer Members

        public object Deserialize(Type type, byte[] objectBytes)
        {
            var serializer = MsgPack.Serialization.MessagePackSerializer.Create(type);
            return serializer.UnpackSingleObject(objectBytes);
        }

        public byte[] Serialize(object obj)
        {
            var serializer = MsgPack.Serialization.MessagePackSerializer.Create(obj.GetType());
            return serializer.PackSingleObject(obj);
        }

        #endregion
    }
}
