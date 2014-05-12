using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using MyOrm.Attributes;

namespace MyOrm
{
    internal enum ColumnType { Simple, Relation };

    internal class OrmMap
    {
        private IDictionary<string, PropertyInfo> _simpleColumnToProperty;
        private IDictionary<string, PropertyInfo> _relationColumnToProperty;
        private Type objectType;

        public string TableName { get; private set; }
        public string ID { get; private set; }

        private OrmMap()
        {
            _simpleColumnToProperty = new Dictionary<string, PropertyInfo>();
            _relationColumnToProperty = new Dictionary<string, PropertyInfo>();
        }

        public PropertyInfo this[string columnName, ColumnType type = ColumnType.Simple]
        {
            get
            {
                if (type == ColumnType.Simple)
                    return _simpleColumnToProperty[columnName];
                else if (type == ColumnType.Relation)
                    return _relationColumnToProperty[columnName];
                else
                    throw new Exception("");
            }
        }

        public ICollection<string> Columns
        {
            get
            {
                return _simpleColumnToProperty.Keys;
            }
        }

        public ICollection<string> Relations
        {
            get
            {
                return _relationColumnToProperty.Keys;
            }
        }

        public PropertyInfo GetIDPropertyInfo() 
        {
            return this[ID];
        }

        public System.Data.DbType GetDbType(string columnName)
        {
            ColumnAttribute attr = this[columnName].GetCustomAttribute<ColumnAttribute>();
            return attr.ColumnType;
        }

        public Type ObjectType
        {
            get
            {
                return objectType;
            }
        }


        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.Append("Table name: ");
            b.Append(TableName);
            b.Append("\nColumns: \n");
            foreach (var c in _simpleColumnToProperty)
            {
                b.Append("  ");
                b.Append(c.Key);
                b.Append(" => ");
                b.Append(c.Value.Name);
                b.Append("\n");
            }
            return b.ToString();
        }


        public static OrmMap FromType(Type type)
        {
            TableAttribute attr = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).SingleOrDefault();
            if (attr == null)
            {
                throw new Exception("this type have no TableAttribute");
            }
            OrmMap map = new OrmMap();
            map.objectType = type;
            map.TableName = attr.TableName;

            foreach (PropertyInfo p in type.GetProperties())
            {
                ColumnAttribute ca = p.GetCustomAttribute<ColumnAttribute>();
                if (ca != null)
                {
                    map._simpleColumnToProperty[ca.ColumnName] = p;
                    if (ca is IdAttribute)
                    {
                        map.ID = ca.ColumnName;
                    }
                }
                else
                {
                    RelationAttribute ra = p.GetCustomAttribute<RelationAttribute>();
                    if (ra != null)
                    {
                        if (ra.Type == RelationType.One)
                        {
                            map._relationColumnToProperty[ra.ThisColumn] = p;
                        }
                        else if(ra.Type == RelationType.Many)
                        {
                            map._relationColumnToProperty[map.ID] = p;
                        }
                    }
                }
            }
            return map;
        }
    }
}
