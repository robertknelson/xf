// <copyright company="eXtensoft, LLC" file="ApiEndpointManager.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace XF.WebApi.Core
{
    using Common;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web.Hosting;
    using WebApi;
    public sealed class ApiEndpointManager : IEnumerable<IEndpointController>
    {
        #region local members
        private bool _IsInitialized = false;
        private List<IEndpointController> _OrderedControllers = null;
        #endregion

        #region properties
        [ImportMany(typeof(IEndpointController))]
        public List<IEndpointController> Controllers { get; set; }

        private List<Endpoint> _Endpoints = null;
        public IEnumerable<Endpoint> Endpoints
        {
            get
            {
                
                return _Endpoints;
            }
        }
        #endregion

        #region constructors
        public ApiEndpointManager() { }

        static ApiEndpointManager()
        {
            InitializeConfiguration();
        }

        private static void InitializeConfiguration()
        {
            // read in xml file if exists

        }
        #endregion

        public bool Initialize()
        {
           _IsInitialized = Controllers != null && Controllers.Count() > 0;

            List<Endpoint> list = new List<Endpoint>();
            int i = 1;
            foreach (var endpoint in this)
            {
                var item = new Endpoint()
                {
                    SortOrder = i++,
                    Id = endpoint.Id.ToString(),
                    Name = endpoint.Name,
                    Description = endpoint.Description,
                    RoutePattern = endpoint.RouteTablePattern,
                    WhitelistPattern = endpoint.WhitelistPattern,
                    Version = endpoint.Version
                };
                list.Add(item);
            }
             string filepath = HostingEnvironment.MapPath("~/app_data/api.endpoints.xml");
            FileInfo info = new FileInfo(filepath);
            if (!info.Exists)
            {

                GenericSerializer.WriteGenericList<Endpoint>(list, info.FullName);
                _Endpoints = list;
            }
            else
            {
            // IF endpoints came from existing, then order
                List<Endpoint> endpoints = GenericSerializer.ReadGenericList<Endpoint>(info.FullName);
                    _Endpoints = list;
            }





            return _IsInitialized;
        }

        IEnumerator<IEndpointController> IEnumerable<IEndpointController>.GetEnumerator()
        {
            if (!_IsInitialized)
            {
                yield return null;
            }
            else
            {
                foreach (IEndpointController controller in Controllers)
                {
                    yield return controller;
                }
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

}
