using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfFeedback.Framework
{
    /// <summary>
    /// List to hold unique types.
    /// </summary>
    public class UniqueTypeListWrapper<T> : ICollection<T>
    {
        private List<T> _wrappedList = new List<T>();

        public void Add(T item)
        {
            List<T> newList = new List<T>();
            foreach (var listItem in _wrappedList.ToArray())
	        {
	        	 if(listItem is T)
                 {
                     continue;
                 }

                newList.Add(listItem);
	        }
            newList.Add(item);
            _wrappedList = new List<T>(newList);
        }

        public void Clear()
        {
            _wrappedList.Clear();
        }

        public bool Contains(T item)
        {
            return _wrappedList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return _wrappedList.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            return _wrappedList.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _wrappedList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
