using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arges
{
    public class SelectionConverter
    {

        #region Selections (List<Selection>)

        private List<Cyclops.Selection> _Selections;

        /// <summary>
        /// Gets or sets the List<Selection> value for Selections
        /// </summary>
        /// <value> The List<Selection> value.</value>

        public List<Cyclops.Selection> Selections
        {
            get { return _Selections; }
            set
            {
                if (_Selections != value)
                {
                    _Selections = value;
                }
            }
        }

        #endregion

        public SelectionConverter(List<Cyclops.Selection> list)
        {
            _Selections = list;
        }

        public  string Convert(int selectionId)
        {
            var found = _Selections.Find(x => x.SelectionId.Equals(selectionId));
            return found != null ? found.Display : String.Empty;
        }

        public int ConvertToId(string selectionDisplay)
        {

            var found = _Selections.Find(x => x.Token.Equals(selectionDisplay, StringComparison.OrdinalIgnoreCase));
            return found != null ? found.SelectionId : 0;
        }

    }
}
