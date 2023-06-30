using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.classModel.Ap
{
    public class Node
    {
        public int g;
        public int h;
        public CellCoordinate Coordinate { get; set; }
        public Node parent;
        public Node(CellCoordinate newCor, Node par)
        {
            Coordinate = newCor;
            parent = par;
        }
        public Node(CellCoordinate newCor)
        {
            Coordinate.X=newCor.X;
            Coordinate.Y=newCor.Y;
        }
        public int GetF()
        {
            return g + h;
        }
    }
}
