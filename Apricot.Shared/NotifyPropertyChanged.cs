using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Apricot.Shared
{
    /// <summary>
    ///     Classe de notification entre la vue et le vue-modèle.
    /// </summary>
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        #region Members.

        /// <summary>
        ///     Raises when a property value is updated.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Members.

        #region Methods.

        /// <summary>
        ///     Notify a update by the component name.
        /// </summary>
        /// <param name="propertyName">The property name. This parameter is optional: the name is obtained if this method is called in a property.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException("propertyName", "The parameter is null or empty.");
            }

            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        ///     Notify a update by a component object.
        /// </summary>
        /// <param name="args">The component.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            try
            {
                if (PropertyChanged != null)
                {
                    Debug.WriteLine("Update notification on the property: {0}", args.PropertyName);
                    PropertyChanged(this, args);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("The property has couldn't be notified: {0} following an error: {1}", args.PropertyName, e.Message);
            }
        }

        /// <summary>
        ///     Update and notify a value.
        /// </summary>
        /// <typeparam name="T">The generic type.</typeparam>
        /// <param name="property">The property value.</param>
        /// <param name="value">The new value of the property.</param>
        /// <param name="propertyName">The property name. This parameter is optional: the name is obtained if this method is called in a property.</param>
        /// <returns>True if the property is update and notified, otherwise, False.</returns>
        protected bool SetValueProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException("propertyName", "The parameter is null or empty.");
            }
            if (Equals(property, value) && (propertyName != null))
            {
                Debug.WriteLine("The property has couldn't be notified: {0} because the previous value is identical to the new value.", propertyName);
                return false;
            }

            property = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion Methods.
    }
}