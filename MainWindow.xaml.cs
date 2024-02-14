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
        StringBuilder strBild = new StringBuilder();
        private int count1;
        private int count2;

        public MainWindow()
        {
            InitializeComponent();
            string_for_lisp.CheckDate();
        }

        // метод сохранения в файл
        private void Button_Save_as_Click(object sender, RoutedEventArgs e)
        {
        addlay();
            string sborka = strLisp.lispbeginning().ToString() + strBild.ToString().ToString() + strLisp.lispending().ToString();
            TextBlockCount.Text = "кабелей - " + textboxLayName.LineCount.ToString();
            // метод записи файла 
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
                        sw.Write(sborka);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            sborka = "";
            // победа, я новый обьект создаю 06-11-2023
            strLisp = new string_for_lisp();
    }
        public string addlay()
        {
            // разделение текстбоксов на строки
            #region
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
            // создаем 
            
            // стринг для второй координаты
            string firstCoor = "";
            #endregion

            // (command "_.-layer" "_m" "1091-III-D3-K15" "")
            //(command "_.3Dpoly" '(206236	-47787	0)'(95377   52133   0) "")
            try
            {
                // добавляем в список значения из текстбокса имя слоя  и координаты трех textbox
                // причем у второго тексбокса может быть много строк
                foreach (var item in massTextBoxLayname)
                {
                    // добавляем имя слоя в строку
                    strBild.Append("\n" + @"(command ""_.-layer"" ""_m"" "" " + massTextBoxLayname[count1]  + @" "" """")"+"\n");
                    // собираем первые координаты полилинии
                    strBild.Append( "\n" + @"(command ""_.3Dpoly""");
                    strBild.Append("\n" + " '(" + masstextboxFirst[count1] + ")");
                    // собираем средние координаты полилинии
                    foreach (var itemt in masstextboxSecond)
                    {
                        strBild.Append( "\n" + " '(" + masstextboxSecond[count2] + ")" + "\n");
                        count2++;
                    }
                    count2 = 0;
                    // собираем третьи (последние) координаты полилинии
                    strBild.Append("\n" + @" '(" + masstextboxThree[count1] + @") """")");
                    count1++;
                }
                count1 = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("проверьте количество!!!" +"\n"+ ex.Message);
                count1 = 0; count2 = 0;
            }
            // обнуляем счетчики
            finally { count1 = 0; count2 = 0; }
            // возвращаем обьект StringBilder (строку)
            return strBild.ToString();
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            strBild = new StringBuilder();
            textboxLayName.Text = string.Empty;
            textboxFirst.Text = string.Empty;
            textboxSecond.Text = string.Empty;
            textboxThree.Text = string.Empty;
            TextBlockCount.Text = "-";
        }

        private void Button_Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Координаты заполняем через пробел"+"\n"+
                "Имя слоя не содержит:"+"\n"+
                "<" + "\n" + 
                ">" + "\n" +
                "/" + "\n" +
                "\"" + "\n" +
                ":" + "\n" +
                ";" + "\n" +
                "?" + "\n" +
                "`" + "\n" + 
                "*" + "\n" +
                "|" + "\n" +
                "`" + "\n" +
                "," + "\n" +
                "=" + "\n" +
                "`" + "\n" +
                "]" + "\n" +
                "\"" ,"Помощь");
        }
    }
}
