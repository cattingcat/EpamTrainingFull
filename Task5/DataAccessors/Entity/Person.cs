using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;

using MyOrm.Attributes;

namespace DataAccessors.Entity
{
    [Serializable]
    [Table(TableName = "PersonTbl")]
    public class Person
    {
        public Person()
        {
            DayOfBirth = DateTime.Now;
        }

        [Id(ColumnName = "id", ColumnType = DbType.Int32)]
        public int Id { get; set; }
        [Column(ColumnName = "name", ColumnType = DbType.String)]
        public string Name { get; set; }
        [Column(ColumnName = "lastname", ColumnType = DbType.String)]
        public string LastName { get; set; }
        [Column(ColumnName = "dob", ColumnType = DbType.DateTime)]
        public DateTime DayOfBirth { get; set; }       
        [XmlIgnore]
        [Many(SecondTable = "PhoneTbl", SecondColumn = "person_id")]
        public ICollection<Phone> Phones { get; set; }

        public override string ToString()
        {
            return String.Format("id: {0, 5}, name: {1, 10}, lastname: {2, 10}, DayOfBirth: {3}, Phones: {4, 3}",
                Id, Name.Trim(), LastName.Trim(), DayOfBirth.ToString("d MMM yyyy"), Phones == null ? 0 : Phones.Count);
        }
        
        /* public override string ToString()
        {
            return String.Format("id: {0, 5}, name: {1, 10}, lastname: {2, 10}, DayOfBirth: {3}",
                ID, Name.Trim(), LastName.Trim(), DayOfBirth.ToString("d MMM yyyy"));
        } */
    }
}
