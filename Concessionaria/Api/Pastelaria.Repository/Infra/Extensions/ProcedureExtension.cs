using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace Concessionaria.Repository.Infra.Extensions
{
    public static class ProcedureExtension
    {
        public static T ReadAttr<T>(this IDataReader r, string attrName)
        {
            try
            {
                if (r[attrName] == DBNull.Value || string.IsNullOrEmpty(r[attrName].ToString()))
                    return default(T);

                var tipoT = typeof(T);
                var tipoR = r[attrName].GetType();

                return (T)(tipoR == tipoT || (tipoT.GetGenericArguments().Any() && tipoR == tipoT.GenericTypeArguments[0])
                    ? r[attrName]
                    : Convert.ChangeType(r[attrName], tipoT));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T Cast<T>(this IDataReader r) where T : class
        {
            var propName = "";
            try
            {
                var obj = (T)Activator.CreateInstance(typeof(T));
                var props = obj.GetType().GetProperties();
                for (var i = 0; i < r.FieldCount; i++)
                {
                    var columnName = r.GetName(i);
                    if (r[columnName] == DBNull.Value || r[columnName] == null)
                        continue;

                    var prop = props.FirstOrDefault(x => string.Equals(x.Name, columnName, StringComparison.OrdinalIgnoreCase));
                    if (prop == null)
                        continue;

                    propName = prop.Name;
                    var propType = prop.PropertyType;
                    var columnType = r[columnName].GetType();

                    prop.SetValue(obj, propType == columnType || (propType.GetGenericArguments().Any() && propType.GenericTypeArguments[0] == columnType)
                        ? r[columnName]
                        : Convert.ChangeType(r[columnName], propType));
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{propName}: {ex.Message}");
            }
        }

        public static T CastEmpty<T>(this IDataReader r) where T : class, new() => r.Read() ? r.Cast<T>() : new T();

        public static IEnumerable<T> CastEnumerable<T>(this IDataReader r) where T : class
        {
            var collection = new Collection<T>();
            while (r.Read())
                collection.Add(r.Cast<T>());
            return collection;
        }

        public static IEnumerable<T> CastEnumerable<T>(this IDataReader r, string column)
        {
            var collection = new Collection<T>();
            while (r.Read())
                collection.Add(r.ReadAttr<T>(column));
            return collection;
        }
    }
}