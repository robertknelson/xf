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
        private List<IEndpointController> _OrderedControllers = new List<IEndpointController>();
        #endregion

        #region properties
        [ImportMany(typeof(IEndpointController))]
        public List<IEndpointController> Controllers { get; set; }

        public bool IsDirty { get; set; }

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
            int i = 1;
            if (_IsInitialized)
            {
                List<Endpoint> list = new List<Endpoint>();

                 string filepath = HostingEnvironment.MapPath("~/app_data/api.endpoints.xml");
                FileInfo info = new FileInfo(filepath);
                if (!info.Exists)
                {
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

                    GenericSerializer.WriteGenericList<Endpoint>(list, info.FullName);
                }
                else
                {
                    // IF endpoints came from existing, then order
                    List<Guid> burned = new List<Guid>();
                    List<Endpoint> endpoints = GenericSerializer.ReadGenericList<Endpoint>(info.FullName);
                    foreach (Endpoint orderedEndpoint in endpoints)
                    {
                        Guid g = new Guid(orderedEndpoint.Id);
                        var found = Controllers.Find(x => x.Id.Equals(g));
                        if (found != null)
                        {
                            burned.Add(g);
                            _OrderedControllers.Add(found);
                        }
                    }
                    foreach (var controller in Controllers)
                    {
                        if (!burned.Contains(controller.Id))
                        {
                            _OrderedControllers.Add(controller);
                        }
                    }
                    foreach (var endpoint in _OrderedControllers)
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
                    GenericSerializer.WriteGenericList<Endpoint>(list, info.FullName);
                }

                _Endpoints = list;
            }
            return _IsInitialized;
        }

        public void SaveChanges() {
            if (IsDirty)
            {
                string filepath = HostingEnvironment.MapPath("~/app_data/api.endpoints.xml");
                GenericSerializer.WriteGenericList<Endpoint>(_Endpoints, filepath);
                IsDirty = false;
            }

        }

        IEnumerator<IEndpointController> IEnumerable<IEndpointController>.GetEnumerator()
        {
            if (!_IsInitialized)
            {
                yield return null;
            }
            else if (_OrderedControllers != null)
            {
                foreach (IEndpointController controller in _OrderedControllers)
                {
                    yield return controller;
                }
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

        public void Swap(Guid xId, Guid yId)
        {
            Endpoint xEndpoint = null;
            Endpoint yEndpoint = null;

            string xid = xId.ToString();
            string yid = yId.ToString();
            List<Endpoint> list = new List<Endpoint>();
            foreach (var endpoint in Endpoints)
            {
                if (!endpoint.Id.Equals(xid) && !endpoint.Id.Equals(yid))
                {
                    Endpoint item = endpoint;
                    list.Add(item);
                }
                else if(endpoint.Id.Equals(xid))
                {
                    Endpoint item = endpoint;
                    xEndpoint = item;
                }
                else if(endpoint.Id.Equals(yid))
                {
                    yEndpoint = endpoint;
                    list.Add(yEndpoint);
                    list.Add(xEndpoint);
                    IsDirty = true;
                }
            }
            _Endpoints = list;
        }
    }

}
