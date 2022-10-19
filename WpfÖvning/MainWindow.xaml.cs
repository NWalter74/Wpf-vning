using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private void TBox_SendMail_TextChanged(object sender, MouseButtonEventArgs e)
        {
            TBox_SendMail.Text = "";
        }

        private void B_SendMail_Click(object sender, RoutedEventArgs e)
        {
            //Create pattern for email
            string pattern = @"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;]{0,1}\s*)+$";

            //Create a Regex
            Regex rg = new Regex(pattern);

            Match match = rg.Match(TBox_SendMail.Text);

            if (match.Success)
            {
                MessageBox.Show("Email correct!");
                File.AppendAllText("myEmailadresses.txt", TBox_SendMail.Text.ToString() + "\n");
                TBox_SendMail.Text = "Ditt mailadress...";
            }
            else
            {
                MessageBox.Show("Email inte correct!");
                File.AppendAllText("myEmailadresses.txt", "Fel mailadress, " + DateTime.Now + "\n");
                TBox_SendMail.Text = "Ditt mailadress...";
            }

        }

        private void B_Showemailadresses_Click(object sender, RoutedEventArgs e)
        {
            string fil = File.ReadAllText("myEmailadresses.txt");

            TBlock_ShowMaillist.Text = fil + "\n";
        }
    }
}
