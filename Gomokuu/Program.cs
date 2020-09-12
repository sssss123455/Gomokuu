using System;

namespace Gomokuu
{
    class Program
    {
        static void Main(string[] args)
        {
            bool answer = false;
            string text = "No winner";
            int count = 0;
            char[,] board = Board.Get();
            while (answer != true)
            {
                if (count % 2 == 0)
                {
                    FirstPlayer.GetStep(board, count);
                    answer = Five.Search(board, 'x');
                    if (answer == true)
                    {
                        text = "The first player is win";
                        
                    }

                }
                else
                {
                    SecondPlayer.GetStep(board, count);
                    answer = Five.Search(board, 'o');
                    if (answer == true)
                    {
                        text = "The second player is win";
                        
                    }
                }
                count++;

            }
            Console.WriteLine(text);
            Board.Show(board);

        }
    }
}
