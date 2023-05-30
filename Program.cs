using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa.UIL
{
    public static class Program
    {
        [STAThread]
        public static void Main(params string[] Args)
        {
            Config.Initial();
            var m = new MainWindow();
            m.Execute(Args);
            m.ShowDialog();
        }
    }
}
