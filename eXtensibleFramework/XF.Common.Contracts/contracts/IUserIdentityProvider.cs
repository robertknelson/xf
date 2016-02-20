// <copyright company="eXtensoft, LLC" file="IUserIdentityProvider.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{

    public interface IUserIdentityProvider
    {
        string Username { get; }

        string Culture { get; }

        string UICulture { get; }
    }
}
