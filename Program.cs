using System;
using System.Windows.Forms;
using CFMART;

namespace CFMART
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new CFMART.Form1());
        }
    }
}