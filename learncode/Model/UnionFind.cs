using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.Model
{
    public class UnionFind
    {
        private List<int> parent;

        public UnionFind()
        {
            parent = new List<int>();
        }
        public void Init(int n)
        {
            for (int i = 0; i < n; i++)
            {
                parent.Add(i);
            }
        }
        public int Find(int x)
        {
            if (parent[x] == x)
                return x;
            else
            {
                parent[x] = Find(parent[x]);
                return parent[x];
            }
        }
        public void merge(int i, int j)
        {
            parent[Find(j)] = Find(i);
        }
    }
}
