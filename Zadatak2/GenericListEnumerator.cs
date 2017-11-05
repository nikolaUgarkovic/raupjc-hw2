using System.Collections;
using System.Collections.Generic;

namespace Zadatak2
{
    internal class GenericListEnumerator<X> : IEnumerator<X>
    {
        private GenericList<X> genericList;
        private int _indexOfLastElement;

        public GenericListEnumerator(GenericList<X> genericList)
        {
            this.genericList = genericList;
            _indexOfLastElement = -1;
        }

        public X Current => genericList.GetElement(_indexOfLastElement);

        object IEnumerator.Current => genericList.GetElement(_indexOfLastElement);

        public void Dispose()
        {
            //throw new System.NotImplementedException();
        }

        public bool MoveNext()
        {
            if ((_indexOfLastElement + 1) <= (genericList.Count - 1))
            {
                _indexOfLastElement++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            //throw new System.NotImplementedException();
        }
    }
}