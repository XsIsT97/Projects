﻿using System;
using ChessBoardModel;

namespace ChessBoard
{
    internal class Program
    {
        static Board myBoard = new Board(8);
        static void Main(string[] args)
        {
            // show the empty chess board
            printBoard(myBoard);

            // ask the user for an x and y coordinate where we will place a piece
            Cell currentCell = setCurrentCell();
            currentCell.CurrentlyOccupied = true;
            Console.WriteLine("What kind of chess piece would you like to place on the board? Knight, King, Queen, Rook, Bishop?");
            string chessPiece = Console.ReadLine();

            // calculate all legal moves for that piece
            myBoard.MarkNextLegalMoves(currentCell, chessPiece);

            // print the chess board. Use an "x" for occupied square
            printBoard(myBoard);

            // wait for another enter key press before ending program.
            Console.ReadLine();
        }

        private static Cell setCurrentCell()
        {
            int currentRow = 0;
            int currentCol = 0;
            try
            {
                Console.WriteLine("Enter the current row number");
                currentRow = int.Parse(Console.ReadLine());
            }
            catch 
            {
                Console.WriteLine("Not valid. Enter new number value");
                currentRow = int.Parse(Console.ReadLine());
            }

            try
            {
                Console.WriteLine("Enter the current column number");
                currentCol = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Not valid. Enter new number value");
                currentCol = int.Parse(Console.ReadLine());
            }

            if (currentRow < 0 || currentRow > myBoard.Size || currentCol < 0 || currentCol > myBoard.Size)
            {
                Console.WriteLine("out of range. Using 3,3");
                currentCol = 3;
                currentRow = 3;
            }
            myBoard.theGrid[currentRow -1, currentCol-1].CurrentlyOccupied = true;

            return myBoard.theGrid[currentRow - 1, currentCol - 1];
        }

        private static void printBoard(Board myBoard)
        {
            //print the chess board to the console.
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int b = 0; b < myBoard.Size; b++)
                {
                    Console.Write("+---");
                }
                Console.Write("+");
                Console.WriteLine();
                Console.Write("|");

                for (int j = 0; j < myBoard.Size; j++)
                {

                    Cell c = myBoard.theGrid[i, j];

                    if (c.CurrentlyOccupied == true)
                    {
                        Console.Write(" X ");
                    }
                    else if (c.LegalNextMove == true)
                    {
                        Console.Write(" + ");
                    }
                    else
                    {
                        Console.Write("   ");

                    }
                    Console.Write("|");
                }

                Console.WriteLine();
            }

            for (int d = 0; d < myBoard.Size; d++)
            {
                Console.Write("+---");
            }
            Console.Write("+");
            Console.WriteLine();

            Console.WriteLine("=================================");
        }
    }
}
