using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace learncode.classModel.Ap
{
    public class CellCoordinate
    {
        public int X;
        public int Y;
        public static bool operator==(CellCoordinate cor1,CellCoordinate cor2)
        {
            if (cor1.X == cor2.X && cor1.Y == cor2.Y)
                return true;
            else
                return false;
        }
        public static bool operator!=(CellCoordinate cor1, CellCoordinate cor2)
        {
            if (cor1.X != cor2.X || cor1.Y != cor2.Y)
                return true;
            else
                return false;
        }
        public CellCoordinate(int x,int y)
        {
            X= x; ;
            Y = y;
        }
        public CellCoordinate()
        {

        }

    }
}
