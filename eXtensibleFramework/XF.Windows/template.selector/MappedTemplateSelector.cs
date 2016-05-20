// <copyright file="MappedTemplateSelector.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// This DataTemplateSelector uses a Convention-over-Configuration
    /// methodology to mapping ViewModels to DataTemplates
    /// The Convention is to follow a convention: [Model]ViewModel matches
    /// a DataTemplate with Key= [Model]DataTemplate
    ///
    /// This default behavior may be overridden by adding a mapping entry
    /// into the _DataTempalteMaps dictionary with the key as the ViewModel typename
    /// and the value being the DataTemplate Key
    /// </summary>
    public class MappedTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate template = null;
            if (item != null)
            {
                IDictionary<string, string> maps = Application.Current.Properties[XUXConstants.TemplateMaps] as IDictionary<string, string>;
                string s = item.GetType().Name;
                if (maps != null && maps.ContainsKey(s))
                {
                    string t = maps[s];
                    DataTemplate candidate = Application.Current.Resources[t] as DataTemplate;
                    if (candidate != null)
                    {
                        template = candidate;
                    }
                }
                else
                {
                    string t = s.Replace("ViewModel", "DataTemplate");
                    DataTemplate candidate = Application.Current.Resources[t] as DataTemplate;
                    if (candidate != null)
                    {
                        template = candidate;
                    }
                }
            }
            return template;
        }
    }
}