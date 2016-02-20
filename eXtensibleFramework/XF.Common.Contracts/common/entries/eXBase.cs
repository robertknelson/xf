// <copyright company="eXtensoft LLC" file="eXBase.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.Common
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;


    [Serializable]
    [DataContract(Namespace = "http://eXtensoft/schemas/2016/04")]
    public abstract partial class eXBase 
    {

        #region properties

        private string createdAt;
        public string CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

        [DataMember]
        public string ApplicationKey { get; set; }

        [DataMember]
        public string Zone { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public DateTimeOffset Tds { get; set; }

        [DataMember]
        public IEnumerable<TypedItem> Items { get; set; }

        #endregion properties


    }
}
