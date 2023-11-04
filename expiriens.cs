using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace WPF_Autocad_Lisp_3d_Polyline_03_11_2023
{
    public class expiriens : Window
    {
        Window Window = new Window();
        TextBox textBox = new TextBox();
        public void WorkTextbox()
        {
            MessageBox.Show("вызвали текстбокс");
            textBox.Text = "вызвали текстбокс";
        }
    }
}
