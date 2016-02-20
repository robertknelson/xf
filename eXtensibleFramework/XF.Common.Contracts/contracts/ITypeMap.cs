// <copyright company="eXtensoft, LLC" file="ITypeMap.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;

    public interface ITypeMap
    {
        string Domain { get; }

        Type KeyType { get; }

        Type TypeResolution { get; }
    }
}