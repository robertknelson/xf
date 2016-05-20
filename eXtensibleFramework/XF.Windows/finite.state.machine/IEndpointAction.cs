// <copyright file="IEndpointAction.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    public interface IEndpointAction
    {
        EndpointOption Endpoint { get; set; }

        void Execute();
    }
}