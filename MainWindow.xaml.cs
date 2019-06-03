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

namespace myGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Line[] columnLines;
        Line[] rowLines;
        public MainWindow()
        {
            InitializeComponent();

            createColumns();
            createRows();
            addString("Hello", 0, 25);
            addString("Goodbye", 100, 75);

        }



        private void addString(string s, int x, int y)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = s;
            textBlock.Foreground = Brushes.Black;
            textBlock.FontSize = 14;
            canvas.Children.Add(textBlock);
            Canvas.SetTop(textBlock, y);
            Canvas.SetLeft(textBlock, x);
        }
        private void createColumns()
        {
            columnLines = new Line[4];
            for (int i = 0; i < columnLines.Length; i++)
            {
                columnLines[i] = new Line();
                columnLines[i].Stroke = Brushes.Black;
                columnLines[i].X1 = 50 * i;
                columnLines[i].X2 = columnLines[i].X1;
                columnLines[i].Y1 = 0;
                columnLines[i].Y2 = 100;

                canvas.Children.Add(columnLines[i]);
            }
        }

        private void createRows()
        {
            rowLines = new Line[5];
            for (int i = 0; i < rowLines.Length; i++)
            {
                if (i != 2)
                {
                    rowLines[i] = new Line();
                    rowLines[i].Stroke = Brushes.Black;
                    rowLines[i].Y1 = 25 * i;
                    rowLines[i].Y2 = rowLines[i].Y1;
                    rowLines[i].X1 = 0;
                    rowLines[i].X2 = 150;

                    canvas.Children.Add(rowLines[i]);
                }
            }
        }

        private void canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point p = Mouse.GetPosition(canvas);
            if (p.X < 50 && p.Y < 25)
            {
                //cell 0, 0
                MessageBox.Show("clicked 0,0");
            }
            else if (p.X < 100 && p.Y < 25)
            {
                //cell 1,1
                addString("yo", 50, 0);
            }
            else
            {
                TextBlock temp;
                temp = new TextBlock();
                foreach (object i in canvas.Children)
                {
                    MessageBox.Show(i.ToString() + "\n" + i.GetType());
                    if (i.GetType().ToString().Contains("TextBlock"))
                    {
                        TextBlock t = (TextBlock)i;
                        t.Foreground = Brushes.Red;
                        if (t.Text == "Goodbye")
                        {
                            temp = t;

                        }
                    }
                }
                canvas.Children.Remove(temp);
            }

            //MessageBox.Show(p.ToString());
        }
    }
}
