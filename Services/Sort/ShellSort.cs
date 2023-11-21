using System;

namespace Sort
{
    public class ShellSort<T> : SortBase<T> where T : IComparable
    {
        public override T[] Sort(T[] a)
        {
            int n = a.Length;
            int h = 1;
            while(h < n/3)
            {
                h = 3 * h + 1;
            }
            while(h >= 1)
            {
                for(int i = h; i < n; i++)
                {
                    for(int j = i; j >= h && Less(a[j],a[j-h]); j -= h)
                    {
                        Exchange(a, j, j - h);
                    }
                }
                h = h / 3;
            }


            return a;
        }

        public override T[] Sort(T[] a, Action<T[]> action)
        {
            int n = a.Length;
            int h = 1;
            while (h < n / 3)
            {
                h = 3 * h + 1;
            }
            while (h >= 1)
            {
                for (int i = h; i < n; i++)
                {
                    for (int j = i; j >= h && Less(a[j], a[j - h]); j -= h)
                    {
                        Exchange(a, j, j - h);
                    }
                }
                h = h / 3;

                action.Invoke(a);
            }
            return a;
        }

    }
}