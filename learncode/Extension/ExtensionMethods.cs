using learncode.classModel.Ap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.Extension
{
    public static class ExtensionMethods
    {
        public static string GetString(this string s,string fixes)
        {
            return s + fixes;
        }

        public static IQueryable<T> GetQuery<T>(this IQueryable<T> query,int id)
            where T:CellCoordinate
        {
            return query.Where(r=>r.X==id);
        }
        public static IEnumerable<T> GetEnumerable<T>(this IEnumerable<T> query, int id)
            where T : CellCoordinate
        {
            return query.Where(r => r.X == id);
        }
    }
}
