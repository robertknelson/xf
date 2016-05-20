// <copyright file="HierarchicalViewModel.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    public interface IHierarchicalViewModel
    {
        bool IsExpanded { get; set; }

        bool IsSelected { get; set; }

        IHierarchicalViewModel Master { get; set; }
    }
}