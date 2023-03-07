using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GatePass
{
    internal class Utility
    {
        public static string GetImageStorePath(string imageName)
        {
            return Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10)) + "\\IMAGES\\" + imageName + ".jpg";
        }
    }
}
