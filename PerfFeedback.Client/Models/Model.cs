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
        where TContractItem : class
        where TViewModelItem : class
    {
        public void Commit(TViewModelItem commitItem)
        {
            try
            {
                var item = OnTranslateToContract(commitItem);
                var response = OnCommit(item);
                OnPublish(response);
            }
            catch (Exception e)
            {
                //TODO LOG EXCEPTION
            }
        }

        public void Get(long id)
        {
            try
            {
                OnGet(id);
            }
            catch (Exception e)
            {
                //TODO LOG EXCEPTION
            }
        }

        public List<TViewModelItem> GetAll()
        {
            try
            {
                return OnGetAll();
            }
            catch (Exception e)
            {
                //TODO LOG EXCEPTION
            }

            return null;
        }

        public Model()
        {

        }

        protected abstract TViewModelItem OnCommit(TContractItem commitItem);
        protected abstract TViewModelItem OnGet(long id);
        protected abstract void OnPublish(TViewModelItem item);
        protected abstract List<TViewModelItem> OnGetAll();

        protected virtual TContractItem OnTranslateToContract(TViewModelItem item)
        {
            string serializedClient = serializeToString<TViewModelItem>(item);

            return deserializeToClass<TContractItem>(serializedClient);
        }

        protected virtual TViewModelItem OnTranslateToViewModel(TContractItem item)
        {
            string serializedContract = serializeToString<TContractItem>(item);

            return deserializeToClass<TViewModelItem>(serializedContract);
        }

        private TItem deserializeToClass<TItem>(string item)
            where TItem : class
        {
            var deserializedObj = new DataContractSerializer(typeof(TItem));

            using (var stringReader = new StringReader(item))
            {
                using (var xmlTextReader = new XmlTextReader(stringReader))
                {
                    return deserializedObj.ReadObject(xmlTextReader) as TItem;
                }
            }
        }

        private static string serializeToString<TItem>(TItem item)
        {
            var serializer = new DataContractSerializer(item.GetType());
            string ret = string.Empty;
            using (var writer = new StringWriter())
            {
                using (var tw = new XmlTextWriter(writer))
                {
                    serializer.WriteObject(tw, item);
                    return writer.ToString();
                    //ret = writer.ToString();
                }
            }
            //string nn = string.Empty;
            //var serializer2 = new DataContractSerializer(typeof(PerfFeedback.BusinessService.Contract.CoWorker));
            //using (var writer = new StringWriter())
            //{
            //    using (var tw = new XmlTextWriter(writer))
            //    {
            //        serializer2.WriteObject(tw, new PerfFeedback.BusinessService.Contract.CoWorker());
            //        //return writer.ToString();
            //        nn = writer.ToString();
            //    }
            //}

            //return nn;
        }
    }
}
