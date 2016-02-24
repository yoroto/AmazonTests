using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BinaryTrees
{
    [TestFixture]
    public class DepthLists
    {

        public static IList<List<Node<T>>> Get<T>(Node<T> root)
        {
            IList<List<Node<T>>> lists = new List<List<Node<T>>>();

            Get(root, lists, 0);

            return lists;
        }

        private static void Get<T>(Node<T> root, IList<List<Node<T>>> lists, int level)
        {
            if(lists.Count == level)
                lists.Add(new List<Node<T>>());
            lists[level].Add(root);
            Get(root.Left, lists, level);
            Get(root.Right, lists, level);
        }
    }
}
