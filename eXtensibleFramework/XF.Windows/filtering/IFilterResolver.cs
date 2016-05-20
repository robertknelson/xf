// <copyright file="IFilterResolver.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System.Collections.Generic;

    public interface IFilterResolver
    {
        List<FilterItem> Filters { get; set; }

        bool Resolve(List<FilterItem> selectedFilters, object item);
    }
}