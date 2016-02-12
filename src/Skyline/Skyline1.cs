using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline
{
    public class Skyline1
    {
        public static IEnumerable<Tuple<int, int>> Skyline(Tuple<int, int, int>[] input)
        {
            var heights = new int[100];
            var max = 0;

            foreach (var p in input)
            {
                if (p.Item2 - 1 >= heights.Length)
                {
                    var newHeights = new int[heights.Length*2];
                    Array.Copy(heights, newHeights, max);
                    heights = newHeights;
                    max = p.Item2 - 1;
                }

                for (var i = p.Item1; i < p.Item2; i++)
                {
                    if (p.Item3 > heights[i])
                        heights[i] = p.Item3;
                }
            }

            for (var i = 0; i <= max; i++)
            {
                if (i > 0 && heights[i-1] == heights[i])
                    continue;
                yield return new Tuple<int, int>(i, heights[i]);
            }
        }
    }
}
