using System;
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

namespace MacSG
{

    public partial class frmMain
    {
        private AutoCompleteStringCollection strColAutoCompleteList = new AutoCompleteStringCollection();

        private TextBox[] txtArray;
        private TextBox[] pronounsArray;
        private JCS.ToggleSwitch[] switchArray;
        private TrackBar[] trkbrArray;
        private Button[] btnArray;

        private string appdataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\macsg";

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

            setupLivestreamerCheck();

            setupAutocompleteSources();
            ControlArrayItems();

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                args[0] = args[1];
                cliStartup(args: args);
            }

            ToolStripStatusLabel1.Text = "Version " + GetType().Assembly.GetName().Version.ToString();

            tsmiCombineNamesPronouns.Checked = My.MySettingsProperty.Settings.boolCombinedStreamerPronounFile;

        }

        public void ControlArrayItems()
        {
            txtArray = new[] { txtStream1, txtStream2, txtStream3, txtStream4 };
            pronounsArray = new[] { txtPronouns1, txtPronouns2, txtPronouns3, txtPronouns4 };
            trkbrArray = new[] { trkbrStream1, trkbrStream2, trkbrStream3, trkbrStream4 };
            btnArray = new[] { btnStream1Gen, btnStream2Gen, btnStream3Gen, btnStream4Gen };
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

                    client.DownloadFileAsync(new Uri("https://github.com/streamlink/windows-builds/releases/download/4.3.0-1/streamlink-4.3.0-1-py310-x86.exe"), Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MacSG\streamlink-1.1.1.exe");
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
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MacSG\streamlink-1.1.1.exe");
                Close();
            }

            else
            {
                MessageBox.Show("There was an error downloading Streamlink.  Please try running the application as an Administrator and try again.");
                ProgressBar1.Visible = false;
            }
        }

        // Defines autocomplete sources for all textboxes
        public void setupAutocompleteSources()
        {

            using (var reader = new StreamReader(My.MySettingsProperty.Settings.strPathToStreamerFile))
            {
                strColAutoCompleteList.Clear();
                while (!reader.EndOfStream)
                    strColAutoCompleteList.Add(reader.ReadLine());
            }

            txtStream1.AutoCompleteCustomSource = strColAutoCompleteList;
            txtStream2.AutoCompleteCustomSource = strColAutoCompleteList;
            txtStream3.AutoCompleteCustomSource = strColAutoCompleteList;
            txtStream4.AutoCompleteCustomSource = strColAutoCompleteList;

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

            btnStream1Gen.PerformClick();
            btnStream2Gen.PerformClick();
            btnStream3Gen.PerformClick();
            btnStream4Gen.PerformClick();

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
            fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MacSG";
            fd.Filter = "Config files (*.conf)|*.conf";
            fd.RestoreDirectory = true;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                My.MySettingsProperty.Settings.strPathToStreamerFile = fd.FileName;

                frmMain_Load(this, e);

                txtStream1.Text = "";
                txtStream2.Text = "";
                txtStream3.Text = "";
                txtStream4.Text = "";
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


        // Unattached subs
        public void genStream(string streamer, string quality, string source, string windowTitle, string configFile, string racerNumber)
        {
            string runningProcess = "/c title " + windowTitle + " & " + source + @"-a "" --config %AppData%\MacSG\vlcrc --width 877 --height 518 -"" " + " --title " + racerNumber + " --hls-live-edge 1 twitch.tv/" + streamer + quality;
            var strLivestreamerProcess = new ProcessStartInfo("cmd.exe", runningProcess);

            strLivestreamerProcess.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(strLivestreamerProcess);

        }

        public void writeNameToFile(string streamer, string file)
        {

            string strPathtoName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MacSG\streamer" + file + ".txt";
            StreamWriter swstreamer;
            swstreamer = My.MyProject.Computer.FileSystem.OpenTextFileWriter(strPathtoName, false);
            swstreamer.WriteLine(streamer);
            swstreamer.Close();

        }
        public void writePronounsToFile(string pronouns, string file)
        {

            string strPathtoName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MacSG\streamer-pronouns" + file + ".txt";
            StreamWriter swstreamer;
            swstreamer = My.MyProject.Computer.FileSystem.OpenTextFileWriter(strPathtoName, false);
            swstreamer.WriteLine(pronouns);
            swstreamer.Close();

        }

        public void writeNameAndPronounsToFile(string streamer, string pronouns, string file)
        {

            string strPathtoName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MacSG\streamer" + file + ".txt";


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

        public void writeNameToAutocomplete(string streamer)
        {

            var streamers = File.ReadLines(My.MySettingsProperty.Settings.strPathToStreamerFile);

            if (!streamers.Contains(streamer.ToLower()))
            {
                using (var w = new StreamWriter(My.MySettingsProperty.Settings.strPathToStreamerFile, append: true))
                {
                    w.WriteLine(streamer.ToLower());
                }
            }

            setupAutocompleteSources();

        }

        // Write udStream control values to text files
        public void updControls_Changed(object sender, EventArgs e)
        {

            string updIndex = ((Control)sender).Name.Remove(0, 9);

            using (var swScore = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MacSG\score" + updIndex + ".txt"))
            {
                swScore.Write(((NumericUpDown)sender).Value);
            }

        }

        // Handles CLI startup
        public void cliStartup(string[] args)
        {

            btnKillVLC.PerformClick();

            if (args.Length > 0)
            {

                string[] splitArgs = args[0].Split(new char[] { ',' });
                splitArgs[0] = splitArgs[0].Replace("macsg:", "");

                // DO NOT SUBMIT rework this completely?
                if (splitArgs.Length > 4)
                {
                    Array.Resize(ref splitArgs, 4);
                }

                for (int i = 0, loopTo = splitArgs.Length - 1; i <= loopTo; i++)
                {
                    if (!string.IsNullOrEmpty(splitArgs[i]))
                    {
                        string[] splitRacer = splitArgs[i].Split(new char[] { ';' });
                        if (splitRacer.Length == 2)
                        {
                            pronounsArray[i].Text = splitRacer[1];
                        }
                        else if (splitRacer.Length != 1)
                        {
                            Interaction.MsgBox("Invalid command line arguments, exiting...");
                            Application.Exit();
                            return;
                        }
                        txtArray[i].Text = splitRacer[0];
                        btnArray[i].PerformClick();
                    }
                }
            }
        }


        // Generate streams
        public void streamButton_Clicked(object sender, EventArgs e)
        {

            int ctrlIndex = int.Parse(Regex.Replace(((Button)sender).Name, "[^1-4]", ""));

            // Dim openWindow As Boolean
            string strWindowTitle = "";
            string vlcWindowTitle = "";

            switch (ctrlIndex)
            {
                case 1:
                    {
                        strWindowTitle = "FirstCMD";
                        vlcWindowTitle = "First";
                        break;
                    }
                case 2:
                    {
                        strWindowTitle = "SecondCMD";
                        vlcWindowTitle = "Second";
                        break;
                    }
                case 3:
                    {
                        strWindowTitle = "ThirdCMD";
                        vlcWindowTitle = "Third";
                        break;
                    }
                case 4:
                    {
                        strWindowTitle = "FourthCMD";
                        vlcWindowTitle = "Fourth";
                        break;
                    }
            }

            if (processChecker(sender: btnArray[ctrlIndex - 1], ctrlIndex: ctrlIndex) == false)
            {
                if (!string.IsNullOrEmpty(txtArray[ctrlIndex - 1].Text))
                {
                    string strSource = "";
                    string strQuality = "";

                    switch (trkbrArray[ctrlIndex - 1].Value)
                    {
                        case 1:
                            {
                                strQuality = " low ";
                                break;
                            }
                        case 2:
                            {
                                strQuality = " medium ";
                                break;
                            }
                        case 3:
                            {
                                strQuality = " high ";
                                break;
                            }
                        case 4:
                            {
                                strQuality = " best ";
                                break;
                            }
                    }
                    strSource = "streamlink ";

                    genStream(streamer: txtArray[ctrlIndex - 1].Text.ToLower(), quality: strQuality, source: strSource, windowTitle: strWindowTitle, configFile: ctrlIndex.ToString(), racerNumber: vlcWindowTitle);
                    writeNameToAutocomplete(streamer: txtArray[ctrlIndex - 1].Text.ToLower());
                    string pronouns = pronounsArray[ctrlIndex - 1].Text;

                    if (!string.IsNullOrEmpty(pronouns))
                    {
                        writePronounsToFile(pronouns: pronouns, file: ctrlIndex.ToString());
                    }
                    else
                    {
                        writePronounsToFile(pronouns: "", file: ctrlIndex.ToString());
                    }


                    if (My.MySettingsProperty.Settings.boolCombinedStreamerPronounFile)
                    {
                        writeNameAndPronounsToFile(streamer: txtArray[ctrlIndex - 1].Text, pronouns: pronouns, file: ctrlIndex.ToString());
                    }
                    else
                    {
                        writeNameToFile(streamer: txtArray[ctrlIndex - 1].Text, file: ctrlIndex.ToString());
                    }

                }
            }
        }

        private void InstallMacsgHandlerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            bool isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (isElevated == true)
            {

                var regMacSG = Registry.ClassesRoot.CreateSubKey("macsg");
                regMacSG.SetValue("", "URL:MacSG Protocol");
                regMacSG.SetValue("URL Protocol", "");

                var regDefaultIcon = regMacSG.CreateSubKey("DefaultIcon");
                regDefaultIcon.SetValue("", Path.GetFileName(Application.ExecutablePath));

                var regShell = regMacSG.CreateSubKey("shell");
                var regOpen = regShell.CreateSubKey("open");
                var regCommand = regOpen.CreateSubKey("Command");
                regCommand.SetValue("", Application.ExecutablePath + " %1");

                Interaction.MsgBox("To finish enabling the protocol, you must reboot your PC.");
            }

            else
            {
                Interaction.MsgBox("MacSG must be running with Administrator privileges to install the custom protocol.  Please relaunch MacSG as an Administrator.");
            }

        }


        public bool processChecker(Button sender, int ctrlIndex)
        {

            Process[] procProcesses = Process.GetProcesses();
            var openWindow = default(bool);
            string strWindowTitle = "";

            switch (ctrlIndex)
            {
                case 1:
                    {
                        strWindowTitle = "First";
                        break;
                    }
                case 2:
                    {
                        strWindowTitle = "Second";
                        break;
                    }
                case 3:
                    {
                        strWindowTitle = "Third";
                        break;
                    }
                case 4:
                    {
                        strWindowTitle = "Fourth";
                        break;
                    }
            }

            foreach (Process p in procProcesses)
            {
                if (p.MainWindowTitle.Contains(strWindowTitle))
                {
                    openWindow = true;
                    break;
                }
                else
                {
                    openWindow = false;
                }

            }

            return openWindow;

        }

        private void tsmiCondorSchedule_Click(object sender, EventArgs e)
        {
            Process.Start("https://condor.live/schedule");
        }

        private void tsmiOpenAppData_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MacSG");
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

        private void CheckForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string githubApiUrl = "https://api.github.com/repos/necrommunity/macsg/releases/latest";
            string githubHeaders = "Accept:  application/vnd.github+json";
            var webClient = new WebClient();
            webClient.Headers.Add(githubHeaders);

            string githubResponse;

            try
            {
                githubResponse = webClient.DownloadString(new Uri(githubApiUrl));
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response is not null)
                {
                    HttpWebResponse response = (HttpWebResponse)ex.Response;
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        Interaction.MsgBox("Error checking for latest MacSG releases");
                    }
                }
                throw;
            }

            Interaction.MsgBox(githubResponse);

        }
    }
}