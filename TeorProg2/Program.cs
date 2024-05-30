using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeorProg2.Control;
using TeorProg2.Model;

namespace TeorProg2
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IModel model = new Model.Model();
            IController controller = new Control.Controller(model);
            Form1 form = new Form1(controller);
            Application.Run(form);
        }
    }
}
