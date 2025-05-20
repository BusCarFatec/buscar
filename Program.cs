using System;
using System.Windows.Forms; 

namespace BusCar
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Tela inicial
            Application.Run(new view.LoginScreen());
        }
    }
}
