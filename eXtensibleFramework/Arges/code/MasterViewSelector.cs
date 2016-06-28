// <copyright company="eXtensoft, LLC" file="MasterViewSelector.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace Arges
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    public sealed class MasterViewSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate template = null;
            MasterViewOption option = MasterViewOption.Simple;
            if (item != null && Enum.TryParse<MasterViewOption>(item.ToString(), out option))
            {
                string templateName = String.Empty;
                switch (option)
                {
                    case MasterViewOption.None:
                        break;
                    case MasterViewOption.Simple:
                        templateName = "SimpleMasterDataTemplate";
                        break;
                    case MasterViewOption.Grouped:
                        templateName = "GroupedMasterDataTemplate";
                        break;
                    case MasterViewOption.Hierarchical:
                        templateName = "HierarchicalMasterDataTemplate";
                        break;
                    default:
                        break;
                }
                DataTemplate candidate = Application.Current.Resources[templateName] as DataTemplate;
                if (candidate != null)
                {
                    template = candidate;
                }
            }

            return template;
        }
    }

}
