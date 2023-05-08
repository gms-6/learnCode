using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.classModel
{
    public class RandomizedSet
    {
        Dictionary<int,int> dic;
        Random ran;
        List<int> list;
        public RandomizedSet()
        {
            dic = new Dictionary<int, int>();
            ran = new Random();
            list = new List<int>();
        }

        public bool Insert(int val)
        {
            if (dic.ContainsKey(val))
                return false;
            else
            {
                int index = list.Count;
                dic.Add(val,index);
                list.Add(val);
                return true;
            }
        }

        public bool Remove(int val)
        {
            if(dic.ContainsKey(val))
            {
                int index = dic[val];
                int last = list[list.Count - 1];
                list[index] = last;
                dic[last] = index;
                list.RemoveAt(list.Count-1);
                dic.Remove(val);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetRandom()
        {
            int n = ran.Next(dic.Count);
            
            return list[n];
        }
    }
}
