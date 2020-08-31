using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gui_Photorec
{
    public class Controller
    {
        public Model M { get; set; }
        public Form1 F { get; set; } = new Form1();

        public void PrintError()
        {
            F.PrintPathError();
        }
        public void CopyFiles(Model m)
        {
            OrderByType.CopyFiles(m);
        }
        public void PrintExtensions(List<string> list)
        {
             F.PrintExtensions(list);
        }

        public void PrintInfo()
        {

        }

        public void PrintSuccess()
        {
            F.PrintSuccess();
        }
    }
}
