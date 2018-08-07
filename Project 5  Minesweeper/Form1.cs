//Henry's Minesweeper
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_5__Minesweeper
{
    public partial class Form1 : Form
    {
        Button[,] board = new Button[10, 10];

        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            //Create 10x10 board of buttons
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = new Button();
                    board[i, j].Location = new Point(i * 40, j * 40);
                    board[i, j].Width = 40;
                    board[i, j].Height = 40;
                    board[i, j].Click += buttonArray_Click;
                    groupBox1.Controls.Add(board[i, j]);
                }
            }
            //Generates mines
            Random rnd = new Random();
            int xvalue = rnd.Next(10);
            int yvalue = rnd.Next(10);
            int count = 0;
            while (count < 11)
            {
                board[xvalue, yvalue].Tag = "*";
                xvalue = rnd.Next(10);
                yvalue = rnd.Next(10);
                count++;
            }
        }
        
        private void buttonArray_Click(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            int curCol = (temp.Location.Y) / 40;
            int curRow = (temp.Location.X) / 40;
            //Clicked on mine
            //winner();
            if (board[curRow, curCol].Tag == "*")
            {
                MessageBox.Show("You landed on a Mine!");
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (board[i, j].Tag == "*")
                        {
                            board[i, j].Text = "*";
                        }
                        board[i,j].Enabled = false;       
                    }
                }
            }
            // showing # 1
            // for values not in the last rows/cols
            if (board[curRow, curCol].Tag != "*" && curCol > 0 && curCol < 9 && curRow > 0 && curRow < 9)
            {
                if (board[curRow + 1, curCol].Tag == "*"
                || board[curRow, curCol + 1].Tag == "*"
                || board[curRow + 1, curCol + 1].Tag == "*"
                || board[curRow - 1, curCol].Tag == "*"
                || board[curRow, curCol - 1].Tag == "*"
                || board[curRow - 1, curCol - 1].Tag == "*"
                || board[curRow + 1, curCol - 1].Tag == "*"
                || board[curRow - 1, curCol + 1].Tag == "*")
                {
                    temp.Text = "1";
                    temp.Enabled = false;
                }
            }
            // first column
            if (board[curRow, curCol].Tag != "*" && curRow == 0 && curCol < 9 && curCol > 0)
            {
                if (board[curRow + 1, curCol + 1].Tag == "*"
                    || board[curRow + 1, curCol].Tag == "*"
                    || board[curRow, curCol + 1].Tag == "*"
                    || board[curRow, curCol - 1].Tag == "*"
                    || board[curRow + 1, curCol - 1].Tag == "*")
                {
                    temp.Text = "1";
                    temp.Enabled = false;
                }
            }
            //last col
            if (board[curRow, curCol].Tag != "*" && curRow > 0 && curRow == 9 && curCol < 9 && curCol > 0)
            {
                if (board[curRow, curCol + 1].Tag == "*"
                    || board[curRow - 1, curCol].Tag == "*"
                    || board[curRow, curCol - 1].Tag == "*"
                    || board[curRow - 1, curCol - 1].Tag == "*"
                    || board[curRow - 1, curCol + 1].Tag == "*")
                {
                    temp.Text = "1";
                    temp.Enabled = false;
                }
            }
            // first row
            if (board[curRow, curCol].Tag != "*" && curRow > 0 && curRow < 9 && curCol == 0 && curCol < 9)
            {
                if (board[curRow + 1, curCol].Tag == "*"
                    || board[curRow, curCol + 1].Tag == "*"
                    || board[curRow - 1, curCol].Tag == "*"
                    || board[curRow + 1, curCol + 1].Tag == "*"
                    || board[curRow - 1, curCol + 1].Tag == "*")
                {
                    temp.Text = "1";
                    temp.Enabled = false;
                }
            }
            // last row
            if (board[curRow, curCol].Tag != "*" && curRow > 0 && curRow < 9 && curCol > 0 && curCol == 9)
            {
                if (board[curRow + 1, curCol].Tag == "*"
                     || board[curRow - 1, curCol].Tag == "*"
                     || board[curRow, curCol - 1].Tag == "*"
                     || board[curRow - 1, curCol - 1].Tag == "*"
                     || board[curRow + 1, curCol - 1].Tag == "*")
                {
                    temp.Text = "1";
                    temp.Enabled = false;
                }
            }
            // corners
            if (board[curRow, curCol].Tag != "*" && curRow == 0 && curCol == 0)
            {
                if (board[curRow + 1, curCol].Tag == "*"
                    || board[curRow + 1, curCol + 1].Tag == "*"
                    || board[curRow, curCol + 1].Tag == "*")
                {
                    temp.Text = "1";
                    temp.Enabled = false;
                }
            }
            if (board[curRow, curCol].Tag != "*" && curRow == 0 && curCol == 9)
            {
                if (board[curRow + 1, curCol].Tag == "*"
                    || board[curRow, curCol - 1].Tag == "*")
                {
                    temp.Text = "1";
                    temp.Enabled = false;
                }
            }
            if (board[curRow, curCol].Tag != "*" && curRow == 9 && curCol == 0)
            {
                if (board[curRow, curCol + 1].Tag == "*"
                    || board[curRow - 1, curCol + 1].Tag == "*")
                {
                    temp.Text = "1";
                    temp.Enabled = false;
                }
            }
            if (board[curRow, curCol].Tag != "*" && curRow == 9 && curCol == 9)
            {
                if (board[curRow, curCol - 1].Tag == "*"
                    || board[curRow - 1, curCol].Tag == "*"
                    || board[curRow - 1, curCol - 1].Tag == "*")
                {
                    temp.Text = "1";
                    temp.Enabled = false;
                }
            }
            else
                temp.Enabled = false;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //void winner()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        for (int j = 0; j < 10; j++)
        //        {
        //            if (board[i,j].Text != "*")
        //            {
        //                MessageBox.Show("You Win!");
        //            }
        //        }
        //    }
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j].Enabled = true;
                    board[i, j].Tag = "";
                    board[i, j].Text = "";
                }
            }
            Random rnd = new Random();
            int xvalue = rnd.Next(10);
            int yvalue = rnd.Next(10);
            int count = 0;
            while (count < 11)
            {
                board[xvalue, yvalue].Tag = "*";
                xvalue = rnd.Next(10);
                yvalue = rnd.Next(10);
                count++;
            }
        }
    }
}
