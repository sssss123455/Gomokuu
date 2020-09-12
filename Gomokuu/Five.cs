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
            int size = Сoordinates.Get(board, symbol).Count;
            var positionsForRow = Сoordinates.Get(board, symbol).OrderBy(i => i.Row).ThenBy(i => i.Column);
            for (int i = 0; i < size; i++)
            {
                int count = 1;
                for (int j = 0; j < size; j++)
                {
                    if (positionsForRow.ElementAt(i).Row == positionsForRow.ElementAt(j).Row && i != j)
                    {
                        count += 1;
                        if (count == 5)
                            break;
                    }
                }
                if (i < size - 4 && count == 5 && positionsForRow.ElementAt(i).Column == positionsForRow.ElementAt(i + 1).Column - 1 && positionsForRow.ElementAt(i).Column == positionsForRow.ElementAt(i + 2).Column - 2 && positionsForRow.ElementAt(i).Column == positionsForRow.ElementAt(i + 3).Column - 3 && positionsForRow.ElementAt(i).Column == positionsForRow.ElementAt(i + 4).Column - 4)
                {
                    mainAnswer = true;
                    Console.WriteLine("1 " + symbol);
                }
            }
            //------------------------------------------------------------------------------------------------------------
            var positionsForColumn = Сoordinates.Get(board, symbol).OrderBy(i => i.Column).ThenBy(i => i.Row);
            for (int i = 0; i < size; i++)
            {
                int count2 = 1;
                for (int j = 0; j < size; j++)
                {
                    if (positionsForColumn.ElementAt(i).Column == positionsForColumn.ElementAt(j).Column && i != j)
                    {
                        count2 += 1;
                        if (count2 == 5)
                            break;
                    }
                }
                if (i < size - 4 && count2 == 5 && positionsForColumn.ElementAt(i).Row == positionsForColumn.ElementAt(i + 1).Row - 1 && positionsForColumn.ElementAt(i).Row == positionsForColumn.ElementAt(i + 2).Row - 2 && positionsForColumn.ElementAt(i).Row == positionsForColumn.ElementAt(i + 3).Row - 3 && positionsForColumn.ElementAt(i).Row == positionsForColumn.ElementAt(i + 4).Row - 4)
                {
                    mainAnswer = true;
                    Console.WriteLine("2 " + symbol);
                }
            }
            //----------------------------------------------------------------------------------------------------------------
            List<Position> firstForDiogonal = new List<Position>();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((positionsForRow.ElementAt(i).Row == positionsForRow.ElementAt(j).Row - 1 && positionsForRow.ElementAt(i).Column == positionsForRow.ElementAt(j).Column - 1))
                    {
                        firstForDiogonal.Add(new Position { Row = positionsForRow.ElementAt(i).Row, Column = positionsForRow.ElementAt(i).Column });
                        firstForDiogonal.Add(new Position { Row = positionsForRow.ElementAt(j).Row, Column = positionsForRow.ElementAt(j).Column });
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
                if (firstForDiogonalTwo.ElementAt(i).Column == firstForDiogonalTwo.ElementAt(i + 1).Column - 1 && firstForDiogonalTwo.ElementAt(i).Column == firstForDiogonalTwo.ElementAt(i + 2).Column - 2 && firstForDiogonalTwo.ElementAt(i).Column == firstForDiogonalTwo.ElementAt(i + 3).Column - 3 && firstForDiogonalTwo.ElementAt(i).Column == firstForDiogonalTwo.ElementAt(i + 4).Column - 4 && firstForDiogonalTwo.ElementAt(i).Row == firstForDiogonalTwo.ElementAt(i + 1).Row - 1 && firstForDiogonalTwo.ElementAt(i).Row == firstForDiogonalTwo.ElementAt(i + 2).Row - 2 && firstForDiogonalTwo.ElementAt(i).Row == firstForDiogonalTwo.ElementAt(i + 3).Row - 3 && firstForDiogonalTwo.ElementAt(i).Row == firstForDiogonalTwo.ElementAt( i + 4).Row - 4)
                {
                    mainAnswer = true;
                    Console.WriteLine("3 " + symbol);
                }
            }
            //----------------------------------------------------------------------------------------------------
            List<Position> secondForDiogonal = new List<Position>();
            var positions= Сoordinates.Get(board, symbol).OrderByDescending(i => i.Row);
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
                if (secondForDiogonal[i].Column == secondForDiogonal[i + 1].Column - 1 && secondForDiogonal[i].Column == secondForDiogonal[i + 2].Column - 2 && secondForDiogonal[i].Column == secondForDiogonal[i + 3].Column - 3 && secondForDiogonal[i].Column == secondForDiogonal[i + 4].Column - 4 && secondForDiogonal[i].Row == secondForDiogonal[i + 1].Row + 1 && secondForDiogonal[i].Row == secondForDiogonal[i + 2].Row + 2 && secondForDiogonal[i].Row == secondForDiogonal[i + 3].Row + 3 && secondForDiogonal[i].Row == secondForDiogonal[i + 4].Row + 4)
                {
                    mainAnswer = true;
                    Console.WriteLine("4 "+symbol);
                    
                }
            }
            return mainAnswer;
        }
    }
}
