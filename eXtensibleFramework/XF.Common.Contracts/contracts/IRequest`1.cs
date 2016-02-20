﻿// <copyright company="eXtensoft, LLC" file="IRequest_1.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;


    public interface IRequest<T>
    {
        string Verb { get; set; }

        T Model { get; set; }

        IEnumerable<T> Content { get; set; }

        ICriterion Criterion { get; }

        IEnumerable<IProjection> Display { get; set; }

        DataSet Data { get; set; }
    }
}

