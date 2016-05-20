// <copyright file="PropertyValidatorCollection.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;
    using System.Collections.ObjectModel;

    public class PropertyValidatorCollection : KeyedCollection<string, PropertyValidator>
    {
        protected override string GetKeyForItem(PropertyValidator item)
        {
            return item.PropertyName;
        }

        public void AddValidator(string propertyName, Func<string> executor)
        {
            Add(new PropertyValidator(propertyName, executor));
        }
    }
}