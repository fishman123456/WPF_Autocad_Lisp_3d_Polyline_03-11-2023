using Microsoft.Win32;

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

namespace WPF_Autocad_Lisp_3d_Polyline_03_11_2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      public  string_for_lisp strLisp = new string_for_lisp();
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void Button_Save_as_Click(object sender, RoutedEventArgs e)
        {
            
            TextBlockCount.Text = "кабелей - " + textboxLayName.LineCount.ToString();
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "LSP Files(*.lsp)|*.lsp|All(*.*)|*";
            dialog.RestoreDirectory = true;
            dialog.InitialDirectory = dialog.FileName;
            try
            {
                if (dialog.ShowDialog() == true)
                {
                    string path = dialog.FileName;
                    StreamWriter sw = new StreamWriter(path, false);
                    using (sw)
                    {

                        sw.Write(strLisp.first_lisp());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
