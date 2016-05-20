// <copyright file="ProjectionDataProvider.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System.Collections.Generic;
    using XF.Common;

    /// <summary>
    /// This DataProvider is intended to be used declaratively
    /// in XAML code to provide keyed lists of DisplayItems for
    /// ComboBox dropdowns, in Value Converters for scenarios
    /// such as status code conversion to friendly text
    /// </summary>
    public class ProjectionDataProvider
    {
        /// <summary>
        /// This method is the primary way by which callers
        /// will request lookup lists
        /// </summary>
        /// <param name="parameter">The key for the list of
        /// DisplayItems</param>
        /// <returns></returns>
        public static List<Projection> GetAll(object parameter)
        {
            return ProjectionReadThroughCache.Instance.GetAll(parameter);
        }

        /// <summary>
        /// This method provides an override by which the caller
        /// may request a coercive refresh of any locally cached
        /// data for the given key
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="coerceRefresh"></param>
        /// <returns></returns>
        public static List<Projection> GetAll(object parameter, bool coerceRefresh)
        {
            if (coerceRefresh)
            {
                CoerceRefresh(parameter);
            }

            return GetAll(parameter);
        }

        /// <summary>
        /// This method simply coercively refreshes local
        /// cached data for the given key
        /// </summary>
        /// <param name="parameter"></param>
        public static void CoerceRefresh(object parameter)
        {
            ProjectionReadThroughCache.Instance.CoerceRefresh(parameter);
        }
    }
}