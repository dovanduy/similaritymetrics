using System.Collections.Generic;
using System.Linq;

namespace CollectiveIntelligence.Core.Common
{
    public class Maybe<T>
    {
        private readonly List<T> _zeroOrOneElement;

        public Maybe(T element)
        {
            _zeroOrOneElement = new List<T>();

            if (element != null)
            {
                _zeroOrOneElement.Add(element);
            }
        }

        public bool IsEmpty()
        {
            return !_zeroOrOneElement.Any();
        }

        public T FirstOrDefault(T defaultValue)
        {
            return IsEmpty() ? defaultValue : _zeroOrOneElement[0];
        }
    }
}
