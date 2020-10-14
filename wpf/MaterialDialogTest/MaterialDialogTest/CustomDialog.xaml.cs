using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaterialDialogTest
{
    /// <summary>
    /// CustomDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class CustomDialog : UserControl
    {
        public CustomDialog()
        {
            InitializeComponent();
        }

        public CustomDialog(string title, string message) : this()
        {
            labelTitle.Content = title;
            labelMessage.Content = message;
        }
    }
}
