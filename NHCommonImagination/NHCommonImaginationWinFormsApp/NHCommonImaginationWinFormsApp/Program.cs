using NHibernate;
using NHibernate.Cfg;
using System;
using System.Windows.Forms;

namespace NHCommonImaginationWinFormsApp
{  
    static class Program
    {
        public static ISessionFactory sessionFactory; 

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var config = new Configuration();

            sessionFactory = config.Configure().BuildSessionFactory();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
