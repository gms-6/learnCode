using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.classModel.Ap
{
    public class Cell
    {
        public int g;
        public int h;
        public CellCoordinate Coordinate { get; set; }
        public Cell parent;
        public Cell(CellCoordinate newCor, Cell par)
        {
            Coordinate = newCor;
            parent = par;
        }
        public int GetF()
        {
            return g + h;
        }
    }
}
