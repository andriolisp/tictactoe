using System;
using System.Threading;

namespace TicTacToe
{
    class Program
    {
        private static Game ticTacToe = new Game();

        private static void DrawBoard()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}   ", ticTacToe[7], ticTacToe[8], ticTacToe[9]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}   ", ticTacToe[4], ticTacToe[5], ticTacToe[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}   ", ticTacToe[1], ticTacToe[2], ticTacToe[3]);
            Console.WriteLine("     |     |      ");
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1 plays symbol \"X\", player 2 plays symbol \"O\"");

                DrawBoard();

                if (ticTacToe.Player == 1) Console.WriteLine("Player 1 (X), enter the number position: ");
                else Console.WriteLine("Player 2 (O), enter the position: ");


                try
                {
                    int position = int.Parse(Console.ReadLine());
                    if(!ticTacToe.Play(position))
                    {
                        throw new FormatException();
                    }
                } catch(FormatException)
                {
                    Console.WriteLine("Invalid position, play again.");
                };
                Thread.Sleep(1000);
            } while (ticTacToe.Winner == String.Empty);

            Console.Clear();
            DrawBoard();

            Console.WriteLine("\n{0}", ticTacToe.Winner);
        }
    }
}
