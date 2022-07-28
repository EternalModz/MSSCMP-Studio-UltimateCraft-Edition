using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MSSCMP_Studio
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        [STAThread]
        static void Main(string[] args)
        {
            // redirect console output to parent process;
            // must be before any calls to Console.WriteLine()

            // to demonstrate where the console output is going
             AttachConsole(ATTACH_PARENT_PROCESS);

            int argCount = args == null ? 0 : args.Length;
            Console.WriteLine("nYou specified {0} arguments:", argCount);
            for (int i = 0; i < argCount; i++)
            {
                Console.WriteLine("  {0}", args[i]);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length != 0 && args[0] == "-dev")
            {
                Application.Run(new Form1(1));
            }
            else
                Application.Run(new Form1(0));
        }
    }
}
