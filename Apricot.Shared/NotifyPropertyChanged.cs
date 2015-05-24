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
        #region Événements.

        /// <summary>
        ///     Se produit lorsqu'une valeur de propriété est modifiée.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Méthodes.

        /// <summary>
        /// 
        ///     Notifie un changement selon le nom du composant.
        /// </summary>
        /// <param name="propertyName">Nom de la propriété.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        ///     Notifie un changement selon un objet représentant le composant.
        /// </summary>
        /// <param name="args">Composant.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            try
            {
                if (PropertyChanged == null) return;

                Debug.WriteLine("Notification de changement sur la propriété : {0}", args.PropertyName);
                PropertyChanged(this, args);
            }
            catch (Exception e)
            {
                Debug.WriteLine("La propriété n'a pas pu être notifiée : {0} suite à une erreur : {1}", args.PropertyName, e.Message);
                Debug.WriteLine("StackTrace : {0}", e.StackTrace);
            }
        }

        /// <summary>
        ///     Change la valeur et notifie un changement.
        /// </summary>
        /// <typeparam name="T">Type générique.</typeparam>
        /// <param name="property">Valeur de la propriété.</param>
        /// <param name="value">Nouvelle valeur a affecter.</param>
        /// <param name="propertyName">
        ///     Nom de la propriété.
        ///     Ce paramètre est facultatif et est marqué de l'attribut <see cref="System.Runtime.CompilerServices.CallerMemberNameAttribute"/>.
        ///     En appelant cette méthode, le paramètre prend le nom de la propriété appelante.
        /// </param>
        /// <returns>True si la propriété a été notifiée et changée, False dans le cas contraire.</returns>
        protected bool SetValueProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(property, value) && (propertyName != null))
            {
                Debug.WriteLine("La propriété n'a pas pu être notifiée : {0} car la valeur précédente est identique à la nouvelle valeur.", propertyName);
                return false;
            }

            property = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}
