// <copyright file="FileLoader`1.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;
    using System.IO;
    using System.Windows;
    using XF.Common;

    public class FileSystemLoader<T> where T : class, new()
    {
        #region properties

        public string FullFilepath { get; private set; }

        public string InitialDirectory { get; set; }

        public string Filter { get; set; }

        public string DefaultFileExtension { get; set; }

        public T Model { get; set; }

        public DateTime LoadedAt { get; set; }

        public bool IsLoaded { get; private set; }

        private Func<string, T> _Deserializer;

        public Func<string, T> Deserializer
        {
            get
            {
                if (_Deserializer == null)
                {
                    _Deserializer = Deserialize;
                }
                return _Deserializer;
            }
            set { _Deserializer = value; }
        }

        private Func<T> _Factory;

        public Func<T> Factory
        {
            get
            {
                if (_Factory == null)
                {
                    _Factory = CreateInstance;
                }
                return _Factory;
            }
        }

        #endregion properties

        #region events

        //public static event EventHandler<FileLoaderEventArgs> FileLoaded;

        #endregion events

        public bool Load()
        {
            string fullfilepath;
            T model;
            if (TryLoad(InitialDirectory, Filter, DefaultFileExtension, out model, out fullfilepath, Deserializer))
            {
                Model = model;
                FullFilepath = fullfilepath;
                InitialDirectory = fullfilepath.Substring(0, fullfilepath.LastIndexOf('\\'));
                LoadedAt = DateTime.Now;
                IsLoaded = true;
            }

            return IsLoaded;
        }

        public bool New()
        {
            bool b = false;
            if (!IsLoaded)
            {
                Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
                dialog.FileName = String.Format("", DefaultFileExtension);
                dialog.DefaultExt = DefaultFileExtension;
                dialog.InitialDirectory = InitialDirectory;
                Nullable<bool> result = dialog.ShowDialog();
                if (result != null && result.Value == true)
                {
                    FullFilepath = dialog.FileName;
                    Model = Factory.Invoke();
                    GenericSerializer.WriteGenericItem<T>(Model, FullFilepath);
                    b = true;
                }
            }
            return b;
        }

        public bool Save()
        {
            bool b = false;
            if (!IsLoaded)
            {
                Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
                dialog.FileName = String.Format("", DefaultFileExtension);
                dialog.DefaultExt = DefaultFileExtension;
                dialog.InitialDirectory = InitialDirectory;
                Nullable<bool> result = dialog.ShowDialog();
                if (result != null && result.Value == true)
                {
                    FullFilepath = dialog.FileName;
                    GenericSerializer.WriteGenericItem<T>(Model, FullFilepath);
                    b = true;
                }
            }
            else
            {
                GenericSerializer.WriteGenericItem<T>(Model, FullFilepath);
                b = true;
            }
            return b;
        }

        public static bool TryLoad(string initialDirectory, string filter, string defaultFileExtension, out T t, out string fullFilepath, Func<string, T> deserializer)
        {
            bool b = false;
            t = default(T);
            fullFilepath = String.Empty;

            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = filter;
            dialog.DefaultExt = defaultFileExtension;
            dialog.InitialDirectory = initialDirectory;
            Nullable<bool> result = dialog.ShowDialog();
            if (result == true)
            {
                fullFilepath = dialog.FileName;
                b = TryValidateCandidate(fullFilepath, out t, deserializer);
            }
            return b;
        }

        private static bool TryValidateCandidate(string candidatefilepath, out T t, Func<string, T> deserializer)
        {
            t = default(T);
            bool b = false;
            try
            {
                if (File.Exists(candidatefilepath))
                {
                    FileInfo info = new FileInfo(candidatefilepath);
                    t = deserializer(candidatefilepath);
                    b = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return b;
        }

        private static T Deserialize(string fullFilepath)
        {
            return GenericSerializer.ReadGenericItem<T>(fullFilepath);
        }

        private static T CreateInstance()
        {
            return Activator.CreateInstance<T>();
        }
    }
}