// <copyright company="eXtensoft, LLC" file="IModedDataGatewayInitializable.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;
    public interface IModelDataGatewayInitializeable
    {
        void Initialize<T>(ModelActionOption option, IContext context, T t, ICriterion criterion, ResolveDbKey<T> dbkeyResolver) where T : class, new();
    }

    public delegate string ResolveDbKey<T>(IContext context);
}