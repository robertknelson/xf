// <copyright file="GroupingViewModelcs.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System.ComponentModel;

    public class GroupingViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; }

        public string Key { get; set; }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion INotifyPropertyChanged

        public override string ToString()
        {
            return Title;
        }
    }
}