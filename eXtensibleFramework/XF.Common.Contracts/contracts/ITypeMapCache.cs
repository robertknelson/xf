// <copyright company="eXtensoft, LLC" file="ITypeMapCache.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;

    public interface ITypeMapCache
    {
        void Initialize();
        Type ResolveType<T>() where T : class, new();
        Type ResolveType(string key);

    }
}
