using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndString
{
    public class MyArrayList<T> : IList<T>, ICollection<T>, IEnumerable<T>, ICloneable
    {
        private const int DefaultSize = 4;
        private const int MaxArrayLength = 0X7FEFFFFF;
        private T[] _data;
        private int _size;

        public T this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public MyArrayList()
        {
            _data = new T[0];
        }

        public MyArrayList(int size)
        {
            
        } 

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        private int GetNewCapacity(int newSize)
        {
            var newCapacity = 4;
            if (_size > 0)
            {
                newCapacity = _data.Length * 2;
                if (newCapacity > MaxArrayLength || newCapacity < 0)
                {
                    newCapacity = MaxArrayLength;
                }
            }
            return newCapacity;
        }

        private void ResizeIfNeeded(int newSize)
        { 
            if (newSize > _size)
            {
                var newData = new T[GetNewCapacity(newSize)];

            }
        }
    }
}
