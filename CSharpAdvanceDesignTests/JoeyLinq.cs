using System;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    public static class JoeyLinq
    {
        public static MyCompareBuilder<TType> JoeyOrderBy<TType, TKey>(this IEnumerable<TType> employees,
            Func<TType, TKey> keySelector)
        {
            return new MyCompareBuilder<TType>(employees, new CombineKeyComparer<TType, TKey>(keySelector, Comparer<TKey>.Default));
        }

        public static MyCompareBuilder<TType> JoeyThenBy<TType, TKey>(this MyCompareBuilder<TType> employees,
            Func<TType, TKey> keySelector)
        {
            return employees.AddComparer(new CombineKeyComparer<TType, TKey>(keySelector, Comparer<TKey>.Default));
        }

        public static IEnumerable<TType> JoeyOrderByComboComparer<TType>(this IEnumerable<TType> employees,
            IComparer<TType> comparer)
        {
            return new MyCompareBuilder<TType>(employees, comparer);
        }
    }
}