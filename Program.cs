using System;
using System.Windows.Forms;
using AccountingSystemForWindowsFormLast.Forms;
using AccountingSystemForWindowsFormLast.Forms.Authentication;

namespace AccountingSystemForWindowsFormLast
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (LoginForm loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            Application.Run(new frm_Main());
        }
    }
}




//namespace AccountingSystemForWindowsFormLast
//{
//    internal static class Program
//    {
//        /// <summary>
//        ///  The main entry point for the application.
//        /// </summary>
//        [STAThread]
//        static void Main()
//        {
//            // To customize application configuration such as set high DPI settings or default font,
//            // see https://aka.ms/applicationconfiguration.
//            ApplicationConfiguration.Initialize();
//            Application.Run(new frm_Main());
//        }
//    }
//}