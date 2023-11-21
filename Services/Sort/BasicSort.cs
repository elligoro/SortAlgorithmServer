using System;
using System.Net.WebSockets;

namespace Sort
{
    public class BasicSort<T> : SortBase<T> where T : IComparable 
    {
        public override T[] Sort(T[] a, Action<T[]> action)
        {
            int n = a.Length;
            for(int i = 0; i < n; i++)
            {
                int min = i;
                for(int j = i + 1; j < n; j++)
                {
                    if(Less(a[j],a[min])){
                        min = j;  
                    }
                    a = Exchange(a, i, min);
                }
                action.Invoke(a);
            }
            return a;
        }
        public override T[] Sort(T[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (Less(a[j], a[min]))
                    {
                        min = j;
                    }
                    a = Exchange(a, i, min);
                }
            }
            return a;
        }
    }
}