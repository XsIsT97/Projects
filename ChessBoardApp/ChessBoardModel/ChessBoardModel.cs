using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Board
    {
        // Size of board usually 8x8
        public int Size { get; set; }
        
        // 2D array type Cell
        public Cell[,] theGrid { get; set; }

        //constructor
        public Board (int s)
        {
            //initial size of board
            Size = s;

            //create a new 2D array of type cell
            theGrid = new Cell[Size, Size];

            //fill the 2D array with the new Cell, with x and y coordinates
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public bool isSafe(int x, int y)
        {
            if (x < 0 || x >= Size || y < 0 || y >= Size)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void MarkNextLegalMoves (Cell currentCell, string chessPiece)
        {
            // clear all previous legal move
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].LegalNextMove = false;
                    theGrid[i, j].CurrentlyOccupied = false;
                }
            }

            // find all legal moves and mark cells as "legal"

            switch (chessPiece)
            {
                case "Knight":
                    if (isSafe(currentCell.RowNumber + 2, currentCell.ColNumber + 1))
                    {
                        theGrid[currentCell.RowNumber + 2, currentCell.ColNumber + 1].LegalNextMove = true;
                    }
                    if (isSafe(currentCell.RowNumber + 2, currentCell.ColNumber - 1))
                    {
                        theGrid[currentCell.RowNumber + 2, currentCell.ColNumber - 1].LegalNextMove = true;
                    }
                    if (isSafe(currentCell.RowNumber - 2, currentCell.ColNumber + 1))
                    {
                        theGrid[currentCell.RowNumber - 2, currentCell.ColNumber + 1].LegalNextMove = true;
                    }
                    if (isSafe(currentCell.RowNumber - 2, currentCell.ColNumber - 1))
                    {
                        theGrid[currentCell.RowNumber - 2, currentCell.ColNumber - 1].LegalNextMove = true;
                    }
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColNumber + 2))
                    {
                        theGrid[currentCell.RowNumber + 1, currentCell.ColNumber + 2].LegalNextMove = true;
                    }
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColNumber - 2))
                    {
                        theGrid[currentCell.RowNumber + 1, currentCell.ColNumber - 2].LegalNextMove = true;
                    }
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColNumber + 2))
                    {
                        theGrid[currentCell.RowNumber - 1, currentCell.ColNumber + 2].LegalNextMove = true;
                    }
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColNumber - 2))
                    {
                        theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 2].LegalNextMove = true;
                    }

                    break;

                case "King":
                    break;

                case "Rook":
                    break;

                case "Bishop":
                    break;

                case "Queen":
                    break;

                default:
                    break;
            }
            theGrid[currentCell.RowNumber, currentCell.ColNumber].CurrentlyOccupied = true;
        }
    }
}
