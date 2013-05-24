using System.Collections;
using System.Collections.Generic;

namespace FluentMigrator.CF.Collections.Generic
{
    /// <summary>
    /// Represents a set of values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the hash set.</typeparam>
    public class HashSet<T> : ICollection<T>
    {
        private readonly IDictionary<T, object> _internalDictionary = new Dictionary<T, object>();
        private static readonly object PlaceholderObject = new object();

        /// <summary>
        /// Returns an enumerator that iterates through a <see cref="FluentMigrator.CF.Collections.Generic.HashSet{T}"/> object.
        /// </summary>
        /// <returns>A <see cref="FluentMigrator.CF.Collections.Generic.HashSet{T}"/> object for the <see cref="FluentMigrator.CF.Collections.Generic.HashSet{T}"/> object.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _internalDictionary.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Adds the specified element to a set.
        /// </summary>
        /// <param name="item">The element to add to the set.</param>
        public void Add(T item)
        {
            if (!_internalDictionary.ContainsKey(item))
            {
                //The object we are adding is just a placeholder.  The thing we are
                //really concerned with is 'item', the key.
                _internalDictionary.Add(item, PlaceholderObject);
            }
        }

        /// <summary>
        /// Removes all elements from a <see cref="FluentMigrator.CF.Collections.Generic.HashSet{T}"/> object.
        /// </summary>
        public void Clear()
        {
            _internalDictionary.Clear();
        }

        /// <summary>
        /// Determines whether a <see cref="FluentMigrator.CF.Collections.Generic.HashSet{T}"/> object contains the specified element.
        /// </summary>
        /// <param name="item">The element to locate in the HashSet<T> object.</param>
        /// <returns>true if the <see cref="FluentMigrator.CF.Collections.Generic.HashSet{T}"/> object contains the specified element; otherwise, false.</returns>
        public bool Contains(T item)
        {
            return _internalDictionary.ContainsKey(item);
        }

        /// <summary>
        /// Copies the elements of a <see cref="FluentMigrator.CF.Collections.Generic.HashSet{T}"/> object to an array, starting at the specified array index.
        /// </summary>
        /// <param name="array">The one-dimensional array that is the destination of the elements
        /// copied from the <see cref="FluentMigrator.CF.Collections.Generic.HashSet{T}"/> object. The array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="System.ArgumentNullException">array is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">arrayIndex is less than 0.</exception>
        /// <exception cref="System.ArgumentException">arrayIndex is greater than the length of the destination array.-or-count is larger than the size of the destination array.</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _internalDictionary.Keys.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the specified element from a <see cref="FluentMigrator.CF.Collections.Generic.HashSet{T}"/> object.
        /// </summary>
        /// <param name="item">The element to remove.</param>
        /// <returns>true if the element is successfully found and removed; otherwise, false.
        /// This method returns false if item is not found in the <see cref="FluentMigrator.CF.Collections.Generic.HashSet{T}"/> object.
        /// </returns>
        public bool Remove(T item)
        {
            var contained = this.Contains(item);
            if (contained)
            {
                _internalDictionary.Remove(item);
            }
            return contained;
        }

        /// <summary>
        /// Gets the number of elements that are contained in a set.
        /// </summary>
        /// <returns>The number of elements that are contained in the set.</returns>
        public int Count { get { return _internalDictionary.Count; } }

        /// <summary>
        /// Gets a value indicating whether the <see cref="FluentMigrator.CF.Collections.Generic.HashSet{T}"/> is read-only.
        /// </summary>
        /// <returns>true if the <see cref="ICollection{T}"/> is read-only; otherwise, false.</returns>
        public bool IsReadOnly { get { return _internalDictionary.IsReadOnly; } }
    }
}