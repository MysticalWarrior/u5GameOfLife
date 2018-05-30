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
        public int liveCounter = 0;
        public int deadCounter = 0;
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
                        MessageBox.Show(cells[i, ii].ToString());
                    }
                }
            }
        }

        public void CheckCells(Canvas canvas)
        {
            cells[5, 5] = true;
            AddCellGraphic(cells[5, 5], 5, 5, canvas);

            for (int i = 0; i < 20; i++)
            {
                for (int ii = 0; ii < 20; ii++)
                {
                    /*for (int I = i - 1; I < i + 1; I++)//capital i is a temporary one.
                    {
                        if (I != -1 & I != 20)
                        {
                            for (int II = ii - 1; II < ii + 1; II++)
                            {
                                if (II != -1 & II != 20)
                                {
                                    if (cells[I, II])
                                    {
                                        liveCounter++;
                                    }
                                }
                            }
                        }
                    }

                    if (cells[i, ii])
                    {
                        if (liveCounter < 2)
                        {
                            cells[i, ii] = false;
                        }
                        else if (liveCounter > 3)
                        {
                            cells[i, ii] = false;
                        }
                    }
                    else if (cells[i, ii] = false & liveCounter == 3)
                    {
                        cells[i, ii] = true;
                    }*/
                    liveCounter = 0;

                    AddCellGraphic(cells[i, ii], i, ii, canvas);
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

        public void ClearCells(Canvas canvas)
        {
                canvas.Children.Clear();
        }
    }
}
