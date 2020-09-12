using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomokuu
{
    public class Counter
    {
        public static List<Hindrance> CountForThree(char[,] board,char symbol)
        {
            List<Hindrance> three = new List<Hindrance>();
            int size = Coordinat.Get(board, symbol).Count;
            var positionsForRow = Coordinat.Get(board, symbol).OrderBy(i=>i.Row).ThenBy(i=>i.Column);
            for (int i = 0; i < size; i++)
            {

                int k = 1;
                for (int j = 0; j < size; j++)
                {
                    if (i != j && positionsForRow.ElementAt(i).Column == positionsForRow.ElementAt(j).Column - k && positionsForRow.ElementAt(i).Row == positionsForRow.ElementAt(j).Row)
                    {
                        k++;
                        if (k == 3)
                        {
                            three.Add(new Hindrance { Case = true,RowFirst = positionsForRow.ElementAt(i).Row, RowLast = positionsForRow.ElementAt(i).Row, ColumnFirst = positionsForRow.ElementAt(i).Column, ColumnLast = positionsForRow.ElementAt(i).Column + 2, StepR = 0, StepC = 1 }) ;

                        }
                    }
                }
                //int count = 1;
                //for (int j = 0; j < size; j++)
                //{
                //    if (positionsForRow.ElementAt(i).Row == positionsForRow.ElementAt(j).Row && i != j)
                //    {
                //        count+=1;
                //        if (count == 3)
                //            break;
                //    }
                //}
                //if (i< size - 2 && count == 3 && positionsForRow.ElementAt(i).Column == positionsForRow.ElementAt(i + 1).Column - 1 && positionsForRow.ElementAt(i).Column == positionsForRow.ElementAt(i + 2).Column - 2)
                //{
                //    three.Add(new Hindrance { Case = true,RowFirst = positionsForRow.ElementAt(i).Row, RowLast = positionsForRow.ElementAt(i).Row, ColumnFirst = positionsForRow.ElementAt(i).Column, ColumnLast = positionsForRow.ElementAt(i).Column + 2, StepR = 0, StepC = 1 }) ;
                //}
            }
            //----------------------
            var positionsForColumn = Coordinat.Get(board, symbol).OrderBy(i => i.Column).ThenBy(i => i.Row);
            for (int i = 0; i < size; i++)
            {
                int k = 1;
                for (int j = 0; j < size; j++)
                {
                    if (i != j && positionsForColumn.ElementAt(i).Column == positionsForColumn.ElementAt(j).Column && positionsForColumn.ElementAt(i).Row == positionsForColumn.ElementAt(j).Row - k)
                    {
                        k++;
                        if (k == 3)
                        {
                            three.Add(new Hindrance {Case=true, RowFirst = positionsForColumn.ElementAt(i).Row, RowLast = positionsForColumn.ElementAt(i).Row + 2, ColumnFirst = positionsForColumn.ElementAt(i).Column, ColumnLast = positionsForColumn.ElementAt(i).Column, StepC = 0, StepR = 1 });

                        }
                    }
                }
                //int count2 = 1;
                //for (int j = 0; j < size; j++)
                //{
                //    if (positionsForColumn.ElementAt(i).Column == positionsForColumn.ElementAt(j).Column && i != j)
                //    {
                //        count2 += 1;
                //        if (count2 == 3)
                //            break;
                //    }
                //}
                //if (i < size - 2 && count2 == 3 && positionsForColumn.ElementAt(i).Row == positionsForColumn.ElementAt(i + 1).Row - 1 && positionsForColumn.ElementAt(i).Row == positionsForColumn.ElementAt(i + 2).Row - 2)
                //{
                //    three.Add(new Hindrance {Case=true, RowFirst = positionsForColumn.ElementAt(i).Row, RowLast = positionsForColumn.ElementAt(i).Row + 2, ColumnFirst = positionsForColumn.ElementAt(i).Column, ColumnLast = positionsForColumn.ElementAt(i).Column, StepC = 0, StepR = 1 });
                //}
            }
            //--------------------------------------------------------------
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
            for (int i = 0; i < firstForDiogonal.Count - 2; i++)
            {
                int k = 1;
                for (int j = 0; j < firstForDiogonal.Count; j++)
                {
                    if (i != j && firstForDiogonal.ElementAt(i).Column == firstForDiogonal.ElementAt(j).Column - k && firstForDiogonal.ElementAt(i).Row == firstForDiogonal.ElementAt(j).Row - k)
                    {
                        k++;
                        if (k == 3)
                        {
                            three.Add(new Hindrance { Case = true, ColumnFirst = firstForDiogonal[i].Column, ColumnLast = firstForDiogonal[i ].Column + 2, RowFirst = firstForDiogonal[i].Row, RowLast = firstForDiogonal[i ].Row + 2, StepC = 1, StepR = 1 });

                        }
                    }
                }
            }
            //--------------------------------------------------------------
            List<Position> secondForDiogonal = new List<Position>();
            positionsForRow = positionsForRow.OrderByDescending(i => i.Row);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((positionsForRow.ElementAt(i).Row == positionsForRow.ElementAt(j).Row + 1 && positionsForRow.ElementAt(i).Column == positionsForRow.ElementAt(j).Column - 1))
                    {
                        secondForDiogonal.Add(new Position { Row = positionsForRow.ElementAt(i).Row, Column = positionsForRow.ElementAt(i).Column });
                        secondForDiogonal.Add(new Position { Row = positionsForRow.ElementAt(j).Row, Column = positionsForRow.ElementAt(j).Column });
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
            for (int i = 0; i < secondForDiogonal.Count - 2; i++)
            {
                int k = 1;
                for (int j = 0; j < secondForDiogonal.Count; j++)
                {
                    if (i != j && secondForDiogonal[i].Column == secondForDiogonal[j].Column - k && secondForDiogonal[i].Row == secondForDiogonal[j].Row + k)
                    {
                        k++;
                        if (k == 3)
                        {
                            three.Add(new Hindrance { Case = true, ColumnFirst = secondForDiogonal[i].Column, ColumnLast = secondForDiogonal[i].Column + 3, RowFirst = secondForDiogonal[i].Row, RowLast = secondForDiogonal[i].Row - 3, StepC = 1, StepR = -1 });

                        }
                    }
                }
            }
            return three;
        }
        public static List<Hindrance> CountForFour(char[,] board, char symbol)
        {
            List<Hindrance> four = new List<Hindrance>();
            int size = Coordinat.Get(board, symbol).Count;
            var positionsForRow = Coordinat.Get(board, symbol).OrderBy(i => i.Row).ThenBy(i => i.Column);
            for (int i = 0; i < size; i++)
            {
                int k = 1;
                for (int j = 0; j < size; j++)
                {
                    if (i != j && positionsForRow.ElementAt(i).Column == positionsForRow.ElementAt(j).Column - k && positionsForRow.ElementAt(i).Row == positionsForRow.ElementAt(j).Row)
                    {
                        k++;
                        if (k == 4)
                        {
                            four.Add(new Hindrance { Case = true, RowFirst = positionsForRow.ElementAt(i).Row, RowLast = positionsForRow.ElementAt(i).Row, ColumnFirst = positionsForRow.ElementAt(i).Column, ColumnLast = positionsForRow.ElementAt(i).Column + 2, StepR = 0, StepC = 1 });

                        }
                    }
                }
            }
            //----------------------
            var positionsForColumn = Coordinat.Get(board, symbol).OrderBy(i => i.Column).ThenBy(i => i.Row);
            for (int i = 0; i < size; i++)
            {
                int k = 1;
                for (int j = 0; j < size; j++)
                {
                    if (i != j && positionsForColumn.ElementAt(i).Column == positionsForColumn.ElementAt(j).Column && positionsForColumn.ElementAt(i).Row == positionsForColumn.ElementAt(j).Row - k)
                    {
                        k++;
                        if (k == 4)
                        {
                            four.Add(new Hindrance { Case = true, RowFirst = positionsForColumn.ElementAt(i).Row, RowLast = positionsForColumn.ElementAt(i).Row + 2, ColumnFirst = positionsForColumn.ElementAt(i).Column, ColumnLast = positionsForColumn.ElementAt(i).Column, StepC = 0, StepR = 1 });

                        }
                    }
                }
            }
            //-----------------------------------------------------------------------------------------------------
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
            for (int i = 0; i < firstForDiogonal.Count - 3; i++)
            {
                int k = 1;
                for (int j = 0; j < firstForDiogonal.Count; j++)
                {
                    if (i != j && firstForDiogonal.ElementAt(i).Column == firstForDiogonal.ElementAt(j).Column - k && firstForDiogonal.ElementAt(i).Row == firstForDiogonal.ElementAt(j).Row - k)
                    {
                        k++;
                        if (k == 4)
                        {
                            four.Add(new Hindrance { Case = true, ColumnFirst = firstForDiogonal[i].Column, ColumnLast = firstForDiogonal[i].Column + 2, RowFirst = firstForDiogonal[i].Row, RowLast = firstForDiogonal[i].Row + 2, StepC = 1, StepR = 1 });

                        }
                    }
                }
            }
            //-----------------------------------------------------------------
            List<Position> secondForDiogonal = new List<Position>();
            positionsForRow = positionsForRow.OrderByDescending(i => i.Row);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((positionsForRow.ElementAt(i).Row == positionsForRow.ElementAt(j).Row + 1 && positionsForRow.ElementAt(i).Column == positionsForRow.ElementAt(j).Column - 1))
                    {
                        secondForDiogonal.Add(new Position { Row = positionsForRow.ElementAt(i).Row, Column = positionsForRow.ElementAt(i).Column });
                        secondForDiogonal.Add(new Position { Row = positionsForRow.ElementAt(j).Row, Column = positionsForRow.ElementAt(j).Column });
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
            for (int i = 0; i < secondForDiogonal.Count - 3; i++)
            {
                int k = 1;
                for (int j = 0; j < secondForDiogonal.Count; j++)
                {
                    if (i != j && secondForDiogonal[i].Column == secondForDiogonal[j].Column - k && secondForDiogonal[i].Row == secondForDiogonal[j].Row + k)
                    {
                        k++;
                        if (k == 4)
                        {
                            four.Add(new Hindrance { Case = true, ColumnFirst = secondForDiogonal[i].Column, ColumnLast = secondForDiogonal[i].Column + 3, RowFirst = secondForDiogonal[i].Row, RowLast = secondForDiogonal[i].Row - 3, StepC = 1, StepR = -1 });

                        }
                    }
                }
            }

            return four;
        }
    }
}
