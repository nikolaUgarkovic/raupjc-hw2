using System;
using System.Collections;
using System.Collections.Generic;

namespace Zadatak2
{
    class GenericList <X> : IGenericList<X>
    {
        private X[] _internalStorage;
        private int _indexOfLastElement;

        public GenericList()
        {
            _internalStorage = new X[4];
            _indexOfLastElement = -1;
        }

        public GenericList(int initialSize)
        {
            if (initialSize < 0)
            {
                Console.WriteLine("Invalid list size");
            }
            else
            {
                _internalStorage = new X[initialSize];
                _indexOfLastElement = -1;
            }
        }

        public void Add(X item)
        {
            if (Count == _internalStorage.Length)
            {
                X[] newStorage = new X[_internalStorage.Length * 2];
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    newStorage[i] = _internalStorage[i];
                }
                _indexOfLastElement++;
                newStorage[_internalStorage.Length] = item;
                _internalStorage = newStorage;
            }
            else
            {
                _indexOfLastElement++;
                _internalStorage[_indexOfLastElement] = item;
            }
        }

        public bool Remove(X item)
        {
            for (int i = 0; i < _indexOfLastElement + 1; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index > _indexOfLastElement)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                for (int i = index; i < _indexOfLastElement; i++)
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                }

                _indexOfLastElement--;
                return true;
            }
        }

        public X GetElement(int index)
        {
            if (index < 0 || index > _indexOfLastElement)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return _internalStorage[index];
            }
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i <= _indexOfLastElement; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public int Count
        {
            get { return _indexOfLastElement + 1; }
        }
        public void Clear()
        {
            _internalStorage = new X[_internalStorage.Length];
            _indexOfLastElement = -1;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i <= _indexOfLastElement; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
