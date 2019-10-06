using System;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace CSharpAdvanceDesignTests
{
    public static class MyComparerBuilder
    {
        public static IEnumerable<Employee> Sort(IEnumerable<Employee> employees, IComparer<Employee> comparer)
        {
            //bubble sort
            var elements = employees.ToList();
            while (elements.Any())
            {
                var minElement = elements[0];
                var index = 0;
                for (int i = 1; i < elements.Count; i++)
                {
                    var employee = elements[i];
                    var finalCompareResult = comparer.Compare(employee, minElement);

                    if (finalCompareResult < 0)
                    {
                        minElement = employee;
                        index = i;
                    }
                }

                elements.RemoveAt(index);
                yield return minElement;
            }
        }
    }

    public static class MyLinqExtensions
    {
        public static IEnumerable<Employee> JoeyOrderBy<TKey>(this IEnumerable<Employee> employees,
            Func<Employee, TKey> keySelector)
        {
            throw new NotImplementedException();
        }

        //public static IEnumerable<Employee> JoeyOrderBy(this IEnumerable<Employee> employees, IComparer<Employee> comparer)
        //{

        //}

        public static IEnumerable<Employee> JoeyOrderByComboComparer(this IEnumerable<Employee> employees,
            IComparer<Employee> comparer)
        {
            return MyComparerBuilder.Sort(employees, comparer);
        }

        public static IEnumerable<Employee> JoeyThenBy<TKey>(this IEnumerable<Employee> actual,
            Func<Employee, TKey> selector)
        {
            throw new NotImplementedException();
        }
    }
}