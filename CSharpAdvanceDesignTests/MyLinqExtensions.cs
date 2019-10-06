using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace CSharpAdvanceDesignTests
{
    public class MyComparerBuilder : IEnumerable<Employee>
    {
        private readonly IEnumerable<Employee> _Source;
        private readonly IComparer<Employee> _CurrentComparer;

        public MyComparerBuilder(IEnumerable<Employee> source, IComparer<Employee> currentComparer)
        {
            _Source = source;
            _CurrentComparer = currentComparer;
        }

        public static IEnumerator<Employee> Sort(IEnumerable<Employee> employees, IComparer<Employee> comparer)
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

        public IEnumerator<Employee> GetEnumerator()
        {
            return Sort(_Source, _CurrentComparer);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class MyLinqExtensions
    {
        public static IEnumerable<Employee> JoeyOrderBy<TKey>(this IEnumerable<Employee> employees,
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

        public static IEnumerable<Employee> JoeyThenBy<TKey>(this IEnumerable<Employee> actual,
            Func<Employee, TKey> selector)
        {
            throw new NotImplementedException();
        }
    }
}