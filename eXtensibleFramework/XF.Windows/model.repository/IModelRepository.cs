// <copyright file="IModelRepository.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using XF.Common;

    public interface IModelRepository
    {
        IModelService Service { get; set; }
    }
}