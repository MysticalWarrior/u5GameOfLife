using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace u5GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Cells cells = new Cells();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                string temp = txtInput.Text;
                int.TryParse(temp.Substring(0, 2), out int tempX);
                int.TryParse(temp.Substring(2, 2), out int tempY);
                cells.addItem(tempX, tempY);
                txtInput.Text = "";
            }
        }

        private void btnShowInstructions_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(cells.cells[1, 1].ToString());
            cells.AddCellGraphic(true, 0, 0, Grid);
            cells.ClearCells(Grid);
        }

        private void btnRunDay_Click(object sender, RoutedEventArgs e)
        {
            cells.ClearCells(Grid);
            cells.CheckCells(Grid);
        }
    }
}
