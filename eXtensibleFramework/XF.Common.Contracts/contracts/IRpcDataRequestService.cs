// <copyright company="eXtensoft, LLC" file="IRpcDataRequestService.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{

    public interface IRpcDataRequestService
    {
        IResponse<T, U> ExecuteRpc<T, U>(IRequest<T> request) where T : class, new();
    }
}
