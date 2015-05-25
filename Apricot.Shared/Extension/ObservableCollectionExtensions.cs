using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Apricot.Shared.Extension
{
    /// <summary>
    ///     Extension class for <see cref="ObservableCollection{T}"/>.
    /// </summary>
    public static class ObservableCollectionExtensions
    {
        /// <summary>
        ///     Adds the elements of an <see cref="IEnumerable{T}"/> to the end of the <see cref="ObservableCollection{T}"/>.
        /// </summary>
        /// <typeparam name="T">The item type.</typeparam>
        /// <param name="collection">The Collection.</param>
        /// <param name="items">The items to add.</param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="collection"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="items"/> is null.</exception>
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        /// <summary>
        ///     Adds the unique elements of an <see cref="IEnumerable{T}"/> to the end of the <see cref="ObservableCollection{T}"/>.
        /// </summary>
        /// <typeparam name="T">The item type.</typeparam>
        /// <param name="collection">The Collection.</param>
        /// <param name="items">The items to add.</param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="collection"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="items"/> is null.</exception>
        public static void AddUnique<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            foreach (var item in items.Where(item => !collection.Contains(item)))
            {
                collection.Add(item);
            }
        }
    }
}
