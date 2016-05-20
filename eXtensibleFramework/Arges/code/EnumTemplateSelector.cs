// <copyright company="eXtensoft, LLC" file="MasterViewTemplateSelector.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace Arges
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;

    public class EnumTemplateSelector : DataTemplateSelector
    {
        public Enum SelectFrom { get;set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate template = null;
            if (item != null && item.GetType().IsEnum)
            {
                string t = string.Format("{0}{1}", item.ToString(),"DataTemplate");
                DataTemplate candidate = Application.Current.Resources[t] as DataTemplate;
                if (candidate != null)
                {
                    template = candidate;
                }
            }
            return template;
        }
    }

}
