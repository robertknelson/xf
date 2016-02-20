// <copyright company="eXtensoft, LLC" file="IConfigStrategyResolver.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;
    public interface IConfigStrategyResolver
    {
        void Initialize(eXtensibleStrategySectionGroup sectionGroup);

        string Resolve<T>(IContext context) where T : class, new();

        bool IsInitialized { get; }

    }

}
