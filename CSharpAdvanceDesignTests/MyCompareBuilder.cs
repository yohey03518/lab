using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    public class MyCompareBuilder<TType> : IEnumerable<TType>
    {
        private readonly IEnumerable<TType> _employees;
        private IComparer<TType> _untilNowComparer;

        public MyCompareBuilder(IEnumerable<TType> employees, IComparer<TType> untilNowComparer)
        {
            _employees = employees;
            _untilNowComparer = untilNowComparer;
        }

        public static IEnumerator<TType> Sort(IEnumerable<TType> employees, IComparer<TType> comparer)
        {
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

        public IEnumerator<TType> GetEnumerator()
        {
            return Sort(_employees, _untilNowComparer);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public MyCompareBuilder<TType> AddComparer<TKey>(CombineKeyComparer<TType, TKey> comparer)
        {
            _untilNowComparer = new ComboComparer<TType>(_untilNowComparer, comparer);
            return this;
        }
    }
}