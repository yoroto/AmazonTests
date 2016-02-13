using System;
using System.Collections.Generic;

namespace Skyline
{
    public class Skyline1
    {
        public static IEnumerable<int[]> Skyline(int[,] input)
        {
            var heights = new int[100];
            var max = 0;

            for (var p = 0; p < input.GetUpperBound(0); p++)
            {
                if (input[p,1] - 1 >= heights.Length)
                {
                    var newHeights = new int[heights.Length*2];
                    Array.Copy(heights, newHeights, max);
                    heights = newHeights;
                    max = input[p,1] - 1;
                }

                for (var i = input[p,0]; i < input[p,1]; i++)
                {
                    if (input[p,2] > heights[i])
                        heights[i] = input[p,2];
                }
            }

            for (var i = 0; i <= max; i++)
            {
                if (i > 0 && heights[i-1] == heights[i])
                    continue;
                yield return new[] { i, heights[i] };
            }
        }
    }
}
