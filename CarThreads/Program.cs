using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarThreads
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //CallStart();
            Thread t = new Thread(Program.Start);
            t.Start();
            t.Join();
        }

        private static async void CallStart()
        {
            await Task.Run(delegate () { Program.Start(); });
        }

        private static void Start()
        {
            Application.Run(new Form1());
        }
    }
}
