// <copyright company="eXtensoft, LLC" file="BindingTypeOption.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common.Wcf
{
    using System;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue", Justification = "BasicHttp is the default binding"), FlagsAttribute]
    public enum BindingTypeOptions
    {
        BasicHttp = 0,
        WsHttp = 1,
        Tcp = 2,
        NoSecurity = 4,
        MessageSecurity = 8,
        TransportSecurity = 16,
        TransportWithMessageCredential = 32
    }
}
