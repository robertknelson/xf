// <copyright file="IViewModel.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    public interface IViewModel
    {
        bool IsDirty { get; }

        bool MarkedForRemoval { get; }
    }
}