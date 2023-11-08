using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MacSG
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmMain : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            btnGenAll = new Button();
            btnGenAll.Click += new EventHandler(btnGenAll_Click);
            btnKillVLC = new Button();
            btnKillVLC.Click += new EventHandler(vlcKill_Click);
            btnMoveResize = new Button();
            btnMoveResize.Click += new EventHandler(moveResize_Click);
            stream1Group = new GroupBox();
            Label2 = new Label();
            Label1 = new Label();
            txtPronouns1 = new TextBox();
            updStream1 = new NumericUpDown();
            updStream1.ValueChanged += new EventHandler(updControls_Changed);
            trkbrStream1 = new TrackBar();
            txtStream1 = new TextBox();
            btnStream1Gen = new Button();
            btnStream1Gen.Click += new EventHandler(streamButton_Clicked);
            stream2Group = new GroupBox();
            Label3 = new Label();
            txtPronouns2 = new TextBox();
            Label4 = new Label();
            updStream2 = new NumericUpDown();
            updStream2.ValueChanged += new EventHandler(updControls_Changed);
            txtStream2 = new TextBox();
            trkbrStream2 = new TrackBar();
            btnStream2Gen = new Button();
            btnStream2Gen.Click += new EventHandler(streamButton_Clicked);
            stream3Group = new GroupBox();
            Label5 = new Label();
            txtPronouns3 = new TextBox();
            Label6 = new Label();
            updStream3 = new NumericUpDown();
            updStream3.ValueChanged += new EventHandler(updControls_Changed);
            txtStream3 = new TextBox();
            trkbrStream3 = new TrackBar();
            btnStream3Gen = new Button();
            btnStream3Gen.Click += new EventHandler(streamButton_Clicked);
            stream4Group = new GroupBox();
            Label7 = new Label();
            txtPronouns4 = new TextBox();
            Label8 = new Label();
            updStream4 = new NumericUpDown();
            updStream4.ValueChanged += new EventHandler(updControls_Changed);
            txtStream4 = new TextBox();
            trkbrStream4 = new TrackBar();
            btnStream4Gen = new Button();
            btnStream4Gen.Click += new EventHandler(streamButton_Clicked);
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem1 = new ToolStripMenuItem();
            tsmiSelectAutocompleteFile = new ToolStripMenuItem();
            tsmiSelectAutocompleteFile.Click += new EventHandler(selectAutocompleteFile_Click);
            tsmiEditAutocompleteFile = new ToolStripMenuItem();
            tsmiEditAutocompleteFile.Click += new EventHandler(tsmiEditAutocompleteFile_Click);
            tsmiChangeVLCWindowSize = new ToolStripMenuItem();
            tsmiChangeVLCWindowSize.Click += new EventHandler(tsmiChangeVLCWindowSize_Click);
            InstallMacsgHandlerToolStripMenuItem = new ToolStripMenuItem();
            InstallMacsgHandlerToolStripMenuItem.Click += new EventHandler(InstallMacsgHandlerToolStripMenuItem_Click);
            tsmiOpenAppData = new ToolStripMenuItem();
            tsmiOpenAppData.Click += new EventHandler(tsmiOpenAppData_Click);
            tsmiCombineNamesPronouns = new ToolStripMenuItem();
            tsmiCombineNamesPronouns.Click += new EventHandler(tsmiFileConfigure_Click);
            CheckForUpdatesToolStripMenuItem = new ToolStripMenuItem();
            CheckForUpdatesToolStripMenuItem.Click += new EventHandler(CheckForUpdatesToolStripMenuItem_Click);
            tsmiCondorSchedule = new ToolStripMenuItem();
            tsmiCondorSchedule.Click += new EventHandler(tsmiCondorSchedule_Click);
            StreamlinkToolStripMenuItem = new ToolStripMenuItem();
            tsmiEditStreamlinkConfig = new ToolStripMenuItem();
            tsmiEditStreamlinkConfig.Click += new EventHandler(tsmiEditStreamlinkConfig_Click);
            tsmiResetStreamlinkPath = new ToolStripMenuItem();
            tsmiResetStreamlinkPath.Click += new EventHandler(ResetStreamlinkPathToolStripMenuItem_Click);
            ProgressBar1 = new ProgressBar();
            StatusStrip1 = new StatusStrip();
            statusLabel1 = new ToolStripStatusLabel();
            ToolStripStatusLabel1 = new ToolStripStatusLabel();
            stream1Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)updStream1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trkbrStream1).BeginInit();
            stream2Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)updStream2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trkbrStream2).BeginInit();
            stream3Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)updStream3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trkbrStream3).BeginInit();
            stream4Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)updStream4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trkbrStream4).BeginInit();
            menuStrip1.SuspendLayout();
            StatusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGenAll
            // 
            btnGenAll.Location = new Point(310, 69);
            btnGenAll.Name = "btnGenAll";
            btnGenAll.Size = new Size(101, 29);
            btnGenAll.TabIndex = 17;
            btnGenAll.Text = "Generate all";
            btnGenAll.UseVisualStyleBackColor = true;
            // 
            // btnKillVLC
            // 
            btnKillVLC.Location = new Point(310, 103);
            btnKillVLC.Name = "btnKillVLC";
            btnKillVLC.Size = new Size(101, 29);
            btnKillVLC.TabIndex = 16;
            btnKillVLC.Text = "Close all windows";
            btnKillVLC.UseVisualStyleBackColor = true;
            // 
            // btnMoveResize
            // 
            btnMoveResize.Location = new Point(310, 34);
            btnMoveResize.Name = "btnMoveResize";
            btnMoveResize.Size = new Size(101, 29);
            btnMoveResize.TabIndex = 15;
            btnMoveResize.Text = "Move and Resize";
            btnMoveResize.UseVisualStyleBackColor = true;
            // 
            // stream1Group
            // 
            stream1Group.Controls.Add(Label2);
            stream1Group.Controls.Add(Label1);
            stream1Group.Controls.Add(txtPronouns1);
            stream1Group.Controls.Add(updStream1);
            stream1Group.Controls.Add(trkbrStream1);
            stream1Group.Controls.Add(txtStream1);
            stream1Group.Controls.Add(btnStream1Gen);
            stream1Group.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            stream1Group.Location = new Point(12, 27);
            stream1Group.Name = "stream1Group";
            stream1Group.Size = new Size(292, 69);
            stream1Group.TabIndex = 11;
            stream1Group.TabStop = false;
            stream1Group.Text = "Stream 1";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(6, 45);
            Label2.Name = "Label2";
            Label2.Size = new Size(52, 13);
            Label2.TabIndex = 24;
            Label2.Text = "Pronouns";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(6, 19);
            Label1.Name = "Label1";
            Label1.Size = new Size(55, 13);
            Label1.TabIndex = 22;
            Label1.Text = "Username";
            // 
            // txtPronouns1
            // 
            txtPronouns1.AutoCompleteMode = AutoCompleteMode.Append;
            txtPronouns1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPronouns1.Location = new Point(63, 42);
            txtPronouns1.Name = "txtPronouns1";
            txtPronouns1.Size = new Size(67, 20);
            txtPronouns1.TabIndex = 23;
            txtPronouns1.WordWrap = false;
            // 
            // updStream1
            // 
            updStream1.Location = new Point(236, 44);
            updStream1.Name = "updStream1";
            updStream1.Size = new Size(39, 20);
            updStream1.TabIndex = 8;
            // 
            // trkbrStream1
            // 
            trkbrStream1.Enabled = false;
            trkbrStream1.LargeChange = 1;
            trkbrStream1.Location = new Point(226, 13);
            trkbrStream1.Maximum = 4;
            trkbrStream1.Minimum = 1;
            trkbrStream1.Name = "trkbrStream1";
            trkbrStream1.Size = new Size(60, 45);
            trkbrStream1.TabIndex = 3;
            trkbrStream1.TabStop = false;
            trkbrStream1.Value = 4;
            // 
            // txtStream1
            // 
            txtStream1.AutoCompleteMode = AutoCompleteMode.Append;
            txtStream1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtStream1.Location = new Point(63, 16);
            txtStream1.Name = "txtStream1";
            txtStream1.Size = new Size(157, 20);
            txtStream1.TabIndex = 0;
            // 
            // btnStream1Gen
            // 
            btnStream1Gen.Location = new Point(136, 42);
            btnStream1Gen.Name = "btnStream1Gen";
            btnStream1Gen.Size = new Size(84, 21);
            btnStream1Gen.TabIndex = 1;
            btnStream1Gen.Text = "Generate";
            btnStream1Gen.UseVisualStyleBackColor = true;
            // 
            // stream2Group
            // 
            stream2Group.Controls.Add(Label3);
            stream2Group.Controls.Add(txtPronouns2);
            stream2Group.Controls.Add(Label4);
            stream2Group.Controls.Add(updStream2);
            stream2Group.Controls.Add(txtStream2);
            stream2Group.Controls.Add(trkbrStream2);
            stream2Group.Controls.Add(btnStream2Gen);
            stream2Group.Location = new Point(12, 102);
            stream2Group.Name = "stream2Group";
            stream2Group.Size = new Size(292, 69);
            stream2Group.TabIndex = 12;
            stream2Group.TabStop = false;
            stream2Group.Text = "Stream 2";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Location = new Point(6, 45);
            Label3.Name = "Label3";
            Label3.Size = new Size(52, 13);
            Label3.TabIndex = 26;
            Label3.Text = "Pronouns";
            // 
            // txtPronouns2
            // 
            txtPronouns2.AutoCompleteMode = AutoCompleteMode.Append;
            txtPronouns2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPronouns2.Location = new Point(63, 42);
            txtPronouns2.Name = "txtPronouns2";
            txtPronouns2.Size = new Size(67, 20);
            txtPronouns2.TabIndex = 24;
            txtPronouns2.WordWrap = false;
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Location = new Point(6, 19);
            Label4.Name = "Label4";
            Label4.Size = new Size(55, 13);
            Label4.TabIndex = 25;
            Label4.Text = "Username";
            // 
            // updStream2
            // 
            updStream2.Location = new Point(237, 43);
            updStream2.Name = "updStream2";
            updStream2.Size = new Size(38, 20);
            updStream2.TabIndex = 11;
            // 
            // txtStream2
            // 
            txtStream2.AutoCompleteMode = AutoCompleteMode.Append;
            txtStream2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtStream2.Location = new Point(63, 16);
            txtStream2.Name = "txtStream2";
            txtStream2.Size = new Size(157, 20);
            txtStream2.TabIndex = 0;
            // 
            // trkbrStream2
            // 
            trkbrStream2.Enabled = false;
            trkbrStream2.LargeChange = 1;
            trkbrStream2.Location = new Point(226, 13);
            trkbrStream2.Maximum = 4;
            trkbrStream2.Minimum = 1;
            trkbrStream2.Name = "trkbrStream2";
            trkbrStream2.Size = new Size(60, 45);
            trkbrStream2.TabIndex = 3;
            trkbrStream2.TabStop = false;
            trkbrStream2.Value = 4;
            // 
            // btnStream2Gen
            // 
            btnStream2Gen.Location = new Point(136, 42);
            btnStream2Gen.Name = "btnStream2Gen";
            btnStream2Gen.Size = new Size(84, 21);
            btnStream2Gen.TabIndex = 1;
            btnStream2Gen.Text = "Generate";
            btnStream2Gen.UseVisualStyleBackColor = true;
            // 
            // stream3Group
            // 
            stream3Group.Controls.Add(Label5);
            stream3Group.Controls.Add(txtPronouns3);
            stream3Group.Controls.Add(Label6);
            stream3Group.Controls.Add(updStream3);
            stream3Group.Controls.Add(txtStream3);
            stream3Group.Controls.Add(trkbrStream3);
            stream3Group.Controls.Add(btnStream3Gen);
            stream3Group.Location = new Point(12, 177);
            stream3Group.Name = "stream3Group";
            stream3Group.Size = new Size(292, 69);
            stream3Group.TabIndex = 13;
            stream3Group.TabStop = false;
            stream3Group.Text = "Stream 3";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Location = new Point(6, 45);
            Label5.Name = "Label5";
            Label5.Size = new Size(52, 13);
            Label5.TabIndex = 28;
            Label5.Text = "Pronouns";
            // 
            // txtPronouns3
            // 
            txtPronouns3.AutoCompleteMode = AutoCompleteMode.Append;
            txtPronouns3.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPronouns3.Location = new Point(63, 42);
            txtPronouns3.Name = "txtPronouns3";
            txtPronouns3.Size = new Size(67, 20);
            txtPronouns3.TabIndex = 25;
            txtPronouns3.WordWrap = false;
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Location = new Point(6, 19);
            Label6.Name = "Label6";
            Label6.Size = new Size(55, 13);
            Label6.TabIndex = 27;
            Label6.Text = "Username";
            // 
            // updStream3
            // 
            updStream3.Location = new Point(237, 43);
            updStream3.Name = "updStream3";
            updStream3.Size = new Size(38, 20);
            updStream3.TabIndex = 12;
            // 
            // txtStream3
            // 
            txtStream3.AutoCompleteMode = AutoCompleteMode.Append;
            txtStream3.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtStream3.Location = new Point(63, 16);
            txtStream3.Name = "txtStream3";
            txtStream3.Size = new Size(157, 20);
            txtStream3.TabIndex = 0;
            // 
            // trkbrStream3
            // 
            trkbrStream3.Enabled = false;
            trkbrStream3.LargeChange = 1;
            trkbrStream3.Location = new Point(226, 13);
            trkbrStream3.Maximum = 4;
            trkbrStream3.Minimum = 1;
            trkbrStream3.Name = "trkbrStream3";
            trkbrStream3.Size = new Size(60, 45);
            trkbrStream3.TabIndex = 3;
            trkbrStream3.TabStop = false;
            trkbrStream3.Value = 4;
            // 
            // btnStream3Gen
            // 
            btnStream3Gen.Location = new Point(136, 42);
            btnStream3Gen.Name = "btnStream3Gen";
            btnStream3Gen.Size = new Size(84, 21);
            btnStream3Gen.TabIndex = 1;
            btnStream3Gen.Text = "Generate";
            btnStream3Gen.UseVisualStyleBackColor = true;
            // 
            // stream4Group
            // 
            stream4Group.Controls.Add(Label7);
            stream4Group.Controls.Add(txtPronouns4);
            stream4Group.Controls.Add(Label8);
            stream4Group.Controls.Add(updStream4);
            stream4Group.Controls.Add(txtStream4);
            stream4Group.Controls.Add(trkbrStream4);
            stream4Group.Controls.Add(btnStream4Gen);
            stream4Group.Location = new Point(12, 252);
            stream4Group.Name = "stream4Group";
            stream4Group.Size = new Size(292, 69);
            stream4Group.TabIndex = 14;
            stream4Group.TabStop = false;
            stream4Group.Text = "Stream 4";
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Location = new Point(6, 45);
            Label7.Name = "Label7";
            Label7.Size = new Size(52, 13);
            Label7.TabIndex = 30;
            Label7.Text = "Pronouns";
            // 
            // txtPronouns4
            // 
            txtPronouns4.AutoCompleteMode = AutoCompleteMode.Append;
            txtPronouns4.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPronouns4.Location = new Point(63, 42);
            txtPronouns4.Name = "txtPronouns4";
            txtPronouns4.Size = new Size(67, 20);
            txtPronouns4.TabIndex = 25;
            txtPronouns4.WordWrap = false;
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.Location = new Point(6, 19);
            Label8.Name = "Label8";
            Label8.Size = new Size(55, 13);
            Label8.TabIndex = 29;
            Label8.Text = "Username";
            // 
            // updStream4
            // 
            updStream4.Location = new Point(237, 43);
            updStream4.Name = "updStream4";
            updStream4.Size = new Size(38, 20);
            updStream4.TabIndex = 13;
            // 
            // txtStream4
            // 
            txtStream4.AutoCompleteMode = AutoCompleteMode.Append;
            txtStream4.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtStream4.Location = new Point(63, 16);
            txtStream4.Name = "txtStream4";
            txtStream4.Size = new Size(157, 20);
            txtStream4.TabIndex = 0;
            // 
            // trkbrStream4
            // 
            trkbrStream4.Enabled = false;
            trkbrStream4.LargeChange = 1;
            trkbrStream4.Location = new Point(226, 13);
            trkbrStream4.Maximum = 4;
            trkbrStream4.Minimum = 1;
            trkbrStream4.Name = "trkbrStream4";
            trkbrStream4.Size = new Size(60, 45);
            trkbrStream4.TabIndex = 3;
            trkbrStream4.TabStop = false;
            trkbrStream4.Value = 4;
            // 
            // btnStream4Gen
            // 
            btnStream4Gen.Location = new Point(136, 42);
            btnStream4Gen.Name = "btnStream4Gen";
            btnStream4Gen.RightToLeft = RightToLeft.No;
            btnStream4Gen.Size = new Size(84, 21);
            btnStream4Gen.TabIndex = 1;
            btnStream4Gen.Text = "Generate";
            btnStream4Gen.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem1, tsmiCondorSchedule, StreamlinkToolStripMenuItem });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.MaximumSize = new Size(470, 24);
            menuStrip1.MinimumSize = new Size(470, 24);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(470, 24);
            menuStrip1.TabIndex = 18;
            // 
            // fileToolStripMenuItem1
            // 
            fileToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { tsmiSelectAutocompleteFile, tsmiEditAutocompleteFile, tsmiChangeVLCWindowSize, InstallMacsgHandlerToolStripMenuItem, tsmiOpenAppData, tsmiCombineNamesPronouns, CheckForUpdatesToolStripMenuItem });
            fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            fileToolStripMenuItem1.Size = new Size(37, 20);
            fileToolStripMenuItem1.Text = "File";
            // 
            // tsmiSelectAutocompleteFile
            // 
            tsmiSelectAutocompleteFile.Name = "tsmiSelectAutocompleteFile";
            tsmiSelectAutocompleteFile.Size = new Size(240, 22);
            tsmiSelectAutocompleteFile.Text = "Select autocomplete file...";
            // 
            // tsmiEditAutocompleteFile
            // 
            tsmiEditAutocompleteFile.Name = "tsmiEditAutocompleteFile";
            tsmiEditAutocompleteFile.Size = new Size(240, 22);
            tsmiEditAutocompleteFile.Text = "Edit autocomplete file...";
            // 
            // tsmiChangeVLCWindowSize
            // 
            tsmiChangeVLCWindowSize.Name = "tsmiChangeVLCWindowSize";
            tsmiChangeVLCWindowSize.Size = new Size(240, 22);
            tsmiChangeVLCWindowSize.Text = "Change window size...";
            // 
            // InstallMacsgHandlerToolStripMenuItem
            // 
            InstallMacsgHandlerToolStripMenuItem.Name = "InstallMacsgHandlerToolStripMenuItem";
            InstallMacsgHandlerToolStripMenuItem.Size = new Size(240, 22);
            InstallMacsgHandlerToolStripMenuItem.Text = "Install macsg: protocol";
            // 
            // tsmiOpenAppData
            // 
            tsmiOpenAppData.Name = "tsmiOpenAppData";
            tsmiOpenAppData.Size = new Size(240, 22);
            tsmiOpenAppData.Text = "Open AppData folder...";
            // 
            // tsmiCombineNamesPronouns
            // 
            tsmiCombineNamesPronouns.CheckOnClick = true;
            tsmiCombineNamesPronouns.Name = "tsmiCombineNamesPronouns";
            tsmiCombineNamesPronouns.Size = new Size(240, 22);
            tsmiCombineNamesPronouns.Text = "Combine Names and Pronouns";
            // 
            // CheckForUpdatesToolStripMenuItem
            // 
            CheckForUpdatesToolStripMenuItem.Enabled = false;
            CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem";
            CheckForUpdatesToolStripMenuItem.Size = new Size(240, 22);
            CheckForUpdatesToolStripMenuItem.Text = "Check for updates";
            // 
            // tsmiCondorSchedule
            // 
            tsmiCondorSchedule.AutoToolTip = true;
            tsmiCondorSchedule.Name = "tsmiCondorSchedule";
            tsmiCondorSchedule.Size = new Size(118, 20);
            tsmiCondorSchedule.Text = "CoNDOR Schedule";
            // 
            // StreamlinkToolStripMenuItem
            // 
            StreamlinkToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiEditStreamlinkConfig, tsmiResetStreamlinkPath });
            StreamlinkToolStripMenuItem.Name = "StreamlinkToolStripMenuItem";
            StreamlinkToolStripMenuItem.Size = new Size(75, 20);
            StreamlinkToolStripMenuItem.Text = "Streamlink";
            // 
            // tsmiEditStreamlinkConfig
            // 
            tsmiEditStreamlinkConfig.Name = "tsmiEditStreamlinkConfig";
            tsmiEditStreamlinkConfig.Size = new Size(159, 22);
            tsmiEditStreamlinkConfig.Text = "Edit config file...";
            // 
            // tsmiResetStreamlinkPath
            // 
            tsmiResetStreamlinkPath.BackColor = SystemColors.Control;
            tsmiResetStreamlinkPath.Name = "tsmiResetStreamlinkPath";
            tsmiResetStreamlinkPath.Size = new Size(159, 22);
            tsmiResetStreamlinkPath.Text = "Reset path";
            // 
            // ProgressBar1
            // 
            ProgressBar1.Location = new Point(12, 22);
            ProgressBar1.Name = "ProgressBar1";
            ProgressBar1.Size = new Size(399, 4);
            ProgressBar1.TabIndex = 19;
            ProgressBar1.Visible = false;
            // 
            // StatusStrip1
            // 
            StatusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel1, ToolStripStatusLabel1 });
            StatusStrip1.Location = new Point(0, 320);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.RenderMode = ToolStripRenderMode.Professional;
            StatusStrip1.Size = new Size(418, 22);
            StatusStrip1.TabIndex = 21;
            // 
            // statusLabel1
            // 
            statusLabel1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            statusLabel1.Name = "statusLabel1";
            statusLabel1.Size = new Size(0, 17);
            // 
            // ToolStripStatusLabel1
            // 
            ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            ToolStripStatusLabel1.Size = new Size(0, 17);
            ToolStripStatusLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 342);
            Controls.Add(StatusStrip1);
            Controls.Add(ProgressBar1);
            Controls.Add(menuStrip1);
            Controls.Add(btnGenAll);
            Controls.Add(btnKillVLC);
            Controls.Add(btnMoveResize);
            Controls.Add(stream1Group);
            Controls.Add(stream2Group);
            Controls.Add(stream3Group);
            Controls.Add(stream4Group);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(600, 381);
            MinimumSize = new Size(381, 381);
            Name = "frmMain";
            StartPosition = FormStartPosition.Manual;
            Text = "MacSG";
            stream1Group.ResumeLayout(false);
            stream1Group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)updStream1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trkbrStream1).EndInit();
            stream2Group.ResumeLayout(false);
            stream2Group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)updStream2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trkbrStream2).EndInit();
            stream3Group.ResumeLayout(false);
            stream3Group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)updStream3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trkbrStream3).EndInit();
            stream4Group.ResumeLayout(false);
            stream4Group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)updStream4).EndInit();
            ((System.ComponentModel.ISupportInitialize)trkbrStream4).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            Load += new EventHandler(frmMain_Load);
            ResumeLayout(false);
            PerformLayout();

        }

        internal Button btnGenAll;
        private Button btnKillVLC;
        private Button btnMoveResize;
        private GroupBox stream1Group;
        internal NumericUpDown updStream1;
        internal TrackBar trkbrStream1;
        internal TextBox txtStream1;
        private Button btnStream1Gen;
        private GroupBox stream2Group;
        internal NumericUpDown updStream2;
        internal TextBox txtStream2;
        internal TrackBar trkbrStream2;
        private Button btnStream2Gen;
        private GroupBox stream3Group;
        internal NumericUpDown updStream3;
        internal TextBox txtStream3;
        internal TrackBar trkbrStream3;
        private Button btnStream3Gen;
        private GroupBox stream4Group;
        internal NumericUpDown updStream4;
        internal TextBox txtStream4;
        internal TrackBar trkbrStream4;
        private Button btnStream4Gen;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem1;
        private ToolStripMenuItem tsmiSelectAutocompleteFile;
        internal ToolStripMenuItem tsmiEditAutocompleteFile;
        internal ToolStripMenuItem tsmiChangeVLCWindowSize;
        internal ProgressBar ProgressBar1;
        internal ToolStripMenuItem InstallMacsgHandlerToolStripMenuItem;
        internal StatusStrip StatusStrip1;
        internal ToolStripStatusLabel statusLabel1;
        internal ToolStripMenuItem tsmiCondorSchedule;
        internal ToolStripMenuItem tsmiOpenAppData;
        internal ToolStripMenuItem StreamlinkToolStripMenuItem;
        internal ToolStripMenuItem tsmiEditStreamlinkConfig;
        internal ToolStripMenuItem tsmiResetStreamlinkPath;
        internal ToolStripStatusLabel ToolStripStatusLabel1;
        internal TextBox txtPronouns1;
        internal TextBox txtPronouns2;
        internal TextBox txtPronouns3;
        internal TextBox txtPronouns4;
        internal Label Label1;
        internal Label Label2;
        internal Label Label3;
        internal Label Label4;
        internal Label Label5;
        internal Label Label6;
        internal Label Label7;
        internal Label Label8;
        internal ToolStripMenuItem tsmiCombineNamesPronouns;
        internal ToolStripMenuItem CheckForUpdatesToolStripMenuItem;
    }
}