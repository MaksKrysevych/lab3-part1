using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Reflection;
using System.IO;

namespace lab3_part1
{
    class CustomProvider : IFormatter
    {
        private Type _type;

        public CustomProvider(Type type)
        {
            _type = type;
        }

        public CustomProvider()
        {
        }

        public void Serialize(Stream serializationStream, object graph)
        {
            List<PropertyInfo> properties = _type.GetProperties().ToList();
            StreamWriter streamWriter = new StreamWriter(serializationStream);
            streamWriter.WriteLine(_type.Name);
            foreach (PropertyInfo proppertyInfo in properties)
            {
                streamWriter.WriteLine(string.Format("{0} : {1}", proppertyInfo.Name, proppertyInfo.GetValue(graph)));
            }
            streamWriter.Flush();
        }

        public object Deserialize(Stream serializationStream)
        {
            Object obj = Activator.CreateInstance(_type);

            using (var sr = new StreamReader(serializationStream))
            {
                string typeName = sr.ReadLine();
                string contents = sr.ReadToEnd();
                List<string> pairs = contents.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string key, value;
                foreach (string pair in pairs)
                {
                    string[] keyValue = pair.Split(':');
                    key = keyValue[0];
                    value = keyValue[1];

                    PropertyInfo propertyInfo = _type.GetProperty(key);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(obj, value, null);
                    }
                }
            }
            return obj;
        }
        
        public ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SerializationBinder Binder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public StreamingContext Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void CustomSerialize(Type dataType, object data, string filePath)
        {
            CustomProvider customProvider = new CustomProvider(dataType);
            if (File.Exists(filePath)) File.Delete(filePath);
            FileStream fileStream = File.Create(filePath);
            customProvider.Serialize(fileStream, data);
            fileStream.Close();
        }
        public object CustomDeserialize(Type dataType, string filePath)
        {

            object obj = null;

            CustomProvider custom = new CustomProvider(dataType);
            if (File.Exists(filePath))
            {
                FileStream fileStream = File.Open(filePath, FileMode.Open);
                obj = custom.Deserialize(fileStream);
                fileStream.Close();
            }

            return obj;
        }
    }
}
