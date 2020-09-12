using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomokuu
{
    public class Five
    {
        public static bool Search(char[,] board, char symbol)
        {
            bool mainAnswer = false;
            int size = Coordinat.Get(board, symbol).Count;
            var positionsForRow = Coordinat.Get(board, symbol).OrderBy(i => i.Row).ThenBy(i => i.Column);
            for (int i = 0; i < size; i++)
            {
                int k = 1;
                for (int j = 0; j < size; j++)
                {
                    if (i != j && positionsForRow.ElementAt(i).Column == positionsForRow.ElementAt(j).Column-k && positionsForRow.ElementAt(i).Row == positionsForRow.ElementAt(j).Row)
                    {
                        k++;
                        if (k == 5)
                        {
                            mainAnswer = true;
                            //Console.WriteLine("1 " + symbol);
                        }
                    }
                }
            }
            //------------------------------------------------------------------------------------------------------------
            var positionsForColumn = Coordinat.Get(board, symbol).OrderBy(i => i.Column).ThenBy(i => i.Row);
            for (int i = 0; i < size; i++)
            {
                int k = 1;
                for (int j = 0; j < size; j++)
                {
                    if (i != j && positionsForColumn.ElementAt(i).Column == positionsForColumn.ElementAt(j).Column && positionsForColumn.ElementAt(i).Row == positionsForColumn.ElementAt(j).Row - k)
                    {
                        k++;
                        if (k == 5)
                        {
                            mainAnswer = true;
                            //Console.WriteLine("2 " + symbol);
                        }
                    }
                }
            }
            //----------------------------------------------------------------------------------------------------------------
            List<Position> firstForDiogonal = new List<Position>();
            var positionsOne = Coordinat.Get(board, symbol).OrderBy(i => i.Row).ThenBy(i => i.Column);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((positionsOne.ElementAt(i).Row == positionsOne.ElementAt(j).Row - 1 && positionsOne.ElementAt(i).Column == positionsOne.ElementAt(j).Column - 1))
                    {
                        firstForDiogonal.Add(new Position { Row = positionsOne.ElementAt(i).Row, Column = positionsOne.ElementAt(i).Column });
                        firstForDiogonal.Add(new Position { Row = positionsOne.ElementAt(j).Row, Column = positionsOne.ElementAt(j).Column });
                    }
                }
            }
            for (int i = 0; i < firstForDiogonal.Count; i++)
            {
                for (int j = 0; j < firstForDiogonal.Count; j++)
                {
                    if (firstForDiogonal[i].Row == firstForDiogonal[j].Row && firstForDiogonal[i].Column == firstForDiogonal[j].Column && i != j)
                    {
                        firstForDiogonal.RemoveAt(i);
                    }
                }
            }
            var firstForDiogonalTwo = firstForDiogonal.OrderBy(i=>i.Row);
            for (int i = 0; i < firstForDiogonal.Count - 4; i++)
            {
                int k = 1;
                for (int j = 0; j < firstForDiogonal.Count; j++)
                {
                    if (i != j && firstForDiogonalTwo.ElementAt(i).Column == firstForDiogonalTwo.ElementAt(j).Column - k && firstForDiogonalTwo.ElementAt(i).Row == firstForDiogonalTwo.ElementAt(j).Row - k)
                    {
                        k++;
                        if (k == 5)
                        {
                            mainAnswer = true;
                            //Console.WriteLine("3 " + symbol);
                        }
                    }
                }
            }
            //----------------------------------------------------------------------------------------------------
            List<Position> secondForDiogonal = new List<Position>();
            var positions= Coordinat.Get(board, symbol).OrderByDescending(i => i.Row);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((positions.ElementAt(i).Row == positions.ElementAt(j).Row + 1 && positions.ElementAt(i).Column == positions.ElementAt(j).Column - 1))
                    {
                        secondForDiogonal.Add(new Position { Row = positions.ElementAt(i).Row, Column = positions.ElementAt(i).Column });
                        secondForDiogonal.Add(new Position { Row = positions.ElementAt(j).Row, Column = positions.ElementAt(j).Column });
                    }
                }
            }
            for (int i = 0; i < secondForDiogonal.Count; i++)
            {
                for (int j = 0; j < secondForDiogonal.Count; j++)
                {
                    if (secondForDiogonal[i].Row == secondForDiogonal[j].Row && secondForDiogonal[i].Column == secondForDiogonal[j].Column && i != j)
                    {
                        secondForDiogonal.RemoveAt(i);
                    }
                }
            }
            for (int i = 0; i < secondForDiogonal.Count - 4; i++)
            {
                int k = 1;
                for (int j = 0; j < secondForDiogonal.Count; j++)
                {
                    if (i != j && secondForDiogonal[i].Column == secondForDiogonal[j].Column - k && secondForDiogonal[i].Row == secondForDiogonal[j].Row + k)
                    {
                        k++;
                        if (k == 5)
                        {
                            mainAnswer = true;
                           // Console.WriteLine("4 " + symbol);
                        }
                    }
                }
            }
            return mainAnswer;
        }
    }
}
