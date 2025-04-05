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

        static void Main(string[] args)
        {
            Console.Title = "Suduko Game";
            Console.CursorVisible = false;

            drawBoard2();
            numInStart();
            
        }
    }
}
