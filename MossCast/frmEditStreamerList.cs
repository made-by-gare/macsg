#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace MossCast
{

    public partial class frmEditStreamerList
    {
        public frmEditStreamerList()
        {
            InitializeComponent();
        }

        public void Form2_Load(object sender, EventArgs e)
        {

            Point p;
            p = My.MyProject.Forms.frmMain.Location;

            Location = new Point(p.X + 10, p.Y + 10);

            using (var srReader = new StreamReader(Settings.Default.strPathToStreamerFile))
            {
                string line;
                line = srReader.ReadLine();

                while (line is not null)
                {
                    string[] columns = line.Split(',').Select(x => x.Trim()).ToArray();
                    dgdStreamerList.Rows.Add(columns);
                    line = srReader.ReadLine();
                }
            }

        }

        private void Form2_FormClosing(object sender, EventArgs e)
        {

            List<string> output = new List<string>();
            int columnCount = dgdStreamerList.Columns.Count;

            for (int i = 1; (i - 1) < dgdStreamerList.Rows.Count; i++)
            {

                List<string> cells = new List<string>();

                for (int j = 0; j < columnCount; j++)
                {
                    cells.Add(dgdStreamerList.Rows[i - 1].Cells[j].Value?.ToString().Trim());
                }

                if (cells.Count() < 1 || string.IsNullOrEmpty(cells[0]))
                {
                    continue;
                }

                output.Add(String.Join(",", cells.ToArray()));
            }

            File.WriteAllText(Settings.Default.strPathToStreamerFile, String.Join("\n", output).TrimEnd());
            My.MyProject.Forms.frmMain.setupStreamerSources();
        }

    }
}