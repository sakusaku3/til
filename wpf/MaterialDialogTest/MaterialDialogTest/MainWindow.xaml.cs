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
using MaterialDesignThemes.Wpf;

namespace MaterialDialogTest
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

        private async void ButtonMaterialDialog_Click(object sender, RoutedEventArgs e)
        {
            var dialogView = new CustomDialog(
                "Dialog from Code Behind", 
                $"Now = {DateTime.Now}");

            var result = await DialogHost.Show(dialogView, "MessageDialogHost");
        }

        private void ButtonSnackBar_Click(object sender, RoutedEventArgs e)
        {
            Snackbar1.MessageQueue
                .Enqueue($"SnackBar from Code Behind Now = {DateTime.Now}");
        }

        private void ButtonSnackBar2_Click(object sender, RoutedEventArgs e)
        {
            Snackbar2.MessageQueue
                .Enqueue($"SnackBar from Code Behind Now = {DateTime.Now}",
                    "カウントアップ", () => { });
        }
    }
}
