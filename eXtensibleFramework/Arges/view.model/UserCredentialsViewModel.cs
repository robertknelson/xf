// <copyright company="eXtensoft, LLC" file="UserCredentialsViewModel.cs">
// Copyright © 2016 All Right Reserved
// </copyright>



namespace Arges
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using XF.Windows.Common;



    public class UserCredentialsViewModel : ViewModel<UserCredentials>
    {
        #region Display (string)

        /// <summary>
        /// Gets or sets the string value for Display
        /// </summary>
        /// <value> The string value.</value>

        public string Display
        {
            get { return (String.IsNullOrEmpty(Model.Display)) ? String.Empty : Model.Display; }
            set
            {
                if (Model.Display != value)
                {
                    Model.Display = value;
                    OnPropertyChanged("Display");
                    IsDirty = true;
                }
            }
        }

        #endregion

        #region LastUpdatedAt (DateTime)

        /// <summary>
        /// Gets or sets the DateTime value for LastUpdatedAt
        /// </summary>
        /// <value> The DateTime value.</value>

        public DateTime LastUpdatedAt
        {
            get { return Model.LastUpdatedAt; }
            set
            {
                if (Model.LastUpdatedAt != value)
                {
                    Model.LastUpdatedAt = value;
                    OnPropertyChanged("LastUpdatedAt");
                    IsDirty = true;
                }
            }
        }

        #endregion

        public ObservableCollection<ServerCredentialsViewModel> Credentials { get; set; }

        public UserCredentialsViewModel(UserCredentials model)
        {
            Model = model;

            Credentials = new ObservableCollection<ServerCredentialsViewModel>(from x in model.Credentials select new ServerCredentialsViewModel(x));
            Credentials.CollectionChanged += Credentials_CollectionChanged;
        }

        private void Credentials_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    var vm = item as ServerCredentialsViewModel;
                    if (vm != null)
                    {
                        Model.Credentials.Add(vm.Model);
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    var vm = item as ServerCredentialsViewModel;
                    if (vm != null)
                    {
                        Model.Credentials.Remove(vm.Model);
                    }
                }
            }
        }
    }
}

