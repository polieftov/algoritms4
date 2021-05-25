using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork4
{
    class SalesmanTask
    {
        public List<int> theBestWay;
        public int theBestWayDist;
        int[,] matr;
        List<int[]> ways;
        int start;

        public SalesmanTask(int[,] _matr, int s)
        {
            matr = _matr;
            start = s;
            
        }

        private void FindAllWays()
        {
            var someWay = new List<int>();
            someWay.Add(start);
            var allNodes = GenerateNodesArr(matr.GetLength(0));
            allNodes.Remove(start);
            
            var permut = new Permutation(allNodes.ToArray());
            permut.Generate(0, allNodes.Count);
            ways = permut.res;
        }

        private List<int> GenerateNodesArr(int len)
        {
            var res = new List<int>();
            for (var i = 0; i < len; i++)
                res.Add(i);
            return res;
        }

        public void FindTheBestWay()
        {
            FindAllWays();
            var tempTheBestWay = new List<int>();
            var minDist = int.MaxValue;
            foreach(var way in ways)
            {
                var wayDist = GetDistance(way);
                if (wayDist < minDist && minDist > 0)
                {

                    tempTheBestWay.Add(start);
                    tempTheBestWay.AddRange(way);
                    tempTheBestWay.Add(start);
                    minDist = wayDist;
                }
            }
            theBestWay = tempTheBestWay;
            theBestWayDist = minDist;
        }

        private int GetDistance(int[] way)
        {
            var dist = 0;
            for(var i = 0; i <= way.Length; i++)
            {
                if (i == 0)
                {
                    if (matr[start, way[i]] == -1)
                        return -1;
                    dist += matr[start, way[i]];
                }
                else if (i == way.Length)
                {
                    if (matr[way[i-1], start] == -1)
                        return -1;
                    dist += matr[way[i-1], start];
                }
                else
                {
                    if (matr[way[i-1], way[i]] == -1)
                        return -1;
                    dist += matr[way[i] - 1, way[i]];
                }
            }
            return dist;
        }
    }
}
