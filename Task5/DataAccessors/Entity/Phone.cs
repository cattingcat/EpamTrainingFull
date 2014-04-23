using System;
using System.Data;

using MyOrm.Attributes;

namespace DataAccessors.Entity
{
    [Serializable]
    [Table(TableName = "PhoneTbl")]
    public class Phone
    {
        [Id(ColumnName = "id", ColumnType = DbType.Int32)]
        public int Id { get; set; }
        [Column(ColumnName = "number", ColumnType = DbType.String)]
        public string Number { get; set; }
        [Column(ColumnName = "person_id", ColumnType = DbType.Int32)]
        public int PersonId { get; set; }

        [One(SecondTable="PersonTbl", ThisColumn="person_id")]
        public Person Owner { get; set; }

        public override string ToString()
        {
            return String.Format("Id: {0, 5}, Num: {1}, Person: {2}", Id, Number, Owner == null ? 
                PersonId.ToString() : Owner.Name + " " + Owner.Id);
        }
    }
}
