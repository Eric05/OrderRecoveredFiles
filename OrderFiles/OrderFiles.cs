using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderFiles
{
    public static class OrderByType
    {
        public static void CopyFiles(Model m)
        {
            if (!validateForm(m))
            {
                Controller c = new Controller();
                c.PrintError();
                return;
            }

            string inPath = m.InputPath;
            string outPath = m.OutputPath + "\\" + "Photorec_Ordered" + "\\";
            List<string> extensions = m.Extensions.Split(new char[] { ',', ' ', ';' }).ToList();

            foreach (var d in Directory.GetDirectories(inPath))
            {
                var list = GetFilesRecursively(d);   //Recursiv call
                var filtered = FilterFilesByExtension(list, extensions);

                foreach (var e in extensions)
                {
                    string dirPath = outPath + "\\" + e.Trim();
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                }

                foreach (var s in filtered)
                {
                    var extension = s.Split('.');
                    var arr = s.Split('\\');
                    string actual = outPath + "\\" + extension[extension.Length - 1] + "\\" + arr[arr.Length - 1];

                    if (!File.Exists(actual))
                    {
                        File.Copy(s, actual);
                    }
                }
            }
        }
        private static List<string> GetFilesRecursively(string path)
        {
            var result = new List<string>();
            try
            {
                //Get files in current path
                foreach (string f in Directory.GetFiles(path))
                {
                    result.Add(f);
                }
                //Get folders in current path
                foreach (var d in Directory.GetDirectories(path))
                {
                    GetFilesRecursively(d);
                }
            }
            catch
            {

            }
            return result;
        }

        private static List<string> FilterFilesByExtension(List<string> fileList, List<string> extensions)
        {
            var res = new List<string>();

            foreach (var f in fileList)
            {
                foreach (var e in extensions)
                {
                    if (f.EndsWith(e.Trim()))
                    {
                        res.Add(f);
                    }
                }
            }
            return res;
        }

        private static bool validateForm(Model m)
        {
            if (!Directory.Exists(m.InputPath) || m.OutputPath == "" || m.Extensions == "")
            {
                return false;
            }
            return true;
        }
    }
}
