using System.Collections.Generic;
using System.Linq;

namespace Gomokuu
{
    public class SecondPlayer
    {
        public static void GetStep(char[,] board, int count)
        {
            bool answer = false;
            List<Position> steps = new List<Position>();
            steps.Add(new Position { Row = 0, Column = 1 });
            steps.Add(new Position { Row = 1, Column = 0 });
            steps.Add(new Position { Row = -1, Column = -1 });
            steps.Add(new Position { Row = 1, Column = -1 });
            steps.Add(new Position { Row = -1, Column = 1 });
            steps.Add(new Position { Row = 1, Column = 1 });
            steps.Add(new Position { Row = 0, Column = -1 });
            steps.Add(new Position { Row = -1, Column = 0 });
            List<Position> positionsX = Сoordinates.Get(board, 'x');
            List<Hindrance> hindrancesForThree = Counter.CountForThree(board, 'x');
            List<Hindrance> hindrancesForFour = Counter.CountForFour(board, 'x');
            List<Hindrance> easyWin = Counter.CountForFour(board, 'o');
            if (count == 1)
            {
                int num = RandomNumber.Get(0, 7);
                Position step = steps[num];
                board[positionsX.First().Row + step.Row, positionsX.First().Column + step.Column] = 'o';
            }
            else
            {
                bool answer2 = false;
                if (answer2 != true)
                {

                    foreach (var list in easyWin)
                    {
                        if (list.Case == true)
                        {
                            int rowF = list.RowFirst - list.StepR;
                            int columnF = list.ColumnFirst - list.StepC;
                            if (rowF >= 0 && rowF <= 14 && columnF >= 0 && columnF <= 14 && board[rowF, columnF] == '_')
                            {
                                board[rowF, columnF] = 'o';
                                list.Case = false;
                                answer2 = true;
                                break;
                            }
                            else
                            {
                                int rowL = list.RowLast + list.StepR;
                                int columnL = list.ColumnLast + list.StepC;
                                if (rowL >= 0 && rowL <= 14 && columnL >= 0 && columnL <= 14 && board[rowL, columnL] == '_')
                                {
                                    board[rowL, columnL] = 'o';
                                    list.Case = false;
                                    answer2 = true;
                                    break;
                                }

                            }
                        }
                    }
                }
                if (answer2 != true)
                {
                    foreach (var list in hindrancesForFour)
                    {
                        if (list.Case == true)
                        {
                            int rowF = list.RowFirst - list.StepR;
                            int columnF = list.ColumnFirst - list.StepC;
                            if (rowF >= 0 && rowF <= 14 && columnF >= 0 && columnF <= 14 && board[rowF, columnF] == '_')
                            {
                                board[rowF, columnF] = 'o';
                                list.Case = false;
                                answer2 = true;
                                break;
                            }
                            else
                            {
                                int rowL = list.RowLast + list.StepR;
                                int columnL = list.ColumnLast + list.StepC;
                                if (rowL >= 0 && rowL <= 14 && columnL >= 0 && columnL <= 14 && board[rowL, columnL] == '_')
                                {
                                    board[rowL, columnL] = 'o';
                                    list.Case = false;
                                    answer2 = true;
                                    break;
                                }

                            }
                        }
                    }
                }
                if (answer2 != true)
                {
                    foreach (var list in hindrancesForThree)
                    {
                        if (list.Case == true)
                        {
                            int rowF = list.RowFirst - list.StepR;
                            int columnF = list.ColumnFirst - list.StepC;
                            if (rowF >= 0 && rowF <= 14 && columnF >= 0 && columnF <= 14 && board[rowF, columnF] == '_')
                            {
                                board[rowF, columnF] = 'o';
                                list.Case = false;
                                answer2 = true;
                                break;
                            }
                            else
                            {
                                int rowL = list.RowLast + list.StepR;
                                int columnL = list.ColumnLast + list.StepC;
                                if (rowL >= 0 && rowL <= 14 && columnL >= 0 && columnL <= 14 && board[rowL, columnL] == '_')
                                {
                                    board[rowL, columnL] = 'o';
                                    list.Case = false;
                                    answer2 = true;
                                    break;
                                }

                            }
                        }
                    }
                }
                if (answer2 != true)
                {
                    List<Position> positionsForX = Сoordinates.Get(board, 'o');
                    int k = 0;
                    bool answer3 = false;
                    while (answer3 != true)
                    {
                        k++;
                        if (k < 8)
                        {
                            int num = RandomNumber.Get(0, 7);
                            int row = positionsForX.Last().Row + steps[num].Row;
                            int column = positionsForX.Last().Column + steps[num].Column;
                            if (row >= 0 && row <= 14 && column >= 0 && column <= 14)
                            {
                                if (board[row, column] == '_')
                                {
                                    board[row, column] = 'o';
                                    answer = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            List<Position> positionsFree = Сoordinates.Get(board, '_');
                            if (positionsFree.Count > 0)
                            {

                                int num = RandomNumber.Get(0, positionsFree.Count - 1);
                                board[positionsFree[num].Row, positionsFree[num].Column] = 'o';
                                answer = true;
                                break;

                            }
                        }
                    }
                }
            }
        }
    }
}
