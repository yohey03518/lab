using System;
using System.Collections.Generic;
using Lab.Entities;

static internal class My
{
    public static IEnumerable<Employee> JoeyThenBy<TKey>(IEnumerable<Employee> actual, Func<Employee, TKey> selector)
    {
        throw new NotImplementedException();
    }
}