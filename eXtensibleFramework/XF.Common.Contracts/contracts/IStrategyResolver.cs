// <copyright company="eXtensoft, LLC" file="IStrategyResolver.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;

    public interface IStrategyResolver
    {
        string Resolve(params string[] args);
    }
}
