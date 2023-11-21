using System;

namespace Sort
{
    public class InsertionSort<T> : SortBase<T> where T : IComparable
    {
        public override T[] Sort(T[] a)
        {
            int n = a.Length;

            for(int i = 1; i < n; i++)
            {
                for (int j = i; j > 0 && Less(a[j], a[j - 1]); j--)
                    a = Exchange(a,j,j-1);
            }

            return a;
        }

        public override T[] Sort(T[] a, Action<T[]> action)
        {
            int n = a.Length;

            for (int i = 1; i < n; i++)
            {
                for (int j = i; j > 0 && Less(a[j], a[j - 1]); j--)
                    a = Exchange(a, j, j - 1);

                action.Invoke(a);
            }
            return a;
        }
    }  
}