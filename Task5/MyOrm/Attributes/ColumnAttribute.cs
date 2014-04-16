using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyOrm.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false, Inherited=true)]
    public class ColumnAttribute: Attribute
    {
        public string ColumnName { get; set; }
        public DbType ColumnType { get; set; }
    }
}
