using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
                    switch (chessPiece)
                    {
                        case "Rook":
                            if (i == currentCell.RowNumber)
                            {
                                theGrid[currentCell.RowNumber, j].LegalNextMove = true;
                            }
                            if (j == currentCell.ColNumber)
                            {
                                theGrid[i, currentCell.ColNumber].LegalNextMove = true;
                            }
                           break;
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
                            if (isSafe(currentCell.RowNumber + 1, currentCell.ColNumber + 1))
                            {
                                theGrid[currentCell.RowNumber + 1, currentCell.ColNumber + 1].LegalNextMove = true;
                            }
                            if (isSafe(currentCell.RowNumber + 1, currentCell.ColNumber - 1))
                            {
                                theGrid[currentCell.RowNumber + 1, currentCell.ColNumber - 1].LegalNextMove = true;
                            }
                            if (isSafe(currentCell.RowNumber - 1, currentCell.ColNumber + 1))
                            {
                                theGrid[currentCell.RowNumber - 1, currentCell.ColNumber + 1].LegalNextMove = true;
                            }
                            if (isSafe(currentCell.RowNumber - 1, currentCell.ColNumber - 1))
                            {
                                theGrid[currentCell.RowNumber - 1, currentCell.ColNumber - 1].LegalNextMove = true;
                            }
                            if (isSafe(currentCell.RowNumber, currentCell.ColNumber + 1))
                            {
                                theGrid[currentCell.RowNumber, currentCell.ColNumber + 1].LegalNextMove = true;
                            }
                            if (isSafe(currentCell.RowNumber - 1, currentCell.ColNumber))
                            {
                                theGrid[currentCell.RowNumber - 1, currentCell.ColNumber].LegalNextMove = true;
                            }
                            if (isSafe(currentCell.RowNumber + 1, currentCell.ColNumber))
                            {
                                theGrid[currentCell.RowNumber + 1, currentCell.ColNumber].LegalNextMove = true;
                            }
                            if (isSafe(currentCell.RowNumber, currentCell.ColNumber - 1))
                            {
                                theGrid[currentCell.RowNumber, currentCell.ColNumber - 1].LegalNextMove = true;
                            }

                            break;

                        case "Bishop":
                            for (int k = 0; k < Size; k++)
                            {
                                int rowDiff = currentCell.RowNumber - k;
                                int colDiff = currentCell.ColNumber + rowDiff;
                                int colDiff2 = currentCell.ColNumber - rowDiff;

                                if (colDiff >= 0 && colDiff < Size)
                                {
                                    theGrid[k, colDiff].LegalNextMove = true;
                                }

                                if (colDiff2 >= 0 && colDiff2 < Size)
                                {
                                    theGrid[k, colDiff2].LegalNextMove = true;
                                }
                            }

                            break;

                        case "Queen":
                            if (i == currentCell.RowNumber)
                            {
                                theGrid[currentCell.RowNumber, j].LegalNextMove = true;
                            }
                            if (j == currentCell.ColNumber)
                            {
                                theGrid[i, currentCell.ColNumber].LegalNextMove = true;
                            }

                            for (int k = 0; k < Size; k++)
                            {
                                int rowDiff = currentCell.RowNumber - k;
                                int colDiff = currentCell.ColNumber + rowDiff;
                                int colDiff2 = currentCell.ColNumber - rowDiff;

                                if (colDiff >= 0 && colDiff < Size)
                                {
                                    theGrid[k, colDiff].LegalNextMove = true;
                                }

                                if (colDiff2 >= 0 && colDiff2 < Size)
                                {
                                    theGrid[k, colDiff2].LegalNextMove = true;
                                }
                            }

                            break;

                        default:
                            break;
                    }
                }
            }
            theGrid[currentCell.RowNumber, currentCell.ColNumber].CurrentlyOccupied = true;
        }
    }
}
