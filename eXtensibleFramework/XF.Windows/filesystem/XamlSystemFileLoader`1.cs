// <copyright file="XamlFileLoader`1.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;
    using System.Windows.Input;
    using XF.Common;

    public sealed class XamlFileLoader<T> : FileSystemLoader<T> where T : class, new()
    {
        #region ICommands

        private ICommand _LoadCommand;

        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new RelayCommand(
                        param => LocalLoad(),
                        param => this.CanLoad());
                }
                return _LoadCommand;
            }
        }

        private ICommand _SaveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new RelayCommand(
                        param => LocalSave(),
                        param => this.CanSave());
                }
                return _SaveCommand;
            }
        }

        private ICommand _NewCommand;

        public ICommand NewCommand
        {
            get
            {
                if (_NewCommand == null)
                {
                    _NewCommand = new RelayCommand(
                        param => LocalNew(),
                        param => this.CanNew());
                }
                return _NewCommand;
            }
        }

        #endregion ICommands

        #region events

        public event EventHandler<FileLoaderEventArgs<T>> OnFileLoaded;

        public event EventHandler<FileLoaderEventArgs<T>> OnFileSaved;

        public event EventHandler<FileLoaderEventArgs<T>> OnFileBeginSave;


        #endregion events

        public XamlFileLoader()
        {
        }

        public XamlFileLoader(string workingDirectory)
        {
            InitialDirectory = workingDirectory;
        }

        #region helper methods

        private bool CanLoad()
        {
            return true;
        }

        private bool CanSave()
        {
            return true;
        }

        private bool CanNew()
        {
            return true;
        }

        private void LocalLoad()
        {
            if (base.Load())
            {
                FileLoaderEventArgs<T> args = new FileLoaderEventArgs<T>(FullFilepath, base.Model);
                EventsBroker.Fire(OnFileLoaded, this, args);
            }
        }

        private void LocalSave()
        {
            FileLoaderEventArgs<T> args = new FileLoaderEventArgs<T>(FullFilepath, base.Model);
            EventsBroker.Fire(OnFileBeginSave, this, args);

            if (base.Save())
            {
                FileLoaderEventArgs<T> args2 = new FileLoaderEventArgs<T>(FullFilepath, base.Model);
                EventsBroker.Fire(OnFileSaved, this, args2);
            }
        }

        private void LocalNew()
        {
            if (base.New())
            {
                FileLoaderEventArgs<T> args = new FileLoaderEventArgs<T>(FullFilepath, base.Model);
                EventsBroker.Fire(OnFileLoaded, this, args);
            }
        }

        #endregion helper methods
    }
}