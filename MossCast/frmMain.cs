#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;


namespace MossCast
{

    public partial class frmMain
    {

        public StreamerGroupBox[] streamerGroupBoxes;
        public List<StreamerInfo> streamerInfos;
        public List<string> streamers;

        public string appdataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MossCast";

        public delegate void StartupNextInstanceEventHandler(object sender, StartupNextInstanceEventArgs e);

        public frmMain()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(IntPtr hWnd, string lpString);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool PostMessage(int hwnd, uint message, int wParam, int lParam);

        private uint WM_CLOSE = 0x10U;

        // Form load
        public void frmMain_Load(object sender, EventArgs e)
        {

            if (Settings.Default.strPathToStreamerFile != "*.conf")
            {
                Settings.Default.strPathToStreamerFile = appdataFolder + @"\streamerlist.conf";
                Settings.Default.Save();
            }

            int x = Screen.PrimaryScreen.WorkingArea.Width - Width;
            int y = Screen.PrimaryScreen.WorkingArea.Height - Height;
            Location = new Point(x, y);

            if (!Directory.Exists(appdataFolder))
            {
                Directory.CreateDirectory(appdataFolder);
            }

            if (!File.Exists(Settings.Default.strPathToStreamerFile))
            {
                File.Create(Settings.Default.strPathToStreamerFile).Close();
            }


            streamerGroupBoxes = new[] {
                streamerGroupBox1,
                streamerGroupBox2,
                streamerGroupBox3,
                streamerGroupBox4,
                streamerGroupBox5,
                streamerGroupBox6,
                streamerGroupBox7,
                streamerGroupBox8,
                streamerGroupBox9,
                streamerGroupBox10,
                streamerGroupBox11,
                streamerGroupBox12,
            };
            setupStreamLinkCheck();
            setupStreamerSources();

            ToolStripStatusLabel1.Text = "Version " + GetType().Assembly.GetName().Version.ToString();
        }


        // Check that livestreamer is installed in the Program Files (x86) or Program Files folder
        public void setupStreamLinkCheck()
        {

            if (!string.IsNullOrEmpty(Settings.Default.streamlinkDir) && File.Exists(Settings.Default.streamlinkDir))
            {
                return;
            }


            var possibleLocations = new[]{
                @"C:\Program Files (x86)\Streamlink\bin\streamlink.exe",
                @"C:\Program Files\Streamlink\bin\streamlink.exe",
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Streamlink\bin\streamlink.exe",
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Streamlink\bin\streamlink.exe",
            };

            foreach (var location in possibleLocations)
            {
                if (File.Exists(location))
                {
                    Settings.Default.streamlinkDir = location;
                    Settings.Default.Save();
                    return;
                }
            }


            int boolStreamlink = (int)MessageBox.Show("Streamlink was not found in its default directory.  Click Yes to download the latest version from GitHub, or No to specify streamlink.exe's location.", "Streamlink not found", MessageBoxButtons.YesNo);

            if (boolStreamlink == (int)DialogResult.Yes)
            {
                foreach (Control ctrl in Controls)
                    ctrl.Enabled = false;
                var client = new WebClient();
                client.DownloadProgressChanged += ShowDownloadProgress;
                client.DownloadFileCompleted += DownloadFileCompleted;

                client.DownloadFileAsync(new Uri("https://github.com/streamlink/windows-builds/releases/download/4.3.0-1/streamlink-4.3.0-1-py310-x86.exe"), Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MossCast\streamlink-1.1.1.exe");
            }
            else if (boolStreamlink == (int)DialogResult.No)
            {
                var fd = new OpenFileDialog();

                fd.Title = "Select a file...";
                fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                fd.Filter = "Streamlink executable (*.exe)|*.exe";
                fd.RestoreDirectory = true;

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    Settings.Default.streamlinkDir = fd.FileName.ToString();
                    Settings.Default.Save();
                }
                else
                {
                    foreach (Control ctrl in Controls)
                        ctrl.Enabled = false;
                }
            }

        }

        // Handler for Streamlink download progress bar
        private void ShowDownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressBar1.Visible = true;
            ProgressBar1.Value = e.ProgressPercentage;
        }

        // Runs Streamlink after it has finished downloading; throws error if download fails.
        public void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error is null)
            {
                ProgressBar1.Visible = false;
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MossCast\streamlink-1.1.1.exe");
                Close();
            }
            else
            {
                MessageBox.Show("There was an error downloading Streamlink.  Please try running the application as an Administrator and try again.");
                ProgressBar1.Visible = false;
            }
        }

        // Defines autocomplete sources for all textboxes
        public void setupStreamerSources()
        {

            using (var reader = new StreamReader(Settings.Default.strPathToStreamerFile))
            {
                streamers = new List<string>();
                streamerInfos = new List<StreamerInfo>();
                while (!reader.EndOfStream)
                {
                    List<string> parts = reader.ReadLine().Split(',').Select(x => x.Trim()).ToList();
                    if (parts.Count() < 1 || string.IsNullOrEmpty(parts[0]))
                    {
                        continue;
                    }
                    streamers.Add(parts[0]);
                    streamerInfos.Add(
                        new StreamerInfo(
                            parts[0],
                            parts.ElementAtOrDefault(1),
                            parts.ElementAtOrDefault(2)
                        )
                    );
                }

                foreach (StreamerGroupBox streamerGroupBox in streamerGroupBoxes)
                {
                    streamerGroupBox.UpdateDataSource(streamers);
                }

            }

        }

        // Move and resize all windows
        private void moveResize_Click(object sender, EventArgs e)
        {
            IntPtr hWnd;

            var idx = 1;
            foreach (var group in streamerGroupBoxes)
            {
                var idxStr = idx.ToString("00");

                string arglpClassName = null;
                string arglpWindowName = "Stream" + idxStr + " - VLC Media Player";
                var (width, height, xPos, yPos) = group.GetWindowLocation();
                hWnd = frmMain.FindWindow(arglpClassName, arglpWindowName);
                MoveWindow(hWnd, xPos, yPos, width, height, true);

                idx += 1;
            }

        }

        // Close all VLC windows
        private void vlcKill_Click(object sender, EventArgs e)
        {

            var idx = 1;
            foreach (var group in streamerGroupBoxes)
            {
                var idxStr = idx.ToString("00");

                IntPtr hWnd;
                string arglpClassName = null;
                string arglpWindowName = "Stream" + idxStr + " - VLC Media Player";
                hWnd = frmMain.FindWindow(arglpClassName, arglpWindowName);
                PostMessage((int)hWnd, WM_CLOSE, 0, 0);

                idx += 1;
            }
        }

        // Generate all streams
        private void btnGenAll_Click(object sender, EventArgs e)
        {

            foreach (var group in streamerGroupBoxes)
            {
                group.Launch();
            }
        }


        // Edit autcomplete file
        public void tsmiEditAutocompleteFile_Click(object sender, EventArgs e)
        {
            var frmEditStreamerList = new frmEditStreamerList();
            frmEditStreamerList.Show();
        }


        private void tsmiOpenAppData_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MossCast");
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {

            vlcKill_Click(sender, e);
            foreach (var group in streamerGroupBoxes)
            {
                group.Deactivate();
            }
        }

        private void btnQuickLoad_Click(object sender, EventArgs e)
        {
            var response = Interaction.InputBox("Please provide a comma delimited list of streamers", "Quick Load Streamers");
            if (string.IsNullOrEmpty(response))
            {
                return;
            }
            var streamers = response
                .Split(',')
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrEmpty(x))
                .Where(x => this.streamers.Contains(x))
                .ToList();

            if (streamers.Count <= 0)
            {
                return;
            }

            foreach (var streamerGroupBox in streamerGroupBoxes)
            {

                if (streamers.Count <= 0)
                {
                    break;
                }

                if (streamerGroupBox.IsActive())
                {
                    continue;
                }

                streamerGroupBox.SelectStreamer(streamers[0]);
                streamers.RemoveAt(0);
            }
        }

        private void btnResetScore_Click(object sender, EventArgs e)
        {
            foreach (var group in streamerGroupBoxes)
            {
                group.ResetScore();
            }

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmEditSettings();
            form.Show();
        }

        private void buttonRefreshFiles_Click(object sender, EventArgs e)
        {

            var streamIdx = 0;
            foreach (var group in streamerGroupBoxes)
            {
                string streamIdxStr = (streamIdx + 1).ToString("00");
                var streamerInfo = group.GetSelectedStreamerInfo();
                if (streamerInfo is null)
                {
                    continue;
                }
                group.WriteFiles(streamIdxStr, streamerInfo);
                streamIdx += 1;
            }
        }

        private void buttonFilePlaceholders_Click(object sender, EventArgs e)
        {
            var streamIdx = 0;
            foreach (var group in streamerGroupBoxes)
            {
                string streamIdxStr = (streamIdx + 1).ToString("00");
                group.WritePlaceholders(streamIdxStr);
                streamIdx += 1;

            }
        }
    }
}