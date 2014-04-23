using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;

namespace MyOrm
{
    internal class DbReaderAdapter
    {
        private DbDataReader _reader;
        private OrmMap _map;

        public DbReaderAdapter(DbDataReader reader, OrmMap map)
        {
            _reader = reader;
            _map = map;
        }

        public T GetSingleResult<T>() where T: class, new()
        {
            while (_reader.Read())
            {
                T o = new T();
                for (int i = 0; i < _reader.FieldCount; ++i)
                {                  
                    string column = _reader.GetName(i);
                    PropertyInfo info = _map[column];
                    object value = _reader.GetValue(i);
                    if (value != DBNull.Value)
                    {
                        info.SetValue(o, value);
                    }
                    else
                    {
                        info.SetValue(o, null);
                    }                    
                }
                return o;
            }
            return null;
        }

        public ICollection<T> GetMultipleResult<T>() where T : class, new()
        {
            List<T> result = new List<T>();
            while (_reader.Read())
            {
                T o = new T();
                for (int i = 0; i < _reader.FieldCount; ++i)
                {
                    string column = _reader.GetName(i);
                    PropertyInfo info = _map[column];
                    object value = _reader.GetValue(i);
                    if (value != DBNull.Value)
                    {
                        info.SetValue(o, value);
                    }
                    else
                    {
                        info.SetValue(o, null);
                    }
                }
                result.Add(o);
            }
            return result;
        }

        public object GetSingleResult()
        {
            while (_reader.Read())
            {
                object o = Activator.CreateInstance(_map.ObjectType);
                for (int i = 0; i < _reader.FieldCount; ++i)
                {
                    string column = _reader.GetName(i);
                    PropertyInfo info = _map[column];
                    object value = _reader.GetValue(i);
                    if (value != DBNull.Value)
                    {
                        info.SetValue(o, value);
                    }
                    else
                    {
                        info.SetValue(o, null);
                    }
                }
                return o;
            }
            return null;
        }

        public ICollection<object> GetMultipleResult()
        {
            List<object> result = new List<object>();
            while (_reader.Read())
            {
                object o = Activator.CreateInstance(_map.ObjectType);
                for (int i = 0; i < _reader.FieldCount; ++i)
                {
                    string column = _reader.GetName(i);
                    PropertyInfo info = _map[column];
                    object value = _reader.GetValue(i);
                    if (value != DBNull.Value)
                    {
                        info.SetValue(o, value);
                    }
                    else
                    {
                        info.SetValue(o, null);
                    }
                }
                result.Add(o);
            }
            return result;
        }
    }
}
