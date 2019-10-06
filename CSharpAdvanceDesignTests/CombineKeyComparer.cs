using System;
using System.Collections.Generic;
using Lab.Entities;

namespace CSharpAdvanceDesignTests
{
    public class CombineKeyComparer
    {
        public CombineKeyComparer(Func<Employee, string> keySelector, IComparer<string> keyComparer)
        {
            KeySelector = keySelector;
            KeyComparer = keyComparer;
        }

        public Func<Employee, string> KeySelector { get; private set; }
        public IComparer<string> KeyComparer { get; private set; }
    }
}