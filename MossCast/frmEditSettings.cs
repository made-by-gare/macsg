#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MossCast
{
    public partial class frmEditSettings : Form
    {
        public frmEditSettings()
        {
            InitializeComponent();
        }

        private void frmEditSettings_Load(object sender, EventArgs e)
        {
            textBoxStreamerFile.Text = Settings.Default.strPathToStreamerFile;
            textBoxStreamlink.Text = Settings.Default.streamlinkDir;

            updWindowHeight.Value = Settings.Default.streamerWindowHeight;
            updWindowWidth.Value = Settings.Default.streamerWindowWidth;

            updWindowStartX.Value = Settings.Default.streamerWindowStartX;
            updWindowStartY.Value = Settings.Default.streamerWindowStartY;

            updWindowMaxRows.Value = Settings.Default.streamerWindowMaxPerRow;

            checkBoxCombineNameAndPronouns.Checked = Settings.Default.boolCombinedStreamerPronounFile;
        }

        private void buttonClearStreamlink_Click(object sender, EventArgs e)
        {
            Settings.Default.streamlinkDir = "";
            My.MyProject.Forms.frmMain.setupStreamLinkCheck();
            Settings.Default.Save();
        }

        private void buttonClearStreamerFile_Click(object sender, EventArgs e)
        {
            Settings.Default.strPathToStreamerFile = My.MyProject.Forms.frmMain.appdataFolder + @"\streamerlist.conf";
            My.MyProject.Forms.frmMain.setupStreamerSources();
            Settings.Default.Save();
        }

        private void buttonBrowseStreamerFile_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog();

            fd.Title = "Select a file...";
            fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MossCast";
            fd.Filter = "Config files (*.conf)|*.conf";
            fd.RestoreDirectory = true;
            fd.ShowHelp = true;

            if (fd.ShowDialog() == DialogResult.OK && fd.FileName != Settings.Default.strPathToStreamerFile)
            {
                Settings.Default.strPathToStreamerFile = fd.FileName;
                My.MyProject.Forms.frmMain.setupStreamerSources();
                Settings.Default.Save();
            }
        }

        private void buttonBrowseStreamlink_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog();

            fd.Title = "Select a file...";
            fd.Filter = "Streamlink (*.exe)|*.exe";
            fd.RestoreDirectory = true;
            fd.ShowHelp = true;

            if (fd.ShowDialog() == DialogResult.OK && fd.FileName != Settings.Default.streamlinkDir)
            {
                Settings.Default.streamlinkDir = fd.FileName;
                My.MyProject.Forms.frmMain.setupStreamLinkCheck();
                Settings.Default.Save();
            }
        }

        private void updWindowWidth_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.streamerWindowWidth = (int)((NumericUpDown)sender).Value;
            Settings.Default.Save();
        }

        private void updWindowHeight_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.streamerWindowHeight = (int)((NumericUpDown)sender).Value;
            Settings.Default.Save();
        }

        private void updWindowStartX_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.streamerWindowStartX = (int)((NumericUpDown)sender).Value;
            Settings.Default.Save();
        }

        private void updWindowStartY_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.streamerWindowStartY = (int)((NumericUpDown)sender).Value;
            Settings.Default.Save();
        }

        private void updWindowMaxRows_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.streamerWindowMaxPerRow = (int)((NumericUpDown)sender).Value;
            Settings.Default.Save();
        }

        private void checkBoxCombineNameAndPronouns_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.boolCombinedStreamerPronounFile = ((CheckBox)sender).Checked;
            Settings.Default.Save();
        }

        private void buttonResetAll_Click(object sender, EventArgs e)
        {
            var previousStreamerFile = Settings.Default.strPathToStreamerFile;
            var previousStreamlinkFile = Settings.Default.streamlinkDir;
            Settings.Default.Reset();

            if (Settings.Default.strPathToStreamerFile != previousStreamerFile)
            {
                Settings.Default.strPathToStreamerFile = My.MyProject.Forms.frmMain.appdataFolder + @"\streamerlist.conf";
                My.MyProject.Forms.frmMain.setupStreamerSources();
            }

            if (Settings.Default.streamlinkDir != previousStreamlinkFile)
            {
                My.MyProject.Forms.frmMain.setupStreamLinkCheck();
            }

            Settings.Default.Save();
            frmEditSettings_Load(sender, e);
        }
    }
}
