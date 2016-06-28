// <copyright company="eXtensoft, LLC" file="Bootstrapper.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace Arges
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using XF.Common;
    using XF.Windows.Common;
    public static class Bootstrapper
    {
        public static void Start()
        {

            InitializeUserData();
            InitializeImageMaps();
            InitializeModelService();
            InitializeWorkspace();
            InitializeOverlayManager();
            InitializeStateMachine();
            InitializeSettings();

        }

        private static void InitializeWorkspace()
        {
            IModelRequestService svc = Application.Current.Properties[AppConstants.ModelRequestService] as IModelRequestService;
            var response = svc.GetAll<Cyclops.Selection>(null);
            if (response.IsOkay)
            {
                Workspace w = new Workspace(response);
                var creds = System.Windows.Application.Current.Properties[AppConstants.UserCredentialsViewModel] as UserCredentialsViewModel;
                WorkspaceViewModel vm = new WorkspaceViewModel(w) {  Service = svc, Credentials = creds};
                Application.Current.Properties[AppConstants.Workspace] = w;
                System.Windows.Application.Current.Properties[AppConstants.WorkspaceViewModel] = vm;
            }
        }

        private static void InitializeUserData()
        {
            var found = UserData.Read<UserCredentials>();
            if (found == null)
            {
                found = new UserCredentials() { Credentials = new List<ServerCredentials>(), Display = Environment.UserName, LastUpdatedAt = DateTime.Now };
                List<WindowsServer> ls = new List<WindowsServer>();
                var ws = new WindowsServer() {  GroupName = "grpName", Master = "master", ServerId = 6, ExternalIP = "162.209.16.190" , };
                ls.Add(ws);
                found.Credentials.Add(new ServerCredentials() { Credential = new WindowsCredential() { Name = "MyDomain", Domain = Environment.UserDomainName, Username = Environment.UserName, Password = "pass@word!", Id = Guid.NewGuid() }, Servers = ls });

                UserData.Write<UserCredentials>(found, true);
                found = UserData.Read<UserCredentials>();
            }
            if (found != null)
            {
                System.Windows.Application.Current.Properties[AppConstants.UserCredentials] = found;
                var vm = new UserCredentialsViewModel(found);
                System.Windows.Application.Current.Properties[AppConstants.UserCredentialsViewModel] = vm;
            }
        }


        private static void InitializeImageMaps()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            //list.Add(new Tuple<string, string>("NoProperties", "images/no.properties.png"));
            //list.Add(new Tuple<string, string>("Properties", "images/properties.png"));
            //list.Add(new Tuple<string, string>("None", "images/circle.red.png"));
            //list.Add(new Tuple<string, string>("Connector", "images/intrinsic.connector.png"));
            //list.Add(new Tuple<string, string>("Node", "images/intrinsic.node.png"));
            //list.Add(new Tuple<string, string>("Plane", "images/intrinsic.plane.png"));
            //list.Add(new Tuple<string, string>("resource/url", "images/content.url.png"));
            //list.Add(new Tuple<string, string>("application/vnd.ms-excel", "images/content.msexcel.png"));
            //list.Add(new Tuple<string, string>("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "images/content.msexcel.png"));
            //list.Add(new Tuple<string, string>("text/xml", "images/content.xml.png"));
            //list.Add(new Tuple<string, string>("application/msword", "images/content.msword.png"));
            //list.Add(new Tuple<string, string>("application/vnd.openxmlformats-officedocument.wordprocessingml.document", "images/content.msword.png"));
            //list.Add(new Tuple<string, string>("text/snippet", "images/content.text.png"));
            //list.Add(new Tuple<string, string>("text/plain", "images/content.snippet.png"));
            //list.Add(new Tuple<string, string>("image/bmp", "images/content.image.png"));
            //list.Add(new Tuple<string, string>("image/gif", "images/content.image.png"));
            //list.Add(new Tuple<string, string>("image/png", "images/content.image.png"));
            //list.Add(new Tuple<string, string>("image/tiff", "images/content.image.png"));
            //list.Add(new Tuple<string, string>("image/jpeg", "images/content.image.png"));
            //list.Add(new Tuple<string, string>("Recent", "images/circle.orange.png"));
            //list.Add(new Tuple<string, string>("None", "images/circle.gray.png"));
            //list.Add(new Tuple<string, string>("Favorite", "images/circle.green.png"));
            //list.Add(new Tuple<string, string>("application/pdf", "images/content.pdf.png"));
            list.Add(new Tuple<string, string>("Server", "images/circle.black.png"));
            list.Add(new Tuple<string, string>("grouping-server", "images/circle.blue.png"));
            //list.Add(new Tuple<string, string>("presentationstrategy.grouping", "images/circle.brown.png"));
            list.Add(new Tuple<string, string>("Servers", "images/circle.green.png"));
            list.Add(new Tuple<string, string>("App", "images/circle.red.png"));


            //list.Add(new Tuple<string, string>(AppConstants.STATUSACTIVE, "images/status.active.png"));
            //list.Add(new Tuple<string, string>(AppConstants.STATUSINACTIVE, "images/status.inactive.png"));

            //list.Add(new Tuple<string, string>(AppConstants.TRUE, "images/check.green.png"));
            //list.Add(new Tuple<string, string>(AppConstants.FALSE, "images/x.red.png"));


            Application.Current.Properties[XUXConstants.ImageMaps] = list;
        }
        private static void InitializeModelService()
        {
            //IModelRequestService service = new XF.Common.Wcf.WcfModelRequestService();
            IModelRequestService service = new PassThroughModelRequestService(
                        new DataRequestService(new XF.DataServices.ModelDataGatewayDataService())
                        );
            Application.Current.Properties[AppConstants.ModelRequestService] = service;
        }

        private static void InitializeOverlayManager()
        {
            OverlayManager overlay = new OverlayManager();
            Application.Current.Properties[AppConstants.OverlayManager] = overlay;
        }

        private static void InitializeStateMachine()
        {
            StateMachine machine = new StateMachine(System.Xml.Linq.XDocument.Parse(Resources.Arges_StateMachine));
            Application.Current.Properties[AppConstants.StateManager] = new StateManager()
            {
                Machine = machine
            };
        }
        private static void InitializeSettings()
        {
            string s = System.Reflection.Assembly.GetExecutingAssembly().Location;
            FileInfo info = new FileInfo(s);

            Application.Current.Properties[AppConstants.Settings.CurrentDirectory] = info.Directory.FullName;
        }
    }

}
