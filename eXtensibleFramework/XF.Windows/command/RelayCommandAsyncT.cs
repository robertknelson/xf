// <copyright file="RelayCommandAsyncT.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows.Input;

    public class RelayCommandAsync<T> : ICommand
    {
        private readonly Predicate<object> _canExecute;

        public Func<T> DoWork { get; set; }

        public Action<T> ProcessResult { get; set; }

        public event EventHandler RunWorkStarting;

        public event RunWorkerCompletedEventHandler RunWorkCompleted;

        private bool _isWorking;

        public bool IsWorking
        {
            get { return _isWorking; }
            private set
            {
                _isWorking = value;
            }
        }

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            if (IsWorking)
            {
                return false;
            }
            else
            {
                return _canExecute == null ? true : _canExecute(parameter);
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            try
            {
                OnRunWorkerStarting();
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                worker.RunWorkerCompleted += ((sender, e) => OnRunWorkerCompleted(e));
                if (ProcessResult != null)
                {
                    worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                }
                worker.RunWorkerAsync(parameter);
            }
            catch (Exception ex)
            {
                OnRunWorkerCompleted(new RunWorkerCompletedEventArgs(null, ex, true));
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            T t = (T)e.Result;
            if (ProcessResult != null && t != null)
            {
                ProcessResult.Invoke(t);
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (DoWork != null)
            {
                e.Result = DoWork.Invoke();
            }
        }

        #endregion ICommand Members

        public RelayCommandAsync()
        {
            _canExecute = null;
        }

        public RelayCommandAsync(Func<T> doWork)
            : this(doWork, null) { }

        public RelayCommandAsync(Func<T> doWork, Action<T> processResult)
            : this(doWork, processResult, null) { }

        public RelayCommandAsync(Func<T> doWork, Action<T> processResult, Predicate<object> canExecute)
        {
            DoWork = doWork;
            ProcessResult = processResult;
            _canExecute = canExecute;
        }

        private void OnRunWorkerStarting()
        {
            IsWorking = true;
            if (RunWorkStarting != null)
                RunWorkStarting(this, EventArgs.Empty);
        }

        private void OnRunWorkerCompleted(RunWorkerCompletedEventArgs e)
        {
            IsWorking = false;
            CommandManager.InvalidateRequerySuggested();
            if (RunWorkCompleted != null)
                RunWorkCompleted(this, e);
        }
    }
}

// Sample Usage

//  <Button x:Name="btnExecuteAsync" Margin="10" Content="Execute Async"
//  Command="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type Window}},Path=FetchItemsAsync}"/>
//
//private ICommand _FetchItemsAsync;

//public ICommand FetchItemsAsync
//{
//    get
//    {
//        if (_FetchItemsAsync == null)
//        {
//            // three ways to instantiate the command
//            _FetchItemsAsync = new RelayCommandAsync<List<Customer>>()
//            {
//                DoWork = GetList,
//                ProcessResult = BindList
//            };
//            //_FetchItemsAsync = new RelayCommandAsync<List<Customer>>(
//            //    new Func<List<Customer>>(GetList),
//            //    new Action<List<Customer>>(BindList)
//            //    );
//            //_FetchItemsAsync = new RelayCommandAsync<List<Customer>>(
//            //    () => GetList(),
//            //    BindList
//            //    );
//        }
//        return _FetchItemsAsync;
//    }
//}

//public List<Customer> GetList()
//{
//    return _Service.ReadList<Customer>(null).ToList();
//}
//public void BindList(List<Customer> list)
//{
//    dgrItems.ItemsSource = list;
//}