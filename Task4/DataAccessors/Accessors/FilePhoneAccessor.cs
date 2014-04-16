using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataAccessors.Accessors
{
    public class FilePhoneAccessor: IAccessor<Phone>
    {
       private static XmlSerializer PhoneArraySerializer = 
            new XmlSerializer(typeof(List<Phone>), new[] { typeof(Phone) });

        private ICollection<Phone> data;
        private string fileName;

        public FilePhoneAccessor(string fileName)
        {
            this.fileName = fileName;
            try
            {
                data = DeserializeCollection();
            }
            catch
            {
                data = new LinkedList<Phone>();
            }
        }

        public ICollection<Phone> GetAll()
        {
            return data;
        }

        public Phone GetById(object id)
        {
            var res = from p in data where p.Id == (int)id select p;
            return res.FirstOrDefault<Phone>();
        }

        public void DeleteById(object id)
        {
            var res = from p in data where p.Id == (int)id select p;
            if (res.FirstOrDefault<Phone>() != null)
            {
                Phone existPhone = res.First<Phone>();
                data.Remove(existPhone);
            }
            SerializeCollection(data);
        }

        public void Insert(Phone p)
        {
            var tmp = from ep in data where ep.Id == p.Id select ep;
            Phone existPhone = tmp.FirstOrDefault<Phone>();
            if (existPhone != null)
            {
                data.Remove(existPhone);
            }
            data.Add(p);
            SerializeCollection(data);
        }

        public void SerializeCollection(ICollection<Phone> collection)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                PhoneArraySerializer.Serialize(sw, collection.ToList<Phone>());
            }
        }
        public ICollection<Phone> DeserializeCollection()
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                return (List<Phone>)PhoneArraySerializer.Deserialize(sr);
            }
        }
    }
}
