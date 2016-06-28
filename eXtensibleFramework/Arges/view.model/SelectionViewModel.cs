using System;
using XF.Windows.Common;

namespace Arges
{
    public class SelectionViewModel : ViewModel<Cyclops.Selection>
    {
        #region properties


        #region SelectionId (int)

        /// <summary>
        /// Gets or sets the int value for SelectionId
        /// </summary>
        /// <value> The int value.</value>

        public int SelectionId
        {
            get { return Model.SelectionId; }
            set
            {
                if (Model.SelectionId != value)
                {
                    Model.SelectionId = value;
                    OnPropertyChanged("SelectionId");
                    IsDirty = true;
                }
            }
        }

        #endregion

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

        #region Token (string)

        /// <summary>
        /// Gets or sets the string value for Token
        /// </summary>
        /// <value> The string value.</value>

        public string Token
        {
            get { return (String.IsNullOrEmpty(Model.Token)) ? String.Empty : Model.Token; }
            set
            {
                if (Model.Token != value)
                {
                    Model.Token = value;
                    OnPropertyChanged("Token");
                    IsDirty = true;
                }
            }
        }

        #endregion

        #region Sort (int)

        /// <summary>
        /// Gets or sets the int value for Sort
        /// </summary>
        /// <value> The int value.</value>

        public int Sort
        {
            get { return Model.Sort; }
            set
            {
                if (Model.Sort != value)
                {
                    Model.Sort = value;
                    OnPropertyChanged("Sort");
                    IsDirty = true;
                }
            }
        }

        #endregion

        #region MasterId (int)

        /// <summary>
        /// Gets or sets the int value for MasterId
        /// </summary>
        /// <value> The int value.</value>

        public int MasterId
        {
            get { return Model.MasterId; }
            set
            {
                if (Model.MasterId != value)
                {
                    Model.MasterId = value;
                    OnPropertyChanged("MasterId");
                    IsDirty = true;
                }
            }
        }

        #endregion

        #region Icon (string)

        /// <summary>
        /// Gets or sets the string value for Icon
        /// </summary>
        /// <value> The string value.</value>

        public string Icon
        {
            get { return (String.IsNullOrEmpty(Model.Icon)) ? String.Empty : Model.Icon; }
            set
            {
                if (Model.Icon != value)
                {
                    Model.Icon = value;
                    OnPropertyChanged("Icon");
                    IsDirty = true;
                }
            }
        }

        #endregion

        #region SecondaryIcon (string)

        /// <summary>
        /// Gets or sets the string value for SecondaryIcon
        /// </summary>
        /// <value> The string value.</value>

        public string SecondaryIcon
        {
            get { return (String.IsNullOrEmpty(Model.SecondaryIcon)) ? String.Empty : Model.SecondaryIcon; }
            set
            {
                if (Model.SecondaryIcon != value)
                {
                    Model.SecondaryIcon = value;
                    OnPropertyChanged("SecondaryIcon");
                    IsDirty = true;
                }
            }
        }

        #endregion

        #endregion


        #region constructors



        #endregion


    }
}
