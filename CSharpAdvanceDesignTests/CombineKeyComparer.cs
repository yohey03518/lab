using System;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    public class CombineKeyComparer<TType, TKey> : IComparer<TType>
    {
        public Func<TType, TKey> KeySelector { get; }
        public IComparer<TKey> Comparer { get; }

        public CombineKeyComparer(Func<TType, TKey> keySelector, IComparer<TKey> comparer)
        {
            KeySelector = keySelector;
            Comparer = comparer;
        }

        public int Compare(TType x, TType y)
        {
            return Comparer.Compare(KeySelector(x),
                KeySelector(y));
        }
    }
}