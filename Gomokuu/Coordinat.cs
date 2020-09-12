using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomokuu
{
    public  class Coordinat
    {
        public static List<Position> Get(char[,] board,char symbol)
        {
            List<Position> positions = new List<Position>();
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (board[i, j] == symbol)
                    {
                        positions.Add(new Position { Row = i, Column=j });
                    }
                }
            }
            return positions;
        }
    }
}
