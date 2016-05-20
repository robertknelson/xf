// <copyright file="FileLoaderEventArgs.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;

    public sealed class FileLoaderEventArgs<T> : EventArgs
    {
        public string FullFilepath { get; private set; }

        public T Model { get; private set; }

        public FileLoaderEventArgs(string fullFilepath, T t)
        {
            FullFilepath = fullFilepath;
            Model = t;
        }
    }
}