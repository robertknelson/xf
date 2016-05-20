// <copyright company="eXtensoft, LLC" file="ServerGroupingViewModel.cs">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace Arges
{

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using XF.Windows.Common;

    public sealed class ServerGroupingViewModel : GroupingViewModel
    {
        private ObservableCollection<ServerViewModel> _Items;
        public ObservableCollection<ServerViewModel> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

        public ServerGroupingViewModel(string title, IEnumerable<ServerViewModel> items)
        {
            Title = title;
            _Items = new ObservableCollection<ServerViewModel>(items);
        }

    }

}
