// <copyright company="eXtensoft, LLC" file="CredentialsManager.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace Arges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    public static class CredentialsManager
    {
        public static WindowsCredential ResolveCredentials(string externalIP)
        {
            WindowsCredential item = null;
            UserCredentials userCredentials = GetUserCredentials();
            bool b = false;

            for (int i = 0; !b && i < userCredentials.Credentials.Count; i++)
            {
                ServerCredentials cred = userCredentials.Credentials[i];
                var found = cred.Servers.FirstOrDefault(x => x.ExternalIP.Equals(externalIP));
                if (found != null)
                {
                    item = cred.Credential;
                    b = true;
                }
            }
            return item;
        }

        private static UserCredentials GetUserCredentials()
        {
            UserCredentials model = Application.Current.Properties[AppConstants.UserCredentials] as UserCredentials;
            if (model != null)
            {
                return model;
            }
            return null;
        }

        public static IEnumerable<ListItem> GetLookups()
        {
            UserCredentials creds = GetUserCredentials();
            List<ListItem> list = (from x in creds.Credentials
                                   select new ListItem() { Id = x.Credential.Id.ToString(), Text = x.Credential.ToString() }).ToList();
            return list;
        }
    }

}
