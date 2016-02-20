// <copyright company="eXtensoft, LLC" file="IRequestContext.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{
    public interface IRequestContext : IContext
    {
        string InstanceIdentifier { get; }
        void SetMetric(string scope, string key, object value);
        bool HasError();
    }

}
