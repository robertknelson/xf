using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF.Common
{
    public static class UserData
    {
        public static void Write<T>(T t) where T : class, new()
        {
            Write(t, false);
        }

        public static void Write<T>(T t, bool isClearText) where T : class, new()
        {
            string filepath = GenerateFilepath<T>(isClearText);
            if (isClearText)
            {
                GenericSerializer.WriteGenericItem<T>(t, filepath);
            }
            else
            {
                GenericSerializer.WriteGenericItemBinary<T>(t,filepath);
            }
        }



        public static T Read<T>() where T : class, new()
        {
            T t = default(T);
            bool isClearText = true;
            string filename = String.Empty;
            string s = GetModelName<T>().ToLower();
            var folderpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            DirectoryInfo directory = new DirectoryInfo(folderpath);
            if (directory.Exists)
            {
                bool b = false;
                var files = directory.GetFiles();
                for (int i = 0;!b && i < files.Count(); i++)
                {
                    var file = files[i];
                    string name = file.Name.ToLower();
                    string extension = file.Extension.ToLower();
                    if (name.Contains(s))
                    {
                        filename = name;
                        isClearText = extension.Equals(".xml", StringComparison.OrdinalIgnoreCase);
                        b = true;
                    }
                }
                if (b)
                {
                    string filepath = Path.Combine(folderpath, filename);
                    if (isClearText)
                    {
                        t = GenericSerializer.ReadGenericItem<T>(filepath);
                    }
                    else
                    {
                        t = GenericSerializer.ReadGenericItemBinary<T>(filepath);
                    }
                }
                
            }
            return t;
        }

        private static string GenerateFilepath<T>(bool isClearText)
        {
            string s = GetModelName<T>().ToLower();
            string ext = isClearText ? "xml" : "bin";
            string filename = String.Format("{0}.{1}", s, ext);
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename);
        }

        private static string GetModelName<T>()
        {
            return typeof(T).FullName;
        }

    }
}
