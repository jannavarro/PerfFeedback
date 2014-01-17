using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace PerfFeedback.Client.Models
{
    public abstract class Model<TContractItem, TViewModelItem>
    {
        public void Commit(TViewModelItem commitItem)
        {
            try
            {
                var item = OnTranslate(commitItem);
                OnCommit(item);
            }
            catch (Exception e)
            {
                //TODO LOG EXCEPTION
            }
        }

        protected abstract void OnCommit(TContractItem commitItem);

        protected virtual TContractItem OnTranslate(TViewModelItem item)
        {
            string serializedClient = serializeToString<TViewModelItem>(item);
            var deserializedContract = deserializeToContract<TContractItem>(serializedClient);
            //xml.Serialize
            //var dataSerializer = new DataContractSerializer(typeof(TContractItem));
            //dataSerializer.ReadObject(XmlDictionaryReader.CreateDictionaryReader(
        }

        private T deserializeToContract<T>(string item)
        {
            var deserializedObj = new DataContractSerializer(typeof(T));

            using (var stringReader = new StringReader(item))
            {
                using (var xmlTextReader = new XmlTextReader(stringReader))
                {
                    return deserializedObj.ReadObject(xmlTextReader) as T;
                }
            }
        }

        private static string serializeToString<T>(T item)
        {
            var serializer = new DataContractSerializer(item.GetType());

            using (var writer = new StringWriter())
            {
                using (var tw = new XmlTextWriter(writer))
                {
                    serializer.WriteObject(tw, item);
                    return writer.ToString();
                }
            }
        }
    }
}
