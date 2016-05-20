// <copyright file="ModelRepository'2.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Input;
    using XF.Common;

    /// <summary>
    /// This class implements the Repository Pattern (Fowler http://martinfowler.com/eaaCatalog/repository.html),
    /// and facilitates databinding with XAML based UXs.
    /// </summary>
    /// <typeparam name="T">Any Model that implements SmartCare.Framework.Common.IIdentify</typeparam>
    /// <typeparam name="U">Any ViewModel that inherits from SmartCare.Framework.UX.ViewModel"/></typeparam>
    public class ModelRepository<T, U> : INotifyPropertyChanged, IModelRepository
        where T : class, new()
        where U : ViewModel<T>, new()
    {
        #region local fields

        private List<T> models = null;

        #endregion local fields

        #region properties

        #region save delegate

        public Action RefreshAction { get; set; }

        #endregion save delegate

        #region filtering criteria

        /// <summary>
        /// This property is the criteria that will be passed to
        /// the ModelService ReadList operation
        /// </summary>
        public ICriterion Criteria { get; set; }

        #endregion filtering criteria

        #region AutoRefresh (bool)

        private bool _AutoRefresh = true;

        /// <summary>
        /// Gets or sets the bool value for AutoRefresh
        /// </summary>
        /// <value> The bool value.</value>
        public bool AutoRefresh
        {
            get { return _AutoRefresh; }
            set
            {
                if (_AutoRefresh != value)
                {
                    _AutoRefresh = value;
                }
            }
        }

        #endregion AutoRefresh (bool)

        #region IModelRepository Members

        /// <summary>
        /// This is the local reference to the Model Service provided
        /// by the hosting application
        /// </summary>
        public IModelService Service { get; set; }

        #endregion IModelRepository Members

        #region ReadCommand(ICommand)

        private ICommand _ReadCommand;

        public ICommand ReadCommand
        {
            get
            {
                if (_ReadCommand == null)
                {
                    _ReadCommand = new RelayCommand(
                        param => this.Read());
                }
                return _ReadCommand;
            }
        }

        #endregion ReadCommand(ICommand)

        #region SaveCommand (ICommand)

        private ICommand _SaveCommand;

        /// <summary>
        /// Gets or sets the ICommand value for SaveCommand
        /// </summary>
        /// <value> The ICommand value.</value>
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new RelayCommand(
                        param => this.Save(),
                        param => this.CanSave());
                }
                return _SaveCommand;
            }
        }

        #endregion SaveCommand (ICommand)

        #region ReadListCommand (ICommand)

        private ICommand _ReadListCommand;

        /// <summary>
        /// Gets or sets the ICommand value for FetchCommand
        /// </summary>
        /// <value> The ICommand value.</value>
        public ICommand ReadListCommand
        {
            get
            {
                if (_ReadListCommand == null)
                {
                    _ReadListCommand = new RelayCommand(
                        param => this.ReadList());
                }
                return _ReadListCommand;
            }
        }

        #endregion ReadListCommand (ICommand)

        #region ClearCommand (ICommand)

        private ICommand _ClearCommand;

        /// <summary>
        /// Gets or sets the ICommand value for ClearCommand
        /// </summary>
        /// <value> The ICommand value.</value>
        public ICommand ClearCommand
        {
            get
            {
                if (_ClearCommand == null)
                {
                    _ClearCommand = new RelayCommand(
                        param => this.Clear()
                        );
                }
                return _ClearCommand;
            }
        }

        #endregion ClearCommand (ICommand)

        #region InsertCommand (ICommand)

        private ICommand _InsertCommand;

        /// <summary>
        /// Gets or sets the ICommand value for AddCommand
        /// </summary>
        /// <value> The ICommand value.</value>
        public ICommand AddCommand
        {
            get
            {
                if (_InsertCommand == null)
                {
                    _InsertCommand = new RelayCommand(
                        param => this.Insert(),
                        param => this.CanInsert()
                            );
                }
                return _InsertCommand;
            }
        }

        #endregion InsertCommand (ICommand)

        #region ResetCommand (ICommand)

        private ICommand _ResetCommand;

        /// <summary>
        /// Gets or sets the ICommand value for ResetCommand
        /// </summary>
        /// <value> The ICommand value.</value>
        public ICommand ResetCommand
        {
            get
            {
                if (_ResetCommand == null)
                {
                    _ResetCommand = new RelayCommand(
                        param => this.ResetItem()
                        );
                }
                return _ResetCommand;
            }
        }

        #endregion ResetCommand (ICommand)

        #region Items

        private ReadOnlyObservableCollection<U> _Items;

        /// <summary>
        /// This is the collection of ViewModels to which a XAML based UX can bind
        /// </summary>
        public ReadOnlyObservableCollection<U> Items
        {
            get { return _Items; }
            private set
            {
                if (_Items != value)
                {
                    _Items = value;
                    OnPropertyChanged("Items");
                }
            }
        }

        #endregion Items

        #region Item

        /// <summary>
        /// This is a single ViewModel to which a XAML based UX can bind, typically
        /// used for adding new models to the application
        /// </summary>
        public U Item { get; set; }

        #endregion Item

        #endregion properties

        #region repository delegates

        /// <summary>
        /// This is the hook that allows the UX code to provide criteria that implements
        /// ICriterion to be used in the Model Service's Read operation
        /// </summary>
        public Func<ICriterion> GenerateReadCriterion;

        /// <summary>
        /// This is the hook that allows UX code to provide criteria that implements
        /// ICriterion to be used in the Model Service's ReadList operation
        /// </summary>
        public Func<ICriterion> GenerateReadListCriterion;

        /// <summary>
        /// This is the hook that allows UX code to initialize a Model with
        /// the desired property values
        /// </summary>
        public Action<T> InitializeModel;

        #endregion repository delegates

        #region instance methods

        /// <summary>
        /// Provides a default implementation for obtaining the ID of a model.
        /// This default assumes an ID of type Integer.  If a model's ID is
        /// not an integer, this method should be overridden.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual ICriterion GetModelCriterion(T item)
        {
            //ICriterion criteria = new Criterion(item.Id);
            //return criteria;
            return null;
        }

        public void Read()
        {
            Item = null;
            if (GenerateReadCriterion != null)
            {
                ICriterion criterion = GenerateReadCriterion();
                T model = Service.Get<T>(criterion);
                IViewModelFactory<T, U> factory = null;
                if (typeof(IViewModelFactory<T, U>).IsAssignableFrom(typeof(U)))
                {
                    factory = new U() as IViewModelFactory<T, U>;
                }
                Item = (factory == null) ? new U() { } : factory.Create(model);
            }
        }

        /// <summary>
        /// This method executes UX Criteria producing code if extant,
        /// executes the ModelService's ReadList operation, and generates
        /// a collection of U (ViewModel).
        /// </summary>
        public void ReadList()
        {
            models = null;
            Items = null;
            ICriterion criterion = Criteria;
            if (GenerateReadListCriterion != null)
            {
                criterion = GenerateReadListCriterion();
            }
            models = Service.GetAll<T>(criterion).ToList();
            GenerateCollection();
        }

        private void GenerateCollection()
        {
            if (models != null)
            {
                ObservableCollection<U> temp = new ObservableCollection<U>();
                IViewModelFactory<T, U> factory = null;
                if (typeof(IViewModelFactory<T, U>).IsAssignableFrom(typeof(U)))
                {
                    factory = new U() as IViewModelFactory<T, U>;
                }
                foreach (T model in models)
                {
                    U viewmodel = (factory == null) ? new U() { Model = model } : factory.Create(model);
                    temp.Add(viewmodel);
                }
                Items = new ReadOnlyObservableCollection<U>(temp);
            }
        }

        protected bool CanSave()
        {
            bool b = false;
            if (Items != null && Items.Count > 0)
            {
                for (int i = 0; !b && i < Items.Count; i++)
                {
                    if (Items[i].IsDirty)
                    {
                        b = true;
                    }
                }
            }
            return b;
        }

        /// <summary>
        /// This method iterates over the ViewModel collection, calls the
        /// Model Service's Delete & Update operations as appropriate, and
        /// autorefreshes the collection if appropriate.
        /// </summary>
        protected void Save()
        {
            if (Items != null)
            {
                foreach (var item in Items)
                {
                    if (item.MarkedForRemoval)
                    {
                        ICriterion criteria = null;
                        criteria = GetModelCriterion(item.Model);
                        Service.Delete<T>(criteria);
                    }
                    else if (item.IsDirty)
                    {
                        Service.Put<T>(item.Model,null);
                    }
                }
                if (AutoRefresh)
                {
                    ReadList();
                }
                if (RefreshAction != null)
                {
                    RefreshAction();
                }
            }
        }

        /// <summary>
        /// This method clears both the ViewModel collection, and item.
        /// </summary>
        protected void Clear()
        {
            Items = null;
            models = null;
        }

        protected bool CanInsert()
        {
            return Item.Validate();
        }

        /// <summary>
        /// This method calls the Model Service's Insert operation, passing
        /// in the ViewModel item.
        /// </summary>
        protected void Insert()
        {
            if (Item != null && Item.Validate())
            {
                AddModel(Item.Model);
                ResetItem();
                if (RefreshAction != null)
                {
                    RefreshAction();
                }
            }
        }

        /// <summary>
        /// This method resets the ViewModel item and underlying Model
        /// </summary>
        protected void ResetItem()
        {
            if (Item == null)
            {
                Item = new U();
            }
            Item.Model = new T();
            if (InitializeModel != null)
            {
                InitializeModel(Item.Model);
            }
            Item.Refresh();
        }

        private void AddModel(T model)
        {
            T t = default(T);
            t = Service.Post<T>(model);
            if (models == null)
            {
                models = new List<T>();
            }
            models.Add(t);
            GenerateCollection();
        }

        #endregion instance methods

        #region INotifyPropertyChanged Members

        /// <summary>
        /// This event is required for XAML style databinding
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged Members

        #region helper methods

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion helper methods
    }
}