// <copyright company="eXtensoft, LLC" file="TraceEventTypeOption.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;
    public enum TraceEventTypeOption
    {
        None = 0,
        Critical = 1,
        Error = 2,
        Warning = 4,
        Information = 8,
        Verbose = 16,
        Start = 256,
        Stop = 512,
        Suspend = 1024,
        Resume = 2048,
        Transfer = 4096,
    }

}
