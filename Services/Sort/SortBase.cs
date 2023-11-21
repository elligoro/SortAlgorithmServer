using System;

namespace Sort 
{
    public abstract class SortBase<T> where T : IComparable
    {
        public abstract T[] Sort(T[] a);
        public abstract T[] Sort(T[] a, Action<T[]> action);

        protected bool Less(T v, T w) => v.CompareTo(w) < 0;

        protected T[] Exchange(T[] a, int i, int j)
        {
            T t = a[i];
            a[i] = a[j];
            a[j] = t;
            
            return a;
        }
        public bool IsSorted(T[] a)
        {
            for(var i=1; i<a.Length; i++)
            {
                if (Less(a[i], a[i - 1]))
                    return false;
            }
            return true;
        }
    }
}