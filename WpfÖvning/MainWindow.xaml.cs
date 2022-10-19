using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfÖvning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void B_SendToFile_Click(object sender, RoutedEventArgs e)
        {
            File.AppendAllText("myTextfile.txt", TBox_WriteToFile.Text.ToString() + "\n");
            TBox_WriteToFile.Text = "";
        }

        private void B_ReadFromFile_Click(object sender, RoutedEventArgs e)
        {
            string fil = File.ReadAllText("myTextfile.txt");

            TBlock_ShowFromFile.Text = fil + "\n";
        }

        private void TBox_WriteToFile_TextChanged(object sender, MouseButtonEventArgs e)
        {
            TBox_WriteToFile.Text = "";
        }
    }
}
