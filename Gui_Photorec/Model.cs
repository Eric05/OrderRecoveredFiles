using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Photorec
{
    public class Model
    {
        public string InputPath { get; set; }
        public string OutputPath { get; set; }
        public string Extensions { get; set; }
        public string Info { get; set; }

        public Model(string input, string output, string ext)
        {
            InputPath = input;
            OutputPath = output;
            Extensions = ext;
        }
    }
}
