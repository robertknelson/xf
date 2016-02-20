// <copyright company="eXtensoft, LLC" file="StatusCheckServiceClient.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common.Wcf
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.ServiceModel;

    public sealed class StatusCheckServiceClient
    {
        public StatusCheck ExecuteStatusCheck(string endpointName = "default")
        {
            StatusCheck item = StatusCheck.GenerateDefault();
            StatusCheck result = null;
            try
            {
                using (ChannelFactory<IStatusCheck> factory = new ChannelFactory<IStatusCheck>(endpointName))
                {
                    IStatusCheck proxy = factory.CreateChannel();
                    result = proxy.ExecuteStatusCheck(item);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;

        }
    }
}

