// <copyright file="IViewModelFactory.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    public interface IViewModelFactory<T, U>
        where T : class, new()
        where U : ViewModel<T>, new()
    {
        U Create(T t);
    }
}