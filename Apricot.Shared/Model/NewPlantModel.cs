using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Apricot.Shared.Model
{
    /// <summary>
    ///     Model for the "New plant" view.
    /// </summary>
    public class NewPlantModel : NotifyPropertyChanged
    {
        #region Members.

        /// <summary>
        ///     Plant name.
        /// </summary>
        private string _name;

        /// <summary>
        ///     Variety identifier.
        /// </summary>
        private int _varietyId;

        #endregion Members.

        #region Properties.

        /// <summary>
        ///     Gets or sets a plant name.
        /// </summary>
        /// <value>The plant name.</value>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetValueProperty(ref _name, value);
            }
        }

        /// <summary>
        ///     Gets or sets a command for OnLoaded event.
        /// </summary>
        /// <value>The command for OnLoaded event.</value>
        public ICommand OnLoadedCommand { get; set; }

        /// <summary>
        ///     Gets or sets a photos.
        /// </summary>
        /// <value>The photos.</value>
        public ObservableCollection<string> Photos { get; set; }

        /// <summary>
        ///     Gets or sets a variety identifier.
        /// </summary>
        public IList<Object> Variety { get; set; }

        /// <summary>
        ///     Gets or sets a variety identifier.
        /// </summary>
        /// <value>The variety identifier.</value>
        public int VarietyId
        {
            get
            {
                return _varietyId;
            }
            set
            {
                SetValueProperty(ref _varietyId, value);
            }
        }

        /// <summary>
        ///     Gets or set a cmmand for OnUnloaded event.
        /// </summary>
        /// <value>The command for OnUnloaded event.</value>
        public ICommand OnUnloadedCommand { get; set; }

        #endregion Properties.

        #region Constructor.

        /// <summary>
        ///     Constructor.
        /// </summary>
        public NewPlantModel()
        {
            Photos = new ObservableCollection<string>();
            Variety = new List<object>();
        }

        #endregion Constructor.
    }
}