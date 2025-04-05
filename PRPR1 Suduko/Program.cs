using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRPR1_Suduko
{
    class Program
    {
        private static int[,] board = new int[9, 9];
        private static int cursorX = 0;
        private static int cursorY = 0;

        /*public static void drawBoard()
         {
             for (int row = 0; row < 9; row++)
             {
                 if (row % 3 == 0)
                 {
                     Console.WriteLine("_");
                 }

                 for (int col = 0; col < 9; col++)
                 {
                     if (col % 3 == 0)
                     {
                         Console.Write("|");
                     }
                     else
                     {
                         Console.Write(" ");
                     }
                     Console.Write("-");
                 }

                 Console.WriteLine("|");
             }
             Console.WriteLine("------------------------");
         }
        */ //Ugly


        static void drawBoard2()
        {
          
            Console.Clear();
            Console.WriteLine("Use arrow keys to move and only 1-9 nums are valid");


            for (int y = 0; y < 9; y++)
            {
                if ( y % 3 == 0 && y != 0)
                {
                    Console.WriteLine("------+------+------");
                }

                for (int x = 0; x < 9; x++)
                {
                    if (x % 3 == 0 && x != 0)
                    {
                        Console.Write("| ");
                    }


                    if ( x == cursorX && y == cursorY)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.Write(board[y, x] == 0 ? "  " : board[y, x] + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

        }

        static void numInStart()
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    board[y, x] = 0;
                }
            }

        }

        static bool validMoves(int x, int y, int num)
        {
            for (int col = 0; col < 9; col++)
            {
                if (col != x && board[y, col] == num)
                    return false;
            }

            for (int row = 0; row < 9; row++)
            {
                if (row != y && board[row, x] == num)
                    return false;
            }

            int blockX = (x / 3) *3;
            int blockY = (y / 3) * 3;

            for (int row = blockY; row < blockY + 3; row++)
            {
                for (int col = blockX; col < blockX + 3; col++)
                {
                    if ((row != y || col != x) && board[row, col] == num)
                        return  false;
                }
            }
            return true;
        }



        static void Main(string[] args)
        {

            drawBoard2();
            numInStart();


            bool running = true;
            while (running)
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {

                    case ConsoleKey.UpArrow:
                        if (cursorY > 0) cursorY--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursorY < 8) cursorY++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (cursorX > 0) cursorX--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (cursorX < 8) cursorX++;
                        break;

                    case ConsoleKey.D1:
                    case ConsoleKey.D2:
                    case ConsoleKey.D3:
                    case ConsoleKey.D4:
                    case ConsoleKey.D5:
                    case ConsoleKey.D6:
                    case ConsoleKey.D7:
                    case ConsoleKey.D8:
                    case ConsoleKey.D9:

                    int num = (int)key - (int)ConsoleKey.D0;
                        
                    if (validMoves(cursorX, cursorY, num))
                    {
                   
                            board[cursorY, cursorX] = num;
                    }
                    break;

                    case ConsoleKey.Backspace:
                        board[cursorY, cursorX] = 0;
                        break;

                }

                drawBoard2();
            }


        }
    }   
}
