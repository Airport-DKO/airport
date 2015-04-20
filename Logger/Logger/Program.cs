using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Logger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new FormMain());
            }
            catch
            {
                MessageBox.Show("Ошибка при запуске. Убедитесь, что у вас имеется папка \"C:\\airport\\\"");
            }
        }
    }
}
