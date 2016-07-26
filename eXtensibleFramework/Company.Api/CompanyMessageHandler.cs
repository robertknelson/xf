using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Api
{
    public class CompanyMessageHandler : DelegatingHandler
    {

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {


            Task<HttpResponseMessage> task = base.SendAsync(request, cancellationToken);
            return task;
        }


    }
}
