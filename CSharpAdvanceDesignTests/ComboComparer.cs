using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    public class ComboComparer<TType> : IComparer<TType>
    {
        public IComparer<TType> FirstComparer { get; }
        public IComparer<TType> SecondComparer { get; }

        public ComboComparer(IComparer<TType> firstComparer, IComparer<TType> secondComparer)
        {
            FirstComparer = firstComparer;
            SecondComparer = secondComparer;
        }

        public int Compare(TType x, TType y)
        {
            var firstCompareResult = FirstComparer.Compare(x, y);
            return firstCompareResult != 0 ? firstCompareResult : SecondComparer.Compare(x, y);
        }
    }
}