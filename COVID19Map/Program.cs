using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;

namespace COVID19Map
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var container = new StandardKernel();
            container.Bind<IParser>().To<DataParser>();
            container.Bind<IMarkLocalization>().ToConstant(new RuMarkLocalization());
            var form = container.Get<MainForm>();
            Application.Run(form);
        }
    }
}
