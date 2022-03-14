using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Ui.Models;

namespace Ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Number> input { get; set; }=new List<Number>();
        public MainWindow()
        {
            InitializeComponent();
            List<double> inp = new List<double>() { 30, 40, 21, 421, 213, 22, 214, 234, 23, 1, 2, 4, 6, 25, 128, 20, 223, 412 };
            int i = 0;
            foreach (double d in inp)
            {
                Number temp = new Number();
                temp.value = d;
                temp.index = i;
                input.Add(temp);
                i++;
            }
            DGrid.ItemsSource = input;

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            input.Clear();
            DGrid.ItemsSource = null;
            DGrid.ItemsSource = input;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Number temp = new Number();
            temp.value = Convert.ToDouble(NumberArray.Text);
            temp.index = input.Count;
            input.Add(temp);
            DGrid.ItemsSource = null;
            DGrid.ItemsSource = input;
        }
        private void Show_Click(object sender, RoutedEventArgs e)
        {
            List<double> inp = new List<double>();
            foreach (Number n in input)
                inp.Add(n.value);
            Awnser.Text = Convert.ToString(Select.Quick.QuickSelect(inp, input.Count, Convert.ToInt32(Ktext.Text)));
            DGrid.SelectedItem = inp;
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
