using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessBoardModel;

namespace ChessBoardGUIApp
{
    public partial class Form1 : Form
    {
        static Board myBoard = new Board(8);

        public Button[,] buttonGrid = new Button[myBoard.Size, myBoard.Size];
        
        public Form1()
        {
            InitializeComponent();
            populateGrid();
        }

        private void populateGrid()
        {
            int buttonSize = panel1.Width / myBoard.Size;

            // make the panel perfect squire
            panel1.Height = panel1.Width;

            //nested loops. Create buttons
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    buttonGrid[i, j] = new Button();

                    buttonGrid[i, j].Height = buttonSize;
                    buttonGrid[i, j].Width = buttonSize;

                    //add a click event
                    buttonGrid[i, j].Click += new EventHandler(this.comboBox1_SelectedIndexChanged); ;


                    // add the new button to the panel
                    panel1.Controls.Add(buttonGrid[i, j]);

                    // set location of the new button
                    buttonGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);

                    buttonGrid[i, j].Text = i + "|" + j;
                }
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the row and col number of the button clicked
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;

            int x = location.X;
            int y = location.Y;

            Cell currentCell = myBoard.theGrid[x, y];

            //determine legal next move
            myBoard.MarkNextLegalMoves(currentCell, "Knight");

            // update the text on each button
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    buttonGrid[i, j].Text = "";
                    if (myBoard.theGrid[i, j].LegalNextMove == true)
                    {
                        buttonGrid[i, j].Text = "Legal";
                    }
                    else if (myBoard.theGrid[i, j].CurrentlyOccupied == true)
                    {
                        buttonGrid[i, j].Text = "Knight";
                    }
                }
            }
        }
    }
}
