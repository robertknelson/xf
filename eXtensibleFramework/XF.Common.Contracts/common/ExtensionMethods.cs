﻿// <copyright company="eXtensoft, LLC" file="ExtensionMethods.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;


    public static class ExtensionMethods
    {
        private static IList<Type> typeWhitelist = new List<Type>{
            typeof(bool),
            typeof(char),
            typeof(decimal),
            typeof(double),
            typeof(float),
            typeof(Int16),
            typeof(Int32),
            typeof(Int64),
            typeof(string),
            typeof(DateTime),
            //typeof(DateTimeOffset),
            typeof(Guid),
        };

        public static List<TypedItem> ToTypeItems(this IDictionary<string, object> properties)
        {

            List<TypedItem> list = new List<TypedItem>();
            HashSet<string> hs = new HashSet<string>();
            foreach (var prop in properties)
            {
                if (!String.IsNullOrWhiteSpace(prop.Key) && prop.Value != null)
                {
                    string key = prop.Key;
                    if (hs.Add(key))
                    {
                        if (typeWhitelist.Contains(prop.Value.GetType()) | prop.Value.GetType().BaseType.Equals(typeof(Enum)))
                        {
                            list.Add(new TypedItem(key, prop.Value));
                        }
                        else
                        {
                            bool b = false;
                            try
                            {
                                string s = GenericSerializer.XmlStringFromItem(prop.Value);
                                list.Add(new TypedItem(key, s));
                                b = true;
                            }
                            catch { }

                            if (!b)
                            {
                                list.Add(new TypedItem(key, prop.ToString()));
                            }
                        }
                    }
                }
            }
            return list;
        }


        public static string ToDelimited(this string[] arrayOfString, char delimiter)
        {
            string s = String.Empty;
            if (arrayOfString.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < arrayOfString.Length; i++)
                {
                    if (i > 0)
                    {
                        sb.Append(delimiter);
                    }
                    sb.Append(arrayOfString[i].Trim());
                }
                s = sb.ToString();
            }
            return s;
        }
        public static List<TypedItem> ToTypedItems(this Dictionary<string, object> dictionary)
        {
            HashSet<string> hs = new HashSet<string>();
            List<TypedItem> list = new List<TypedItem>();
            foreach (var key in dictionary.Keys)
            {
                if (hs.Add(key))
                {
                    list.Add(new TypedItem(key, dictionary[key]));
                }
            }
            return list;
        }
        public static IDictionary<string, object> ToIDictionary(this ICriterion criterion)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            HashSet<string> hs = new HashSet<string>();
            foreach (var item in criterion.Items)
            {
                if (hs.Add(item.Key))
                {
                    d.Add(item.Key, item.Value);
                }
            }
            return d;
        }

        public static Dictionary<string, object> ToDictionary(this List<TypedItem> items)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            HashSet<string> hs = new HashSet<string>();
            foreach (var item in items)
            {
                if (hs.Add(item.Key))
                {
                    d.Add(item.Key, item.Value);
                }
            }
            return d;
        }

        public static Dictionary<string, object> ToDictionary(this IContext context)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            HashSet<string> hs = new HashSet<string>();
            foreach (var item in context.TypedItems)
            {
                if (hs.Add(item.Key))
                {
                    d.Add(item.Key, item.Value);
                }
            }
            return d;
        }

        public static Dictionary<string, object> ToDictionary(this IContext context, string ticket)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            HashSet<string> hs = new HashSet<string>();
            foreach (var item in context.TypedItems)
            {
                if (hs.Add(item.Key))
                {
                    d.Add(item.Key, item.Value);
                }
            }
            if (hs.Add(XFConstants.Context.Ticket))
            {
                d.Add(XFConstants.Context.Ticket, ticket);
            }
            return d;
        }


        public static bool ContainsKey<T>(this List<TypedItem> list, string key)
        {
            bool b = false;
            Type type = typeof(T);
            if (list != null && list.Count > 0)
            {
                foreach (var item in list.Where(x => x.Value != null))
                {

                    if (item.Key.Equals(key, StringComparison.OrdinalIgnoreCase) && item.Value.GetType().Equals(typeof(T)))
                    {
                        b = true;
                        break;
                    }
                }
            }
            return b;
        }

        public static T Get<T>(this List<TypedItem> list, string key)
        {
            T t = default(T);
            bool b = false;
            if (list != null && list.Count > 0)
            {
                for (int i = 0; !b && i < list.Count; i++)
                {
                    var item = list[i];
                    if (item.Key.Equals(key, StringComparison.OrdinalIgnoreCase) && item.Value is T)
                    {
                        t = (T)item.Value;
                        b = true;
                    }
                }
            }
            return t;
        }

        public static List<TypedItem> ToTypedItems<T>(this T t) where T : class
        {
            List<TypedItem> list = new List<TypedItem>();
            string fullName = t.GetType().FullName;

            foreach (var info in t.GetType().GetProperties())
            {
                if (info.PropertyType.IsPublic && info.CanRead)
                {
                    if ((info.PropertyType.IsValueType || info.PropertyType == typeof(string)))
                    {
                        TypedItem item = new TypedItem(info.Name, info.GetValue(t));
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public static object Get(this List<TypedItem> list, string key)
        {
            object o = null;
            bool b = false;
            if (list != null && list.Count > 0)
            {
                for (int i = 0; !b && i < list.Count; i++)
                {
                    var item = list[i];
                    if (item.Key.Equals(key, StringComparison.OrdinalIgnoreCase))
                    {
                        o = item.Value;
                        b = true;
                    }
                }
            }
            return o;
        }

        public static T To<T>(this List<TypedItem> list) where T : class, new()
        {
            T t = new T();
            foreach (var info in t.GetType().GetProperties())
            {
                string n = info.Name;
                if (list.ContainsKey(n))
                {
                    object o = list.Get(n);
                    info.SetValue(t, o);
                }
            }
            return t;
        }

        public static bool ContainsKey(this List<TypedItem> list, string key)
        {
            bool b = false;
            if (list != null && list.Count > 0)
            {
                foreach (var item in list.Where(x => x.Value != null))
                {

                    if (item.Key.Equals(key, StringComparison.OrdinalIgnoreCase))
                    {
                        b = true;
                        break;
                    }
                }
            }
            return b;
        }



        public static bool Contains(this ICriterion item, string key)
        {
            bool b = false;

            if (item != null && item.Items != null)
            {
                foreach (var typedItem in item.Items)
                {
                    if (typedItem.Key.Equals(key, StringComparison.OrdinalIgnoreCase))
                    {
                        b = true;
                        break;
                    }
                }
            }
            return b;
        }

        public static void Merge(this List<TypedItem> list, string key, object value)
        {
            List<TypedItem> swap = new List<TypedItem>();
            foreach (var item in list)
            {
                if (item.Key.Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    swap.Add(new TypedItem(key, value));
                }
                else
                {
                    swap.Add(item);
                }
            }
            list = swap;
        }

        public static void Accept(this IEnumerable<TypedItem> items, IeXtensibleVisitor visitor)
        {
            visitor.Visit(items);
        }
        public static void Accept<T>(this IEnumerable<TypedItem> items, T t, IeXtensibleVisitor<T> visitor) where T : class, new()
        {
            visitor.Visit(items);
            visitor.Visit(t);
        }

        public static void SetStrategyKeyValue(this ICriterion item, string strategyKey, string strategyValue)
        {
            Criterion criteria = item as Criterion;
            if (criteria != null)
            {
                criteria.AddItem(XFConstants.Application.StrategyKey, strategyKey);
                criteria.AddItem(strategyKey, strategyValue);
            }
        }

        public static bool ContainsStrategy(this ICriterion item)
        {
            string key = item.GetValue<string>(XFConstants.Application.StrategyKey);
            return !String.IsNullOrEmpty(key);
        }

        public static void AddItem(this ICriterion item, string key, object value)
        {
            Criterion criteria = item as Criterion;
            if (criteria != null)
            {
                if (criteria.Items == null)
                {
                    criteria.Items = new List<TypedItem>();
                }
            }
            criteria.Add(key, value);
        }

        public static string GetStrategyKey(this ICriterion item)
        {
            //string resolution = String.Empty;
            //string key = item.GetValue<string>(XFConstants.Application.StrategyKey);
            //if (!String.IsNullOrEmpty(key))
            //{
            //    resolution = item.GetValue<string>(key);
            //}
            //return resolution;
            return item.GetValue<string>(XFConstants.Application.StrategyKey);
        }

        public static void SetStrategyKey(this ICriterion item, string switchKey)
        {
            if (!item.Contains(XFConstants.Application.StrategyKey))
            {
                item.AddItem(XFConstants.Application.StrategyKey, switchKey);
            }
        }

        public static DateTime NextWeekDay(this DateTime date)
        {
            DateTime next = date.AddDays(1);
            int i = Convert.ToInt16(next.DayOfWeek);
            while (i == 0 | i == 6)
            {
                next = next.AddDays(1);
                i = Convert.ToInt16(next.DayOfWeek);
            }
            return next.Date;
        }

        public static string GetStringValue(this ICriterion criteria, string key)
        {
            string s = String.Empty;
            if (criteria.Items != null)
            {
                foreach (var item in criteria.Items)
                {
                    if (item.Key.Equals(key, StringComparison.OrdinalIgnoreCase))
                    {
                        s = item.Value.ToString();
                        break;
                    }
                }
            }
            return s;
        }

        public static T GetValueAs<T>(this IEnumerable<TypedItem> items, string key)
        {
            T t = default(T);
            bool b = false;

            if (items != null)
            {
                List<TypedItem> list = items.ToList();
                for (int i = 0; !b && i < list.Count; i++)
                {
                    if (list[i].Key.Equals(key, StringComparison.OrdinalIgnoreCase))
                    {
                        TypedItem item = list.First(x => x.Key.Equals(key, StringComparison.OrdinalIgnoreCase));

                        if (item != null)
                        {
                            try
                            {
                                t = (T)item.Value;
                            }
                            catch (Exception ex)
                            {
                                string s = ex.Message;
                            }
                        }
                        b = true;
                    }
                }
            }
            return t;
        }


        public static long ToUnixSeconds(this DateTimeOffset target)
        {
            DateTimeOffset dto = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
            return (long)(target - dto).TotalSeconds;
        }

        public static long ToUnixMilliseconds(this DateTimeOffset target)
        {
            DateTimeOffset dto = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
            return (long)(target - dto).TotalMilliseconds;
        }


        public static DataTable DirectoryFilesToDataTable(this string item)
        {
            DataTable dt = new DataTable();
            if (Directory.Exists(item))
            {
                var query = from s in Directory.GetFiles(item)
                            let fi = new FileInfo(s)
                            select new
                            {
                                Filepath = fi.FullName,
                                Filename = fi.Name,
                                Extension = fi.Extension,
                                Exists = fi.Exists,
                                Directory = fi.DirectoryName
                            };

                dt = query.ToDataTable();
            }
            dt.TableName = "Files";
            return dt;
        }



        public static DataTable ToDataTable<T>(this IEnumerable<T> source)
        {
            return new ObjectShredder<T>().Shred(source, null, null);
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> source,
                                                    DataTable table, LoadOption? options)
        {
            return new ObjectShredder<T>().Shred(source, table, options);
        }


        #region helper classes

        internal class ObjectShredder<T>
        {
            private FieldInfo[] _fi;
            private PropertyInfo[] _pi;
            private Dictionary<string, int> _ordinalMap;
            private Type _type;

            public ObjectShredder()
            {
                _type = typeof(T);
                _fi = _type.GetFields();
                _pi = _type.GetProperties();
                _ordinalMap = new Dictionary<string, int>();
            }

            public DataTable Shred(IEnumerable<T> source, DataTable table, LoadOption? options)
            {
                if (typeof(T).IsPrimitive)
                {
                    return ShredPrimitive(source, table, options);
                }


                if (table == null)
                {
                    table = new DataTable(typeof(T).Name);
                }

                // now see if need to extend datatable base on the type T + build ordinal map
                table = ExtendTable(table, typeof(T));

                table.BeginLoadData();
                using (IEnumerator<T> e = source.GetEnumerator())
                {
                    while (e.MoveNext())
                    {
                        if (options != null)
                        {
                            table.LoadDataRow(ShredObject(table, e.Current), (LoadOption)options);
                        }
                        else
                        {
                            table.LoadDataRow(ShredObject(table, e.Current), true);
                        }
                    }
                }
                table.EndLoadData();
                return table;
            }

            public DataTable ShredPrimitive(IEnumerable<T> source, DataTable table, LoadOption? options)
            {
                if (table == null)
                {
                    table = new DataTable(typeof(T).Name);
                }

                if (!table.Columns.Contains("Value"))
                {
                    table.Columns.Add("Value", typeof(T));
                }

                table.BeginLoadData();
                using (IEnumerator<T> e = source.GetEnumerator())
                {
                    Object[] values = new object[table.Columns.Count];
                    while (e.MoveNext())
                    {
                        values[table.Columns["Value"].Ordinal] = e.Current;

                        if (options != null)
                        {
                            table.LoadDataRow(values, (LoadOption)options);
                        }
                        else
                        {
                            table.LoadDataRow(values, true);
                        }
                    }
                }
                table.EndLoadData();
                return table;
            }

            public DataTable ExtendTable(DataTable table, Type type)
            {
                // value is type derived from T, may need to extend table.
                foreach (FieldInfo f in type.GetFields())
                {
                    if (!_ordinalMap.ContainsKey(f.Name))
                    {
                        DataColumn dc = table.Columns.Contains(f.Name) ? table.Columns[f.Name]
                            : table.Columns.Add(f.Name, f.FieldType);
                        _ordinalMap.Add(f.Name, dc.Ordinal);
                    }
                }
                foreach (PropertyInfo p in type.GetProperties())
                {
                    if (!_ordinalMap.ContainsKey(p.Name))
                    {
                        DataColumn dc = table.Columns.Contains(p.Name) ? table.Columns[p.Name]
                            : table.Columns.Add(p.Name, p.PropertyType);
                        _ordinalMap.Add(p.Name, dc.Ordinal);
                    }
                }
                return table;
            }

            public object[] ShredObject(DataTable table, T instance)
            {

                FieldInfo[] fi = _fi;
                PropertyInfo[] pi = _pi;

                if (instance.GetType() != typeof(T))
                {
                    ExtendTable(table, instance.GetType());
                    fi = instance.GetType().GetFields();
                    pi = instance.GetType().GetProperties();
                }

                Object[] values = new object[table.Columns.Count];
                foreach (FieldInfo f in fi)
                {
                    values[_ordinalMap[f.Name]] = f.GetValue(instance);
                }

                foreach (PropertyInfo p in pi)
                {
                    values[_ordinalMap[p.Name]] = p.GetValue(instance, null);
                }
                return values;
            }

        }

        #endregion
    }
}

