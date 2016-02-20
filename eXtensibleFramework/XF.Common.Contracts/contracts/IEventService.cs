// <copyright company="eXtensoft, LLC" file="IEventService.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract(Namespace = "http://eXtensoft/2014/04")]
    [ServiceKnownType(typeof(TypedItem))]
    [ServiceKnownType(typeof(EventTypeOption))]
    public interface IEventService
    {
        [OperationContract]
        void Write(EventTypeOption option, List<TypedItem> items);
    }

}
