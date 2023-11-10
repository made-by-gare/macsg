#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
            else if (IsActive())
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


            var streamIdx = Array.IndexOf(My.MyProject.Forms.frmMain.streamerGroupBoxes, this);
            if (streamIdx < 0)
            {
                return;
            }

            string streamIdxStr = (streamIdx + 1).ToString("00");
            var streamerInfo = My.MyProject.Forms.frmMain.streamerInfos[idx];


            var qualities = getStreamQuality(streamerInfo.name);
            if (qualities.Count < 1)
            {
                Deactivate();
                return;
            }

            btnDeselect.Show();
            btnDeselect.Enabled = true;


            txtDisplayName.Text = streamerInfo.displayName ?? "";
            txtPronouns.Text = streamerInfo.pronouns ?? "";
            btnLaunch.Enabled = true;
            cbQuality.Enabled = true;
            cbQuality.Items.Add("best");
            cbQuality.Items.AddRange(qualities.ToArray());
            cbQuality.Items.Add("worst");
            cbQuality.SelectedIndex = 0;
            ResetScore();
            updScore.Enabled = true;

            var pronouns = streamerInfo.pronouns ?? "";
            writePronounsToFile(pronouns: pronouns, file: streamIdxStr);

            var outputName = streamerInfo.name;
            if (!string.IsNullOrEmpty(streamerInfo.displayName))
            {
                outputName = streamerInfo.displayName;
            }

            if (Settings.Default.boolCombinedStreamerPronounFile)
            {
                writeNameAndPronounsToFile(streamer: outputName, pronouns: pronouns, file: streamIdxStr);
            }
            else
            {
                writeNameToFile(streamer: outputName, file: streamIdxStr);
            }
        }

        public (int, int, int, int) GetWindowLocation()
        {
            var streamIdx = Array.IndexOf(My.MyProject.Forms.frmMain.streamerGroupBoxes, this);


            var width = Settings.Default.streamerWindowWidth;
            var height = Settings.Default.streamerWindowHeight;

            int startXpos = Settings.Default.streamerWindowStartX;
            int startYPos = Settings.Default.streamerWindowStartY;

            if (streamIdx < 0)
            {
                return (width, height, startXpos, startYPos);
            }

            var xPos = startXpos + streamIdx % Settings.Default.streamerWindowMaxPerRow * width;
            var yPos = startYPos + streamIdx / Settings.Default.streamerWindowMaxPerRow * height;

            return (width, height, xPos, yPos);
        }

        public void ResetScore()
        {
            updScore.Value = 0;

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
            cbQuality.Items.Clear();
            cbQuality.SelectedIndex = -1;
            ResetScore();
            updScore.Enabled = false;

            var streamIdx = Array.IndexOf(My.MyProject.Forms.frmMain.streamerGroupBoxes, this);
            if (streamIdx < 0)
            {
                return;
            }
            string streamIdxStr = (streamIdx + 1).ToString("00");

            writePronounsToFile(pronouns: "", file: streamIdxStr);
            writeNameToFile(streamer: "", file: streamIdxStr);
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

        public List<string> getStreamQuality(string streamer)
        {

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "streamlink",
                    Arguments = "https://twitch.tv/" + streamer,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                if (line.StartsWith("Available streams: "))
                {
                    return line
                        .Replace("Available streams: ", "")
                        .Replace("audio_only", "")
                        .Replace("(best)", "")
                        .Replace("(worst)", "")
                        .Split(',')
                        .Select(x => x.Trim())
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Reverse()
                        .ToList();
                }
            }

            return new List<string>();
        }

        public void genStream(string streamer, string quality, string windowTitle)
        {

            var (width, height, xPos, yPos) = GetWindowLocation();
            string vlcOptions = @"--config %AppData%\MossCast\vlcrc --no-qt-video-autoresize --no-qt-privacy-ask --video-x " + xPos + " --video-y " + yPos + " --width " + width + " --height " + height;
            string cmdOptions = @"-a "" " + vlcOptions + @" -"" --title " + windowTitle + " --hls-live-edge 1 twitch.tv/" + streamer + " " + quality;

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "streamlink",
                    Arguments = cmdOptions,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
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

            genStream(streamer: streamerInfo.name, quality: (string)cbQuality.SelectedItem ?? "best", windowTitle: windowTitle);
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
