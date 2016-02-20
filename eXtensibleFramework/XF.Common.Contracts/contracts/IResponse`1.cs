// <copyright company="eXtensoft, LLC" file="IResponse_1.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System.Collections.Generic;
    using System.Data;


    public interface IResponse<T> : IEnumerable<T>
    {
        bool IsOkay { get; }

        T Model { get; }

        RequestStatus Status { get; }

        IEnumerable<IProjection> Display { get; }

        DataSet Data { get; }

    }

}
