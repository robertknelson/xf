// <copyright file="ProjectionReadThroughCache.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using XF.Common;

    /// <summary>
    /// This class provides a client with locally cached dictionary
    /// of eXtensibleFramework Projections.  Projection Providers
    /// may register keyed delegates, typically at application start-up.
    /// The caller may request data-refresh through coercion.  The class
    /// is implemented as a Singleton.
    /// </summary>
    public class ProjectionReadThroughCache
    {
        #region singleton members

        public DateTime Start { get; set; }

        public static ProjectionReadThroughCache Instance { get; set; }

        #region constructors

        /// <summary>
        /// The static type constructor is invoked a single time
        /// for the lifetime of the app domain
        /// </summary>
        static ProjectionReadThroughCache()
        {
            Instance = new ProjectionReadThroughCache();
        }

        /// <summary>
        /// Presence of a private constructor and lack of
        /// a public constructor ensures that the class
        /// may not be instantiated by calling code
        /// </summary>
        private ProjectionReadThroughCache()
        {
            Start = DateTime.Now;
        }

        #endregion constructors

        #endregion singleton members

        #region local fields

        /// <summary>
        /// This field maintains a list of provider keys that
        /// enforce refresh of data on each client request for
        /// provider supplied data
        /// </summary>
        private List<string> _CoerceRefreshKeys = new List<string>();

        #endregion local fields

        #region properties

        #region DisplayItemProviders (Dictionary<string,Func<List<DisplayItem>))

        private Dictionary<string, Func<List<Projection>>> _DisplayItemProviders = new Dictionary<string, Func<List<Projection>>>();

        /// <summary>
        /// Gets or sets the Dictionary<string,Func<List<DisplayItem>) value
        /// for DisplayItemProviders.  This is the registry of DisplayItem Providers
        /// that make available their services to client code.  The client will
        /// call for data using the keys found in this dictionary
        /// </summary>
        /// <value> The Dictionary<string,Func<List<DisplayItem>) value.</value>

        public Dictionary<string, Func<List<Projection>>> DisplayItemProviders
        {
            get { return _DisplayItemProviders; }
            set
            {
                if (_DisplayItemProviders != value)
                {
                    _DisplayItemProviders = value;
                }
            }
        }

        #endregion DisplayItemProviders (Dictionary<string,Func<List<DisplayItem>))

        #endregion properties

        #region instance methods

        /// <summary>
        /// This method provides a refresh of cached
        /// data on an adhoc basis
        /// </summary>
        /// <param name="parameter"></param>
        public void CoerceRefresh(object parameter)
        {
            if (parameter != null)
            {
                string key = parameter.ToString().ToLower();

                if (!_CoerceRefreshKeys.Contains(key))
                {
                    Remove(parameter);
                    PullList(parameter);
                }
            }
        }

        /// <summary>
        /// This method provides data to the caller based on the key
        /// parameter.  If the data doesn't already exist locally,
        /// the registered provider delegate is invoked.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public List<Projection> GetAll(object parameter)
        {
            List<Projection> list = new List<Projection>();
            if (parameter != null)
            {
                string key = parameter.ToString().ToLower();

                if (_CoerceRefreshKeys.Contains(key))
                {
                    list = InvokeProviderService(parameter);
                }
                else if (!Application.Current.Resources.Contains(key))
                {
                    PullList(parameter);
                    list = Application.Current.Resources[key] as List<Projection>;
                }
                else
                {
                    list = Application.Current.Resources[key] as List<Projection>;
                }
            }
            return list;
        }

        /// <summary>
        /// This method allows Providers to register their data service.
        /// The default behavior is for data to be cached locally, not
        /// being refreshed on demand
        /// </summary>
        /// <param name="key"></param>
        /// <param name="provider"></param>
        public void RegisterProjectionProvider(string key, Func<List<Projection>> provider)
        {
            RegisterProjectionProvider(key, provider, false);
        }

        /// <summary>
        /// This method allows Providers to register their data service, and
        /// to inicate whether or not the data should be coercively refreshed
        /// on each request for data.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="provider"></param>
        /// <param name="coerceRefresh"></param>
        public void RegisterProjectionProvider(string key, Func<List<Projection>> provider, bool coerceRefresh)
        {
            if (!String.IsNullOrEmpty(key) && provider != null)
            {
                string providerkey = key.ToLower();
                if (!DisplayItemProviders.ContainsKey(providerkey.ToLower()))
                {
                    if (coerceRefresh)
                    {
                        _CoerceRefreshKeys.Add(providerkey);
                    }
                    DisplayItemProviders.Add(providerkey, provider);
                }
            }
        }

        #endregion instance methods

        #region helper methods

        private void Remove(object parameter)
        {
            if (parameter != null)
            {
                string key = parameter.ToString().ToLower();
                if (Application.Current.Resources.Contains(key))
                {
                    Application.Current.Resources.Remove(key);
                }
            }
        }

        private void PullList(object parameter)
        {
            if (parameter != null)
            {
                string key = parameter.ToString().ToLower();
                Application.Current.Resources.Add(key, InvokeProviderService(parameter));
            }
        }

        /// <summary>
        /// This method will invoke a Provider service for a
        /// given registered key.  Any error in the Provider
        /// code will be swallowed so as to not bring down
        /// the client.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private List<Projection> InvokeProviderService(object parameter)
        {
            List<Projection> list = new List<Projection>();
            if (parameter != null)
            {
                string key = parameter.ToString().ToLower();
                if (DisplayItemProviders.ContainsKey(key))
                {
                    try
                    {
                        list = DisplayItemProviders[key].Invoke();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return list;
        }

        #endregion helper methods
    }
}