using System;
using System.Collections.Generic;
using Lab.Entities;

namespace CSharpAdvanceDesignTests
{
    public static class MyLinqExtensions
    {
        public static MyComparerBuilder JoeyOrderBy<TKey>(this IEnumerable<Employee> employees,
            Func<Employee, TKey> keySelector)
        {
            var comparer = new CombineKeyComparer<TKey>(keySelector, Comparer<TKey>.Default);
            return new MyComparerBuilder(employees, comparer);
        }

        public static IEnumerable<Employee> JoeyOrderByComboComparer(this IEnumerable<Employee> employees,
            IComparer<Employee> comparer)
        {
            return new MyComparerBuilder(employees, comparer);
        }

        public static IMyOrderedEnumerable JoeyThenBy<TKey>(this IMyOrderedEnumerable myComparerBuilder,
            Func<Employee, TKey> keySelector)
        {
            var comparer = new CombineKeyComparer<TKey>(keySelector, Comparer<TKey>.Default);
            return myComparerBuilder.CreateOrderedEnumerable(comparer);
        }
    }
}