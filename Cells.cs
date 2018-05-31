using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace u5GameOfLife
{
    class Cells
    {
        public bool[,] cells = new bool[20, 20];
        public bool[,] tempCells = new bool[20, 20];
        public int liveCounter = 0;
        public int deadCounter = 0;
        public string troubleshoot = "";
        //true = alive
        //false = dead
        public Cells()
        {/*
            for (int i = 0; i < 20; i++)
            {
                for (int ii = 0; ii < 20; ii++)
                {
                    cells[i, ii] = false;
                }
            }*/
            addItem(5, 5);
            addItem(5, 6);
            addItem(5, 7);
            addItem(6, 5);
            addItem(6, 6);
            addItem(6, 7);
            addItem(7, 5);
            addItem(7, 6);
            addItem(7, 7);
        }

        public void addItem(int x, int y)
        {
            for (int i = 0; i < 20; i++)
            {
                for (int ii = 0; ii < 20; ii++)
                {
                    if (i == x & ii == y)
                    {
                        cells[i, ii] = true;
                        //MessageBox.Show(cells[i, ii].ToString());
                    }
                }
            }
        }

        public void CheckCells(Canvas canvas)
        {
            tempCells = cells;
            for (int i = 0; i < 20; i++)
            {
                for (int ii = 0; ii < 20; ii++)
                {
                    //begin checking surounding
                    for (int I = i - 1; I <= i + 1; I++)
                    {
                        if (I != -1 & I != 20)
                        {
                            for (int II = ii - 1; II <= ii + 1; II++)
                            {
                                if (II != -1 & II != 20 & II != ii & i != I)
                                {
                                    if (cells[I, II])
                                    {
                                        liveCounter++;
                                    }
                                }
                            }
                        }
                    }

                    if (cells[i, ii] == true)
                    {
                        if (liveCounter == 2 || liveCounter == 3)
                        {
                            AddCellGraphic(true, i, ii, canvas);
                            troubleshoot += "t" + i.ToString() + ii.ToString() + '\r';
                        }
                        else
                        {
                            AddCellGraphic(false, i, ii, canvas);
                        }
                    }
                    else if (cells[i, ii] = false & liveCounter == 3)
                    {
                        AddCellGraphic(true, i, ii, canvas);
                        troubleshoot += "t" + i.ToString() + ii.ToString() + '\r';
                    }
                    else
                    {
                        AddCellGraphic(false, i, ii, canvas);
                    }
                    liveCounter = 0;
                }
            }
            MessageBox.Show(troubleshoot);
        }

        public void Changes()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int ii = 0; ii < 20; ii++)
                {
                    cells[i, ii] = tempCells[i, ii];
                }
            }
        }

        public void AddCellGraphic(bool alive, int x, int y, Canvas canvas)
        {
            Rectangle cell = new Rectangle();
            cell.Width = 25;
            cell.Height = 25;
            cell.Stroke = Brushes.Black;
            if (alive)
            {
                cell.Fill = Brushes.Green;
            }
            else if (alive == false)
            {
                cell.Fill = Brushes.Red;
            }
            canvas.Children.Add(cell);
            Canvas.SetLeft(cell, x * 25);
            Canvas.SetTop(cell, y * 25 + 25);
        }
    }
}
