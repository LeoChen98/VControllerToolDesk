using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VControllerToolDesk
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            if (true)
            {
                if(Process.GetProcesses().Where(e => e.ProcessName=="VControllerToolDesk").Count() > 1)
                {
                    Environment.Exit(1);
                }
            }


            App app = new App();
            app.Run(new MainWindow());
        }
    }
}
