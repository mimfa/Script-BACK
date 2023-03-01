using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Command_Language_GUI
{
    public static class Program
    {
        [STAThread]
        public static void Main(params string[] Args)
        {
            var m = new MainWindow();
            m.Execute(Args);
            m.ShowDialog();
        }
    }
}
