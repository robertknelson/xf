// <copyright file="DisplayItemObjectDataProvider.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;

    public class ProjectionObjectDataProvider
    {
        public string Key { get; set; }

        public object Data
        {
            get { return (!String.IsNullOrEmpty(Key)) ? ProjectionReadThroughCache.Instance.GetAll(Key) : null; }
        }
    }
}