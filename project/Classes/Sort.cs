using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaLogo.Classes
{
    class Sort
    {
        public List<int> quicksort(List<int> a)                 //http://www.codeproject.com/Articles/79040/Sorting-Algorithms-Codes-in-C-NET
        {
            Random r = new Random();
            List<int> less = new List<int>();
            List<int> greater = new List<int>();
            if(a.Count <= 1)
                return a;
            int pos = r.Next(a.Count);

            int pivot = a[pos];
            a.RemoveAt(pos);
            foreach(int x in a)
            {
                if(x <= pivot)
                    less.Add(x);
                else
                    greater.Add(x);
            }
            return concat(quicksort(less), pivot, quicksort(greater));
        }

        public List<int> concat(List<int> less, int pivot, List<int> greater)
        {
            List<int> sorted = new List<int>(less);
            sorted.Add(pivot);
            foreach(int i in greater)
                sorted.Add(i);

            return sorted;
        }
    }
}
