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
            //return MyComparerBuilder.Sort(employees, comparer);
        }

        public static MyComparerBuilder JoeyThenBy<TKey>(this MyComparerBuilder myComparerBuilder,
            Func<Employee, TKey> keySelector)
        {
            var comparer = new CombineKeyComparer<TKey>(keySelector, Comparer<TKey>.Default);
            return myComparerBuilder.AppendComparer(comparer);
        }
    }
}