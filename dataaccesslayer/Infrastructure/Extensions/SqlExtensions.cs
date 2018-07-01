using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure.Extensions
{
    static class SqlExtensions
    {
        public static T ToObject<T>(this DataRow row)
        {
            T item = Activator.CreateInstance<T>();
            foreach (PropertyInfo propriedade in typeof(T).GetProperties())
            {
                if (row[propriedade.Name].GetType() != typeof(DBNull))
                {
                    propriedade.SetValue(item, row[propriedade.Name]);
                }
            }
            return item;
        }
        public static List<T> ToObjectCollection<T>(this DataTable table)
        {
            List<T> items = Activator.CreateInstance<List<T>>();
            foreach (DataRow row in table.Rows)
            {
                items.Add(ToObject<T>(row));
            }
            return items;
        }

        public static object ToObject(this DataRow row, object obj)
        {
            Type t = obj.GetType().DeclaringType;
            object item = obj;
            foreach (PropertyInfo propriedade in obj.GetType().GetProperties())
            {
                if (row[propriedade.Name].GetType() != typeof(DBNull))
                {
                    propriedade.SetValue(item, row[propriedade.Name]);
                }
            }
            return item;
        }
        public static List<object> ToObjectCollection(this DataTable table, object obj)
        {
            List<object> items = new List<object>();
            foreach (DataRow row in table.Rows)
            {
                items.Add(ToObject(row, obj));
            }
            return items;
        }
    }
}
