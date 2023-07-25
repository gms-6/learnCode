using learncode.LinqModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.LinqModel
{
    public class LinqTest
    {
        IList<Racer> racer=new List<Racer>();
        public IEnumerable<bool> GetRacers()
        {
            var res = racer.Where(r => r.FirstName == "N").Where(r => r.Wins == 1).Select(r=>r.Starts>=2);
            return res;
        }
    }
}
