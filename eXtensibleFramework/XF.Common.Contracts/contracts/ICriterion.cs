// <copyright company="eXtensoft, LLC" file="ICriterion.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System.Collections.Generic;

    public interface ICriterion
    {
        T GetValue<T>(string key);

        IEnumerable<TypedItem> Items { get; }
    }

}
