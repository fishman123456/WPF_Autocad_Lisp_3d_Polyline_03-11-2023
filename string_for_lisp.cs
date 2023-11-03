using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
// 26-03-2023, мужик за стеной бурит перфоратором зае.....
namespace Autocad_lisp_WPF_insert_block_26_03_2023
{
    public class string_for_lisp
    {
       private StringBuilder sb = new StringBuilder();


        // функция записывает в строку начало файла lsp
        public  StringBuilder first_lisp()
        {
            sb.Append ("");
            sb.Append("(defun  C:PL100 (/ x1 x2 x3)\n");
            sb.Append("(vl-load-com)\n)");
            sb.Append(" (command \"_.-layer\" \"_m\" \"\n)");
            // строка из лиспа для автокада - середина
            return sb;
        }
        // перебираем текстбоксы, создаем слой 
        public  StringBuilder second_lisp(string str)
        {
            sb.Append("(command \"_.3Dpoly\" '( ");
            return sb;
        }
        // функция записывает в окончание начало файла lsp 
        public StringBuilder third_lisp(string str)
        {
            sb.Append(")\t\t'( ");
            return sb;
        }
        public StringBuilder four_lisp(string str)
        {
            sb.Append(")\t\"\")");
            return sb;
        }
        public StringBuilder ends(string str)
        {
            sb.Append("\n(alert \"You win\")\n");
            sb.Append(")");
            return sb;
        }
        // проверка по дате использования
        public static void CheckDate()
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Parse("01/01/2024");
            Window w1 = new Window();

            if (dt1.Date > dt2.Date)
            {
                MessageBox.Show("Your Application is Expire");
                // Выход из проложения добавил 12-07-2023. Чтобы порядок был....
                Application.Current.Shutdown();
                //w1.Close();
            }
            else
            {

                MessageBox.Show("Работайте до   " + dt2.ToString());
            }

        }

    }
}
