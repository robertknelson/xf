// <copyright company="eXtensoft, LLC" file="IResponse_2.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{

    public interface IResponse<T, U> : IResponse<T> where T : class, new()
    {
        U ActionResult { get; set; }
    }
}
