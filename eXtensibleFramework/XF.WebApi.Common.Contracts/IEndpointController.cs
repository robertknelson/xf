﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace XF.WebApi
{
    public interface IEndpointController
    {
        Guid Id { get; }
        string Name { get; }
        string Description { get; }
        void Register(HttpConfiguration config);
    }
}
