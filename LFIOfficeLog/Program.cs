using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
            using (var mutex = new Mutex(false, "Logger is already running"))
            {
                try
                {
                    if (mutex.WaitOne(0))
                    {
                        Run(mutex);
                    }
                    else
                    {
                        MessageBox.Show("Logger is already running");
                    }
                }
                catch(Exception)
                {
                    Run(mutex);
                }
            }
        }

        static void Run(Mutex mutex)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoggerForm());
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }
}
