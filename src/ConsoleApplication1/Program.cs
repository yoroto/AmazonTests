using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace ConsoleApplication1
{
    class Solution
    {
        static string[][] matchDonuts(string[][] donutConstraintPairs, string[][] candidateConstraintPairs)
        {
            var donutMap = new Dictionary<string, string>();
            var result = new List<Tuple<string, string>>();

            for (var i = 0; i < donutConstraintPairs.GetLength(0); i++)
                donutMap.Add(donutConstraintPairs[i][0], donutConstraintPairs[i][1]);

            for(var i = candidateConstraintPairs.GetLength(0) - 1; i >= 0 ; i--)
            {
                if(candidateConstraintPairs[i][1] == "*")
                {
                    foreach (var d in donutMap.Values)
                        result.Add(new Tuple<string, string>(candidateConstraintPairs[i][0], d));
                }
                else if(donutMap.ContainsKey(candidateConstraintPairs[i][1]))
                {
                    result.Add(new Tuple<string, string>(candidateConstraintPairs[i][0], candidateConstraintPairs[i][1]));
                }
                else if(donutMap.ContainsValue(candidateConstraintPairs[i][1]))
                {
                    foreach(var d in donutMap.Where(p => p.Value == candidateConstraintPairs[i][1]).Select(p => p.Key))
                    {
                        result.Add(new Tuple<string, string>(candidateConstraintPairs[i][0], d));
                    }
                }
            }

            return result.Select(t => new[] { t.Item1, t.Item2 }).ToArray();
        }

        static void Main(String[] args)
        {
            string fileName = System.Environment.GetEnvironmentVariable("OUTPUT_PATH");
            TextWriter tw = new StreamWriter(@fileName, true);
            string[][] res;

            int _donutConstraintPairs_rows = 0;
            int _donutConstraintPairs_cols = 0;
            _donutConstraintPairs_rows = Convert.ToInt32(Console.ReadLine());
            _donutConstraintPairs_cols = Convert.ToInt32(Console.ReadLine());

            string[][] _donutConstraintPairs = new string[_donutConstraintPairs_rows][];
            for (int _donutConstraintPairs_i = 0; _donutConstraintPairs_i < _donutConstraintPairs_rows; _donutConstraintPairs_i++)
            {
                _donutConstraintPairs[_donutConstraintPairs_i] = Console.ReadLine().Split(' ');

            }


            int _candidateConstraintPairs_rows = 0;
            int _candidateConstraintPairs_cols = 0;
            _candidateConstraintPairs_rows = Convert.ToInt32(Console.ReadLine());
            _candidateConstraintPairs_cols = Convert.ToInt32(Console.ReadLine());

            string[][] _candidateConstraintPairs = new string[_candidateConstraintPairs_rows][];
            for (int _candidateConstraintPairs_i = 0; _candidateConstraintPairs_i < _candidateConstraintPairs_rows; _candidateConstraintPairs_i++)
            {
                _candidateConstraintPairs[_candidateConstraintPairs_i] = Console.ReadLine().Split(' ');

            }

            res = matchDonuts(_donutConstraintPairs, _candidateConstraintPairs);
            int res_rowLength = res.GetLength(0);
            for (int res_i = 0; res_i < res_rowLength; res_i++)
            {
                for (int res_j = 0; res_j < res[res_i].Length; res_j++)
                {
                    tw.Write(res[res_i][res_j] + " ");
                }
                tw.WriteLine("");
            }

            tw.Flush();
            tw.Close();
        }
    }
}
