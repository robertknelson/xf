// <copyright file="PropertyValidator.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;

    public class PropertyValidator
    {
        #region propertys

        public string PropertyName { get; private set; }

        public Func<string> Executor { get; private set; }

        #endregion propertys

        #region constructors

        public PropertyValidator()
        {
        }

        public PropertyValidator(string propertyName, Func<string> executor)
        {
            PropertyName = propertyName;
            Executor = executor;
        }

        #endregion constructors
    }
}