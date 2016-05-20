// <copyright file="WeeksInMonth.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XAF.Model
{
    using System;

    [FlagsAttribute]
    public enum WeeksInMonth
    {
        None = 0,
        First = 1,
        Second = 2,
        Third = 4,
        Fourth = 8,
        Fifth = 16
    }
}