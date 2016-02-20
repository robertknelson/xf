// <copyright company="eXtensoft, LLC" file="IStatusCheck.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common.Wcf
{
    using System.ServiceModel;

    [ServiceContract(Namespace = "http://eXtensibleSolution/schemas/2014/04")]
    [ServiceKnownType(typeof(ListItem))]
    [ServiceKnownType(typeof(TypedItem))]
    [ServiceKnownType(typeof(StatusCheck))]
    public interface IStatusCheck
    {
        [OperationContract]
        StatusCheck ExecuteStatusCheck(StatusCheck item);
    }
}