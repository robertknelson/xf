// <copyright company="eXtensoft, LLC" file="IRpcHandler_1.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;
    public interface IRpcHander<T> : ITypeMap where T : class, new()
    {
        IContext Context { get; set; }

        U Execute<U>(T t, ICriterion criterion, IContext context);
    }
}

