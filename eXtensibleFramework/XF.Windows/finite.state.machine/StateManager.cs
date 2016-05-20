// <copyright file="StateManager.cs" company="eXtensoft LLC">
// Copyright © 2014 All Right Reserved
// </copyright>

namespace XF.Windows.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Input;

    public class StateManager : INotifyPropertyChanged
    {
        public string Key { get; set; }

        #region Commands

        private ICommand _ExecuteTransition;

        public ICommand ExecuteTransition
        {
            get
            {
                if (_ExecuteTransition == null)
                {
                    _ExecuteTransition = new RelayCommand<string>(LocalExecuteTransition, CanExecuteTransition);
                }
                return _ExecuteTransition;
            }
        }

        #endregion Commands

        #region CurrentState (string)

        /// <summary>
        /// Gets or sets the string value for CurrentState
        /// </summary>
        /// <value> The string value.</value>

        public string CurrentState
        {
            get { return Machine.GetCurrentState().Display; }
        }

        #endregion CurrentState (string)

        #region Transitions (List<Transition>)

        /// <summary>
        /// Gets or sets the List<Transition> value for Transitions
        /// </summary>
        /// <value> The List<Transition> value.</value>

        public List<Transition> Transitions
        {
            get { return Machine.GetTransitions(); }
        }

        #endregion Transitions (List<Transition>)

        public Transition EndingTransition
        {
            get { return Machine.EndingTransition; }
        }

        public StateMachine Machine { get; set; }

        public StateManager()
        {
        }

        #region helper methods

        private void LocalExecuteTransition(string transitionName)
        {
            Machine.ExecuteTransition(transitionName);
            OnPropertyChanged("CurrentState");
            OnPropertyChanged("Transitions");
            OnPropertyChanged("EndingTransition");
        }

        private bool CanExecuteTransition(string transitionName)
        {
            return Machine.CanExecuteTransition(transitionName);
        }

        #endregion helper methods

        #region instance methods

        public void RegisterEndpointAction(string stateKey, EndpointOption option, params Action[] actions)
        {
            var found = Machine.States.FirstOrDefault(x => x.Name.Equals(stateKey, StringComparison.OrdinalIgnoreCase));
            if (found != null)
            {
                if (found.EndpointActions == null)
                {
                    found.EndpointActions = new List<IEndpointAction>();
                }
                found.EndpointActions.Add(new EndpointAction(option, actions));
            }
        }

        public void RegisterTransitionAction(string transitionKey, EndpointOption option, params Action[] actions)
        {
            var found = Machine.States.FirstOrDefault(x => x.Name.Equals(transitionKey, StringComparison.OrdinalIgnoreCase));
            if (found != null)
            {
                if (found.EndpointActions == null)
                {
                    found.EndpointActions = new List<IEndpointAction>();
                }
                found.EndpointActions.Add(new EndpointAction(option, actions));
            }
        }

        #endregion instance methods

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion INotifyPropertyChanged Members
    }
}