﻿
using System.Collections.Generic;
using System.Linq;

namespace DecisionSystems.TSP.Solver
{
    public class NearestNeighborConstructionTSPSolver : ITSPSolver
    {
        public List<int> Solve(IReadOnlyList<Location> cities)
        {
            var result = Enumerable.Range(1,cities.Count).ToList();
            for (int i = 1; i < result.Count; i++)
            {
                var minDistance = cities.GetDistance(result[i - 1], result[i]);
                var next = i;
                //Index der nähesten Stadt zur Stadt 'result[i-1]' suchen
                for (int j = i+1; j < result.Count; j++)
                {
                    var distance = cities.GetDistance(result[j], result[i - 1]);
                    if (minDistance > distance)
                    {
                        minDistance = distance;
                        next = j;
                    }
                }
                result.Swap(i, next);
            }
            return result;
        }
    }
}