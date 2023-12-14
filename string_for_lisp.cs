using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
// 26-03-2023, мужик за стеной бурит перфоратором зае.....
namespace WPF_Autocad_Lisp_3d_Polyline_03_11_2023
{
    public class string_for_lisp 
    {
       private StringBuilder sb = new StringBuilder();
        public string_for_lisp() { }
          // функция записывает в строку  файл lisp
        public  StringBuilder lispbeginning()
        {
            // начало файла lisp
            sb.Append ("");
           
            sb.Append("(defun  C:PL100 (/ x1 x2 x3)\n");
            sb.Append("(vl-load-com)\n");
            // отключаем привязки
            sb.Append("(setvar \"ORTHOMODE\" 0)\r\n  (setvar \"SNAPMODE\" 0)\r\n  (setvar \"OSMODE\" 0)");
            // вставляем создание нового слоя и построение 3д полилинии
            return sb;
        }
        public StringBuilder lispending()
        {
            StringBuilder sb = new StringBuilder();
            // завершение файла
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
                //MessageBox.Show("Работайте до   " + dt2.ToString());
            }
        }
        
        
    }
   
}