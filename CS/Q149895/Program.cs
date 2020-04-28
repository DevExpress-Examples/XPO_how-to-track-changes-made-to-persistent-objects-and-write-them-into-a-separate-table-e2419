using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

namespace Q149895 {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            XpoDefault.ConnectionString = SQLiteConnectionProvider.GetConnectionString(@"nwind.sqlite");
            Application.Run(new Form1());
        }
    }
}