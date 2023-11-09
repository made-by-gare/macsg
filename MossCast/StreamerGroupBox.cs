#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;


namespace MossCast
{
    public partial class StreamerGroupBox : UserControl
    {

        private string header;

        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
                groupStreamer.Text = header;
            }
        }


        public StreamerGroupBox()
        {
            InitializeComponent();
        }

        public void UpdateDataSource(List<string> streamers)
        {

            var selectedItem = cbStreamer.SelectedItem;

            cbStreamer.Items.Clear();
            cbStreamer.Items.AddRange(streamers.ToArray());

            if (selectedItem is not null && cbStreamer.Items.Contains(selectedItem))
            {
                cbStreamer.SelectedItem = selectedItem;
            }
            else
            {
                Deactivate();
            }
        }

        public bool IsActive()
        {
            return cbStreamer.SelectedIndex >= 0;

        }

        public void SelectStreamer(string streamer)
        {
            if (cbStreamer.Items.Contains(streamer))
            {
                cbStreamer.SelectedItem = streamer;
            }
        }

        public void Activate()
        {
            var idx = cbStreamer.SelectedIndex;
            if (idx < 0)
            {
                return;
            }

            btnDeselect.Show();
            btnDeselect.Enabled = true;


            txtDisplayName.Text = My.MyProject.Forms.frmMain.streamerInfos[idx].displayName ?? "";
            txtPronouns.Text = My.MyProject.Forms.frmMain.streamerInfos[idx].pronouns ?? "";
            btnLaunch.Enabled = true;
            cbQuality.Enabled = true;
            cbQuality.SelectedIndex = 0;
            updScore.Enabled = true;
        }
        public void Deactivate()
        {
            cbStreamer.SelectedItem = null;
            btnDeselect.Hide();
            btnDeselect.Enabled = false;

            txtDisplayName.Text = "";
            txtPronouns.Text = "";

            btnLaunch.Enabled = false;
            cbQuality.Enabled = false;
            cbQuality.SelectedIndex = -1;
            updScore.Enabled = false;
        }

        private void stream1Group_Enter(object sender, EventArgs e)
        {

        }

        private void btnDeselect_Click(object sender, EventArgs e)
        {
            Deactivate();
        }

        private void cbStreamer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStreamer.SelectedIndex >= 0)
            {
                Activate();
            }
        }

        public void genStream(string streamer, string quality, string source, string windowTitle, string configFile, string racerNumber)
        {
            string runningProcess = "/c title " + windowTitle + " & " + source + @"-a "" --config %AppData%\MossCast\vlcrc --width 877 --height 518 -"" " + " --title " + racerNumber + " --hls-live-edge 1 twitch.tv/" + streamer + quality;
            var strLivestreamerProcess = new ProcessStartInfo("cmd.exe", runningProcess);

            strLivestreamerProcess.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(strLivestreamerProcess);
        }

        public void writeNameToFile(string streamer, string file)
        {

            string strPathtoName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MossCast\streamer-" + file + ".txt";
            StreamWriter swstreamer;
            swstreamer = My.MyProject.Computer.FileSystem.OpenTextFileWriter(strPathtoName, false);
            swstreamer.WriteLine(streamer);
            swstreamer.Close();

        }
        public void writePronounsToFile(string pronouns, string file)
        {

            string strPathtoName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MossCast\streamer-pronouns-" + file + ".txt";
            StreamWriter swstreamer;
            swstreamer = My.MyProject.Computer.FileSystem.OpenTextFileWriter(strPathtoName, false);
            swstreamer.WriteLine(pronouns);
            swstreamer.Close();

        }

        public void writeNameAndPronounsToFile(string streamer, string pronouns, string file)
        {

            string strPathtoName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MossCast\streamer-" + file + ".txt";


            StreamWriter swstreamer;
            swstreamer = My.MyProject.Computer.FileSystem.OpenTextFileWriter(strPathtoName, false);
            if (!string.IsNullOrEmpty(pronouns))
            {
                swstreamer.WriteLine(streamer + " (" + pronouns + ")");
            }
            else
            {
                swstreamer.WriteLine(streamer);
            }
            swstreamer.Close();

        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            var idx = Array.IndexOf(My.MyProject.Forms.frmMain.streamerGroupBoxes, this);
            if (idx < 0)
            {
                return;
            }

            string idxStr = (idx + 1).ToString("00");
            string windowTitle = "Stream" + idxStr;

            if (processChecker(windowTitle))
            {
                return;
            }

            if (cbStreamer.SelectedIndex < 0 || cbStreamer.SelectedIndex > My.MyProject.Forms.frmMain.streamerInfos.Count)
            {
                return;
            }

            var streamerInfo = My.MyProject.Forms.frmMain.streamerInfos[cbStreamer.SelectedIndex];
            if (string.IsNullOrEmpty(streamerInfo.name))
            {
                return;
            }

            string strSource = "streamlink ";
            string strQuality = " best ";
            genStream(streamer: streamerInfo.name, quality: strQuality, source: strSource, windowTitle: "CMD" + windowTitle, configFile: idxStr, racerNumber: windowTitle);

            var pronouns = streamerInfo.pronouns ?? "";
            writePronounsToFile(pronouns: pronouns, file: idxStr);


            var outputName = streamerInfo.name;
            if (!string.IsNullOrEmpty(streamerInfo.displayName))
            {
                outputName = streamerInfo.displayName;
            }

            if (My.MySettingsProperty.Settings.boolCombinedStreamerPronounFile)
            {
                writeNameAndPronounsToFile(streamer: outputName, pronouns: pronouns, file: idxStr);
            }
            else
            {
                writeNameToFile(streamer: outputName, file: idxStr);
            }

        }


        public void Launch()
        {
            btnLaunch.PerformClick();
        }

        public bool processChecker(string windowTitle)
        {
            Process[] procProcesses = Process.GetProcesses();
            foreach (Process p in procProcesses)
            {
                if (p.MainWindowTitle.Contains(windowTitle))
                {
                    return true;
                }
            }
            return false;
        }

        private void updScore_ValueChanged(object sender, EventArgs e)
        {

            var idx = Array.IndexOf(My.MyProject.Forms.frmMain.streamerGroupBoxes, this);
            if (idx < 0)
            {
                return;
            }

            string idxStr = (idx + 1).ToString("00");

            using (var swScore = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MossCast\score-" + idxStr + ".txt"))
            {
                swScore.Write(((NumericUpDown)sender).Value);
            }


        }
    }
}
