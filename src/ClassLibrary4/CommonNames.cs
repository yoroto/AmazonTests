using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4
{
    public class CommonNames
    {
        public static IEnumerable<string> Get(string[] a, string[] b)
        {
            var itemsInA = new HashSet<string>(a);

            foreach (var item in b)
                if (itemsInA.Contains(item))
                    yield return item;
        }
    }
}
