using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MacSG
{

    public partial class frmEditStreamerList
    {
        private List<string> lstStreamerList = new List<string>();

        public frmEditStreamerList()
        {
            InitializeComponent();
        }

        public void Form2_Load(object sender, EventArgs e)
        {

            Point p;
            p = My.MyProject.Forms.frmMain.Location;

            Location = new Point(p.X + 10, p.Y + 10);

            using (var srReader = new StreamReader(My.MySettingsProperty.Settings.strPathToStreamerFile))
            {
                string line;
                line = srReader.ReadLine();

                while (line is not null)
                {
                    lstStreamerList.Add(line);
                    dgdStreamerList.Rows.Add(line);
                    line = srReader.ReadLine();
                }
            }

        }

        private void Form2_FormClosing(object sender, EventArgs e)
        {

            dgdStreamerList.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

            for (int i = 0, loopTo = dgdStreamerList.Rows.Count - 2; i <= loopTo; i++)
            {
                if (string.IsNullOrEmpty(dgdStreamerList.Rows[i].ToString()))
                {
                    dgdStreamerList.Rows.Remove(dgdStreamerList.Rows[i]);
                }
            }

            dgdStreamerList.SelectAll();

            File.WriteAllText(My.MySettingsProperty.Settings.strPathToStreamerFile, dgdStreamerList.GetClipboardContent().GetText().TrimEnd());
            dgdStreamerList.ClearSelection();

            My.MyProject.Forms.frmMain.setupAutocompleteSources();

        }

    }
}