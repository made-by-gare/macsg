using System.Linq;
using Microsoft.VisualBasic.ApplicationServices;

namespace MacSG.My
{
    internal partial class MyApplication
    {

        private void MyApplication_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            var f = MyProject.Application.MainForm;
            // use YOUR actual form class name:
            if (ReferenceEquals(f.GetType(), typeof(frmMain)))
            {
                ((frmMain)f).cliStartup(e.CommandLine.ToArray());
            }
        }

    }
}