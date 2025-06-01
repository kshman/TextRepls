using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextRepls
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                try
                {
                    var wr = new WorkRepls(args[0], args[1]);
                    var result = wr.BatchRun();
                    Console.WriteLine($"Batch processing completed with {result} replacements.");
                }
                catch
                {
                    Console.WriteLine($"Task failed");
                }
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
