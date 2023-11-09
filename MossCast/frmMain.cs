using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace MossCast
{

    public partial class frmMain
    {

        public StreamerGroupBox[] streamerGroupBoxes;
        public List<StreamerInfo> streamerInfos;
        public List<string> streamers;

        private string appdataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MossCast";

        public event StartupNextInstanceEventHandler StartupNextInstance;

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
        private uint WM_QUIT = 0x12U;
        private uint WM_CLOSE = 0x10U;

        // Form load
        public void frmMain_Load(object sender, EventArgs e)
        {

            if (My.MySettingsProperty.Settings.strPathToStreamerFile != "*.conf")
            {
                My.MySettingsProperty.Settings.strPathToStreamerFile = appdataFolder + @"\streamerlist.conf";
            }

            int x = Screen.PrimaryScreen.WorkingArea.Width - Width;
            int y = Screen.PrimaryScreen.WorkingArea.Height - Height;
            Location = new Point(x, y);

            if (!Directory.Exists(appdataFolder))
            {
                Directory.CreateDirectory(appdataFolder);
            }

            if (!File.Exists(My.MySettingsProperty.Settings.strPathToStreamerFile))
            {
                File.Create(My.MySettingsProperty.Settings.strPathToStreamerFile).Close();
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
            };
            setupLivestreamerCheck();
            setupStreamerSources();




            ToolStripStatusLabel1.Text = "Version " + GetType().Assembly.GetName().Version.ToString();
            tsmiCombineNamesPronouns.Checked = My.MySettingsProperty.Settings.boolCombinedStreamerPronounFile;
        }


        // Check that livestreamer is installed in the Program Files (x86) or Program Files folder
        public void setupLivestreamerCheck()
        {

            if (File.Exists(@"C:\Program Files (x86)\Streamlink\bin\streamlink.exe"))
            {
                My.MySettingsProperty.Settings.streamlinkDir = @"C:\Program Files (x86)\Streamlink\bin\streamlink.exe";
            }
            else if (File.Exists(@"C:\Program Files\Streamlink\bin\streamlink.exe"))
            {
                My.MySettingsProperty.Settings.streamlinkDir = @"C:\Program Files\Streamlink\bin\streamlink.exe";
            }

            if (!File.Exists(My.MySettingsProperty.Settings.streamlinkDir))
            {
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
                        My.MySettingsProperty.Settings.streamlinkDir = fd.FileName.ToString();
                    }
                    else
                    {
                        foreach (Control ctrl in Controls)
                            ctrl.Enabled = false;
                    }
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

            using (var reader = new StreamReader(My.MySettingsProperty.Settings.strPathToStreamerFile))
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

            if (string.IsNullOrEmpty(My.MySettingsProperty.Settings.strWindowSize))
            {
                My.MySettingsProperty.Settings.strWindowSize = Interaction.InputBox("You must define a window size for VLC - the default (for 1920x1080) is already entered below.  Enter the resolution as \"width height\".", "Define window size...", "882 520");
                if (string.IsNullOrEmpty(My.MySettingsProperty.Settings.strWindowSize))
                    My.MySettingsProperty.Settings.strWindowSize = "882 520";
            }

            string strXPos = My.MySettingsProperty.Settings.strWindowSize.Split(' ')[0];
            string strYPos = My.MySettingsProperty.Settings.strWindowSize.Split(' ')[1];

            int intXPos = int.Parse(strXPos) + 5;
            int intYPos = int.Parse(strYPos) - 5;
            IntPtr hWnd;

            string arglpClassName = null;
            string arglpWindowName = "First - VLC Media Player";
            hWnd = frmMain.FindWindow(arglpClassName, arglpWindowName);
            MoveWindow(hWnd, 0, 0, Conversions.ToInteger(strXPos), Conversions.ToInteger(strYPos), true);

            string arglpClassName1 = null;
            string arglpWindowName1 = "Second - VLC Media Player";
            hWnd = frmMain.FindWindow(arglpClassName1, arglpWindowName1);
            MoveWindow(hWnd, intXPos, 0, Conversions.ToInteger(strXPos), Conversions.ToInteger(strYPos), true);

            string arglpClassName2 = null;
            string arglpWindowName2 = "Third - VLC Media Player";
            hWnd = frmMain.FindWindow(arglpClassName2, arglpWindowName2);
            MoveWindow(hWnd, 0, intYPos, Conversions.ToInteger(strXPos), Conversions.ToInteger(strYPos), true);

            string arglpClassName3 = null;
            string arglpWindowName3 = "Fourth - VLC Media Player";
            hWnd = frmMain.FindWindow(arglpClassName3, arglpWindowName3);
            MoveWindow(hWnd, intXPos, intYPos, Conversions.ToInteger(strXPos), Conversions.ToInteger(strYPos), true);

        }

        // Close all VLC windows
        private void vlcKill_Click(object sender, EventArgs e)
        {

            IntPtr hWnd;
            string arglpClassName = null;
            string arglpWindowName = "First - VLC Media Player";
            hWnd = frmMain.FindWindow(arglpClassName, arglpWindowName);
            PostMessage((int)hWnd, WM_CLOSE, 0, 0);

            string arglpClassName1 = null;
            string arglpWindowName1 = "Second - VLC Media Player";
            hWnd = frmMain.FindWindow(arglpClassName1, arglpWindowName1);
            PostMessage((int)hWnd, WM_CLOSE, 0, 0);

            string arglpClassName2 = null;
            string arglpWindowName2 = "Third - VLC Media Player";
            hWnd = frmMain.FindWindow(arglpClassName2, arglpWindowName2);
            PostMessage((int)hWnd, WM_CLOSE, 0, 0);

            string arglpClassName3 = null;
            string arglpWindowName3 = "Fourth - VLC Media Player";
            hWnd = frmMain.FindWindow(arglpClassName3, arglpWindowName3);
            PostMessage((int)hWnd, WM_CLOSE, 0, 0);

        }

        // Generate all streams by "clicking" the 4 buttons
        private void btnGenAll_Click(object sender, EventArgs e)
        {

            // btnStream1Gen.PerformClick();

            if (!string.IsNullOrEmpty(My.MySettingsProperty.Settings.strWindowSize))
            {
                btnMoveResize.PerformClick();
            }
        }


        // Select file to use as autocomplete source
        private void selectAutocompleteFile_Click(object sender, EventArgs e)
        {

            var fd = new OpenFileDialog();

            fd.Title = "Select a file...";
            fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MossCast";
            fd.Filter = "Config files (*.conf)|*.conf";
            fd.RestoreDirectory = true;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                My.MySettingsProperty.Settings.strPathToStreamerFile = fd.FileName;
                setupStreamerSources();
            }
        }

        // Change window size for CMDOW
        private void tsmiChangeVLCWindowSize_Click(object sender, EventArgs e)
        {
            My.MySettingsProperty.Settings.strWindowSize = Interaction.InputBox("Define window size for VLC - enter the resolution as \"width height\".  Recommended sizes:" + Constants.vbCrLf + "1920x1080: 882x520" + Constants.vbCrLf + "1440x900: 642x385", "Define window size...", "882 520");
        }

        // Edit autcomplete file
        public void tsmiEditAutocompleteFile_Click(object sender, EventArgs e)
        {
            var frmEditStreamerList = new frmEditStreamerList();
            frmEditStreamerList.Show();
        }


        // Combined streamer name and pronouns file
        public void tsmiFileConfigure_Click(object sender, EventArgs e)
        {
            My.MySettingsProperty.Settings.boolCombinedStreamerPronounFile = tsmiCombineNamesPronouns.Checked;
        }

        // Handles CLI startup
        public void cliStartup(string[] args)
        {
            btnKillVLC.PerformClick();
        }


        private void tsmiOpenAppData_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MossCast");
        }

        private void tsmiEditStreamlinkConfig_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\streamlink\streamlinkrc");
        }

        private void ResetStreamlinkPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int boolResetStreamlinkPath = (int)MessageBox.Show("Reset the path to Streamlink?  Current path: " + Constants.vbNewLine + My.MySettingsProperty.Settings.streamlinkDir, "Reset Streamlink path", MessageBoxButtons.YesNo);

            if (boolResetStreamlinkPath == (int)DialogResult.Yes)
            {
                My.MySettingsProperty.Settings.streamlinkDir = "Not set";
                setupLivestreamerCheck();
            }
        }

    }
}