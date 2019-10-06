using System.Collections.Generic;
using System.Linq;
using Lab.Entities;

namespace CSharpAdvanceDesignTests
{
    public static class MyLinqExtensions
    {
        public static IEnumerable<Employee> JoeyOrderByComboComparer(this IEnumerable<Employee> employees,
            IComparer<Employee> comparer)
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
}