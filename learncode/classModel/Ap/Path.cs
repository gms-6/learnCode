using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.classModel.Ap
{
    public class Path
    {
        CellCoordinate mapSize;
        List<CellCoordinate> directions;
        List<CellCoordinate> walls;
        int dirCount;
        Func<CellCoordinate, CellCoordinate, int> Heuristic;

        public Path(int x, int y)
        {
            walls = new List<CellCoordinate>();
            mapSize = new CellCoordinate(x, y);
            directions = new List<CellCoordinate>();
            directions.Clear();
            directions.Add(new CellCoordinate(0, 1));
            directions.Add(new CellCoordinate(0, -1));
            directions.Add(new CellCoordinate(1, 0));
            directions.Add(new CellCoordinate(-1, 0));
            directions.Add(new CellCoordinate(1, 1));
            directions.Add(new CellCoordinate(1, -1));
            directions.Add(new CellCoordinate(-1, 1));
            directions.Add(new CellCoordinate(-1, -1));
            dirCount = 4;
            Heuristic = Euclidean;
        }
        public void SetVerticalOrDiagonal(direction dir)
        {
            switch(dir)
            {
                case direction.Around:
                    dirCount = 4;
                    break;
                case direction.Diagonal:
                    dirCount = 8;
                    break;
            }
        }
        public void AddWalls(int x, int y)
        {
            walls.Add(new CellCoordinate(x, y));
        }
        public void RemoveAllWalls()
        {
            walls.Clear();
        }
        public void ShowPath(int maxX,int maxY, CellCoordinate start, CellCoordinate end)
        {
            
        }

        public List<CellCoordinate> GetPath(CellCoordinate start, CellCoordinate end)
        {
            List<Node> openSet = new List<Node>();
            List<Node> closeSet = new List<Node>();
            Node current = null;
            openSet.Add(new Node(start));
            while (openSet.Count != 0)
            {
                current = openSet[0];
                foreach (var node in openSet)
                {
                    if (node.GetF() < current.GetF())
                    {
                        current = node;
                    }
                }
                if (current.Coordinate == end)
                    break;
                closeSet.Add(current);
                openSet.Remove(current);
                for (int i=0;i<dirCount;++i)
                {
                    CellCoordinate newCor = new CellCoordinate(current.Coordinate.X + directions[i].X, current.Coordinate.Y + directions[i].Y);
                    if (isWalls(newCor) || FindNodeInList(closeSet, newCor)==null)
                        continue;
                    int cost = current.g +i<4 ? 10 : 14;
                    Node next = FindNodeInList(openSet,newCor);
                    if(next==null)
                    {
                        next = new Node(newCor,current);
                        next.g=cost;
                        next.h = Heuristic(newCor,end);
                        openSet.Add(next);
                    }
                    else
                    {
                        if(cost<next.g)
                        {
                            next.g=cost;
                            next.parent = current;
                        }    
                    }
                }
            }
            List<CellCoordinate> path = new List<CellCoordinate>();
            while(current!=null)
            {
                path.Add(current.Coordinate);
                current = current.parent;
            }
            path.Reverse();

            return path;
        }
        private bool isWalls(CellCoordinate coordinate)
        {
            foreach(var tmp in walls)
            {
                if(tmp==coordinate)
                    return true;
            }
            if (coordinate.X <= 0 || coordinate.X > mapSize.X || coordinate.Y <= 0 || coordinate.Y > mapSize.Y)
                return true;
            return false;
        }
        public Node FindNodeInList(List<Node> set, CellCoordinate coordinate)
        {
            foreach(var tmp in set)
            {
                if(tmp.Coordinate==coordinate)
                    return tmp;
            }
            return null;
        }
        private int Euclidean(CellCoordinate cor1,CellCoordinate cor2)
        {
            return (int)Math.Sqrt(Math.Pow(cor1.X-cor2.X,2)+Math.Pow(cor1.Y-cor2.Y,2));
        }
        public int manhatten(CellCoordinate cor1,CellCoordinate cor2)
        {
            return Math.Abs(cor1.X - cor2.X) + Math.Abs(cor1.Y-cor2.Y);
        }
    }
}
