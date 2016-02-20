// <copyright company="eXtensoft, LLC" file="IRpcDatastoreService.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;

    public interface IRpcDatastoreService
    {
        U ExecuteRpc<T, U>(T model, ICriterion criterion, IRequestContext requestContext) where T : class, new();
    }
}

