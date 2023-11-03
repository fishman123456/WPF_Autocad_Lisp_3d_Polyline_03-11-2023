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
        public string_for_lisp strLisp = new string_for_lisp();
        public List<string> list_lay_name = new List<string>();
        public List<string> textboxFirsts = new List<string>();
        public List<string> textboxSeconds = new List<string>();
        public List<string> textboxThrees = new List<string>();
        private int count;

        public MainWindow()
        {
            InitializeComponent();
            string_for_lisp.CheckDate();
        }


        private void Button_Save_as_Click(object sender, RoutedEventArgs e)
        {
            addlay();
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
        public void addlay()
        {
            // расделителем может служить один символ, поэтому строку создаём, т е массив символов
            string[] separator = { "\n", "\r" };
            // добавляем данные в список из текстбокса textboxLayName 
            string[] massTextBoxLayname = textboxLayName.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            // добавляем данные в список из текстбокса textboxFirst
            string[] masstextboxFirst = textboxFirst.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            // добавляем данные в список из текстбокса textboxSecond
            string[] masstextboxSecond = textboxSecond.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            // добавляем данные в список из текстбокса textboxThree
            string[] masstextboxThree = textboxThree.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            // добавляем в список значения из текстбокса имя слоя  и координаты
            foreach (var item in massTextBoxLayname)
            {
                list_lay_name.Add(massTextBoxLayname[count]);
                if (masstextboxFirst.Length > 0)
                {
                    textboxFirsts.Add(masstextboxFirst[count]);
                }
                if (masstextboxSecond.Length > 0)
                {
                    textboxSeconds.Add(masstextboxSecond[count]);
                }
                if (masstextboxThree.Length >0)
                {
                    textboxThrees.Add(masstextboxThree[count]);
                }
                count++;
            }
            textboxLayName.Text.ToString();
        }
    }
}
