using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork4
{
    class Permutation
    {
        public Permutation(int[] _arr)
        {
            arr = _arr;
        }
        public int[] arr;
        public List<int[]> res = new List<int[]>();

        public void Generate(int l, int r)
        {

            
            if (l == r)
            {
                var newAr = new int[arr.Length];
                Array.Copy(arr, newAr, arr.Length);
                res.Add(newAr);
            }
            else
            {
                for (var i = l; i < r; i++)
                {
                    Swap(arr, l, i);
                    Generate(l + 1, r);
                    Swap(arr, l, i);
                }
            }
        }

        private void Swap(int[] arr, int i, int j)
        {
            int t;
            t = arr[j];
            arr[j] = arr[i];
            arr[i] = t;
        }
    }
}
