// <copyright company="eXtensoft, LLC" file="ICacheable_1.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;

    public interface ICacheable<T> where T : class, new()
    {
        ICache Cache { set; }
    }
}
