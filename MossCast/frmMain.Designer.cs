#pragma warning disable 1591

using System.Diagnostics;
using System.Windows.Forms;

namespace MossCast
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
        private System.ComponentModel.IContainer components = null;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnGenAll = new System.Windows.Forms.Button();
            this.btnKillVLC = new System.Windows.Forms.Button();
            this.btnMoveResize = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSelectAutocompleteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditAutocompleteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeVLCWindowSize = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenAppData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCombineNamesPronouns = new System.Windows.Forms.ToolStripMenuItem();
            this.StreamlinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiResetStreamlinkPath = new System.Windows.Forms.ToolStripMenuItem();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBoxControls = new System.Windows.Forms.GroupBox();
            this.btnQuickLoad = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.streamerGroupBox12 = new MossCast.StreamerGroupBox();
            this.streamerGroupBox11 = new MossCast.StreamerGroupBox();
            this.streamerGroupBox10 = new MossCast.StreamerGroupBox();
            this.streamerGroupBox9 = new MossCast.StreamerGroupBox();
            this.streamerGroupBox8 = new MossCast.StreamerGroupBox();
            this.streamerGroupBox7 = new MossCast.StreamerGroupBox();
            this.streamerGroupBox6 = new MossCast.StreamerGroupBox();
            this.streamerGroupBox5 = new MossCast.StreamerGroupBox();
            this.streamerGroupBox4 = new MossCast.StreamerGroupBox();
            this.streamerGroupBox3 = new MossCast.StreamerGroupBox();
            this.streamerGroupBox2 = new MossCast.StreamerGroupBox();
            this.streamerGroupBox1 = new MossCast.StreamerGroupBox();
            this.btnResetScore = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.groupBoxControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenAll
            // 
            this.btnGenAll.Location = new System.Drawing.Point(5, 86);
            this.btnGenAll.Name = "btnGenAll";
            this.btnGenAll.Size = new System.Drawing.Size(101, 29);
            this.btnGenAll.TabIndex = 17;
            this.btnGenAll.Text = "Launch All";
            this.btnGenAll.UseVisualStyleBackColor = true;
            this.btnGenAll.Click += new System.EventHandler(this.btnGenAll_Click);
            // 
            // btnKillVLC
            // 
            this.btnKillVLC.Location = new System.Drawing.Point(5, 121);
            this.btnKillVLC.Name = "btnKillVLC";
            this.btnKillVLC.Size = new System.Drawing.Size(101, 29);
            this.btnKillVLC.TabIndex = 16;
            this.btnKillVLC.Text = "Close All";
            this.btnKillVLC.UseVisualStyleBackColor = true;
            this.btnKillVLC.Click += new System.EventHandler(this.vlcKill_Click);
            // 
            // btnMoveResize
            // 
            this.btnMoveResize.Location = new System.Drawing.Point(5, 51);
            this.btnMoveResize.Name = "btnMoveResize";
            this.btnMoveResize.Size = new System.Drawing.Size(101, 29);
            this.btnMoveResize.TabIndex = 15;
            this.btnMoveResize.Text = "Move and Resize";
            this.btnMoveResize.UseVisualStyleBackColor = true;
            this.btnMoveResize.Click += new System.EventHandler(this.moveResize_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.StreamlinkToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MaximumSize = new System.Drawing.Size(470, 24);
            this.menuStrip1.MinimumSize = new System.Drawing.Size(470, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(470, 24);
            this.menuStrip1.TabIndex = 18;
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSelectAutocompleteFile,
            this.tsmiEditAutocompleteFile,
            this.tsmiChangeVLCWindowSize,
            this.tsmiOpenAppData,
            this.tsmiCombineNamesPronouns});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // tsmiSelectAutocompleteFile
            // 
            this.tsmiSelectAutocompleteFile.Name = "tsmiSelectAutocompleteFile";
            this.tsmiSelectAutocompleteFile.Size = new System.Drawing.Size(240, 22);
            this.tsmiSelectAutocompleteFile.Text = "Select Streamerlist File";
            this.tsmiSelectAutocompleteFile.Click += new System.EventHandler(this.selectAutocompleteFile_Click);
            // 
            // tsmiEditAutocompleteFile
            // 
            this.tsmiEditAutocompleteFile.Name = "tsmiEditAutocompleteFile";
            this.tsmiEditAutocompleteFile.Size = new System.Drawing.Size(240, 22);
            this.tsmiEditAutocompleteFile.Text = "Edit Streamerlist File";
            this.tsmiEditAutocompleteFile.Click += new System.EventHandler(this.tsmiEditAutocompleteFile_Click);
            // 
            // tsmiChangeVLCWindowSize
            // 
            this.tsmiChangeVLCWindowSize.Name = "tsmiChangeVLCWindowSize";
            this.tsmiChangeVLCWindowSize.Size = new System.Drawing.Size(240, 22);
            this.tsmiChangeVLCWindowSize.Text = "Change window size...";
            this.tsmiChangeVLCWindowSize.Click += new System.EventHandler(this.tsmiChangeVLCWindowSize_Click);
            // 
            // tsmiOpenAppData
            // 
            this.tsmiOpenAppData.Name = "tsmiOpenAppData";
            this.tsmiOpenAppData.Size = new System.Drawing.Size(240, 22);
            this.tsmiOpenAppData.Text = "Open AppData folder...";
            this.tsmiOpenAppData.Click += new System.EventHandler(this.tsmiOpenAppData_Click);
            // 
            // tsmiCombineNamesPronouns
            // 
            this.tsmiCombineNamesPronouns.CheckOnClick = true;
            this.tsmiCombineNamesPronouns.Name = "tsmiCombineNamesPronouns";
            this.tsmiCombineNamesPronouns.Size = new System.Drawing.Size(240, 22);
            this.tsmiCombineNamesPronouns.Text = "Combine Names and Pronouns";
            this.tsmiCombineNamesPronouns.Click += new System.EventHandler(this.tsmiFileConfigure_Click);
            // 
            // StreamlinkToolStripMenuItem
            // 
            this.StreamlinkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiResetStreamlinkPath});
            this.StreamlinkToolStripMenuItem.Name = "StreamlinkToolStripMenuItem";
            this.StreamlinkToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.StreamlinkToolStripMenuItem.Text = "Streamlink";
            // 
            // tsmiResetStreamlinkPath
            // 
            this.tsmiResetStreamlinkPath.BackColor = System.Drawing.SystemColors.Control;
            this.tsmiResetStreamlinkPath.Name = "tsmiResetStreamlinkPath";
            this.tsmiResetStreamlinkPath.Size = new System.Drawing.Size(129, 22);
            this.tsmiResetStreamlinkPath.Text = "Reset path";
            this.tsmiResetStreamlinkPath.Click += new System.EventHandler(this.ResetStreamlinkPathToolStripMenuItem_Click);
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(14, 22);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(1139, 8);
            this.ProgressBar1.TabIndex = 19;
            this.ProgressBar1.Visible = false;
            // 
            // statusLabel1
            // 
            this.statusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            this.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel1,
            this.ToolStripStatusLabel1});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 464);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.StatusStrip1.Size = new System.Drawing.Size(1164, 22);
            this.StatusStrip1.TabIndex = 21;
            // 
            // groupBoxControls
            // 
            this.groupBoxControls.Controls.Add(this.btnResetScore);
            this.groupBoxControls.Controls.Add(this.btnQuickLoad);
            this.groupBoxControls.Controls.Add(this.btnClearAll);
            this.groupBoxControls.Controls.Add(this.btnMoveResize);
            this.groupBoxControls.Controls.Add(this.btnKillVLC);
            this.groupBoxControls.Controls.Add(this.btnGenAll);
            this.groupBoxControls.Location = new System.Drawing.Point(1040, 36);
            this.groupBoxControls.Name = "groupBoxControls";
            this.groupBoxControls.Padding = new System.Windows.Forms.Padding(0);
            this.groupBoxControls.Size = new System.Drawing.Size(113, 418);
            this.groupBoxControls.TabIndex = 34;
            this.groupBoxControls.TabStop = false;
            this.groupBoxControls.Text = "Controls";
            // 
            // btnQuickLoad
            // 
            this.btnQuickLoad.Location = new System.Drawing.Point(5, 16);
            this.btnQuickLoad.Name = "btnQuickLoad";
            this.btnQuickLoad.Size = new System.Drawing.Size(101, 29);
            this.btnQuickLoad.TabIndex = 19;
            this.btnQuickLoad.Text = "Quick Load";
            this.btnQuickLoad.UseVisualStyleBackColor = true;
            this.btnQuickLoad.Click += new System.EventHandler(this.btnQuickLoad_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(5, 156);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(101, 29);
            this.btnClearAll.TabIndex = 18;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // streamerGroupBox12
            // 
            this.streamerGroupBox12.Header = "Stream 12";
            this.streamerGroupBox12.Location = new System.Drawing.Point(781, 319);
            this.streamerGroupBox12.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.streamerGroupBox12.Name = "streamerGroupBox12";
            this.streamerGroupBox12.Size = new System.Drawing.Size(251, 142);
            this.streamerGroupBox12.TabIndex = 33;
            // 
            // streamerGroupBox11
            // 
            this.streamerGroupBox11.Header = "Stream 11";
            this.streamerGroupBox11.Location = new System.Drawing.Point(524, 319);
            this.streamerGroupBox11.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.streamerGroupBox11.Name = "streamerGroupBox11";
            this.streamerGroupBox11.Size = new System.Drawing.Size(251, 142);
            this.streamerGroupBox11.TabIndex = 32;
            // 
            // streamerGroupBox10
            // 
            this.streamerGroupBox10.Header = "Stream 10";
            this.streamerGroupBox10.Location = new System.Drawing.Point(269, 319);
            this.streamerGroupBox10.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.streamerGroupBox10.Name = "streamerGroupBox10";
            this.streamerGroupBox10.Size = new System.Drawing.Size(251, 142);
            this.streamerGroupBox10.TabIndex = 31;
            // 
            // streamerGroupBox9
            // 
            this.streamerGroupBox9.Header = "Stream 9";
            this.streamerGroupBox9.Location = new System.Drawing.Point(12, 319);
            this.streamerGroupBox9.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.streamerGroupBox9.Name = "streamerGroupBox9";
            this.streamerGroupBox9.Size = new System.Drawing.Size(251, 142);
            this.streamerGroupBox9.TabIndex = 30;
            // 
            // streamerGroupBox8
            // 
            this.streamerGroupBox8.Header = "Stream 8";
            this.streamerGroupBox8.Location = new System.Drawing.Point(781, 177);
            this.streamerGroupBox8.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.streamerGroupBox8.Name = "streamerGroupBox8";
            this.streamerGroupBox8.Size = new System.Drawing.Size(251, 142);
            this.streamerGroupBox8.TabIndex = 29;
            // 
            // streamerGroupBox7
            // 
            this.streamerGroupBox7.Header = "Stream 7";
            this.streamerGroupBox7.Location = new System.Drawing.Point(524, 177);
            this.streamerGroupBox7.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.streamerGroupBox7.Name = "streamerGroupBox7";
            this.streamerGroupBox7.Size = new System.Drawing.Size(251, 142);
            this.streamerGroupBox7.TabIndex = 28;
            // 
            // streamerGroupBox6
            // 
            this.streamerGroupBox6.Header = "Stream 6";
            this.streamerGroupBox6.Location = new System.Drawing.Point(269, 177);
            this.streamerGroupBox6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.streamerGroupBox6.Name = "streamerGroupBox6";
            this.streamerGroupBox6.Size = new System.Drawing.Size(251, 142);
            this.streamerGroupBox6.TabIndex = 27;
            // 
            // streamerGroupBox5
            // 
            this.streamerGroupBox5.Header = "Stream 5";
            this.streamerGroupBox5.Location = new System.Drawing.Point(12, 177);
            this.streamerGroupBox5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.streamerGroupBox5.Name = "streamerGroupBox5";
            this.streamerGroupBox5.Size = new System.Drawing.Size(251, 142);
            this.streamerGroupBox5.TabIndex = 26;
            // 
            // streamerGroupBox4
            // 
            this.streamerGroupBox4.Header = "Stream 4";
            this.streamerGroupBox4.Location = new System.Drawing.Point(783, 33);
            this.streamerGroupBox4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.streamerGroupBox4.Name = "streamerGroupBox4";
            this.streamerGroupBox4.Size = new System.Drawing.Size(251, 142);
            this.streamerGroupBox4.TabIndex = 25;
            // 
            // streamerGroupBox3
            // 
            this.streamerGroupBox3.Header = "Stream 3";
            this.streamerGroupBox3.Location = new System.Drawing.Point(526, 33);
            this.streamerGroupBox3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.streamerGroupBox3.Name = "streamerGroupBox3";
            this.streamerGroupBox3.Size = new System.Drawing.Size(251, 142);
            this.streamerGroupBox3.TabIndex = 24;
            // 
            // streamerGroupBox2
            // 
            this.streamerGroupBox2.Header = "Stream 2";
            this.streamerGroupBox2.Location = new System.Drawing.Point(269, 32);
            this.streamerGroupBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.streamerGroupBox2.Name = "streamerGroupBox2";
            this.streamerGroupBox2.Size = new System.Drawing.Size(251, 142);
            this.streamerGroupBox2.TabIndex = 23;
            // 
            // streamerGroupBox1
            // 
            this.streamerGroupBox1.Header = "Stream 1";
            this.streamerGroupBox1.Location = new System.Drawing.Point(12, 32);
            this.streamerGroupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.streamerGroupBox1.Name = "streamerGroupBox1";
            this.streamerGroupBox1.Size = new System.Drawing.Size(251, 142);
            this.streamerGroupBox1.TabIndex = 22;
            // 
            // btnResetScore
            // 
            this.btnResetScore.Location = new System.Drawing.Point(5, 191);
            this.btnResetScore.Name = "btnResetScore";
            this.btnResetScore.Size = new System.Drawing.Size(101, 29);
            this.btnResetScore.TabIndex = 20;
            this.btnResetScore.Text = "Reset Scores";
            this.btnResetScore.UseVisualStyleBackColor = true;
            this.btnResetScore.Click += new System.EventHandler(this.btnResetScore_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 486);
            this.Controls.Add(this.groupBoxControls);
            this.Controls.Add(this.streamerGroupBox12);
            this.Controls.Add(this.streamerGroupBox11);
            this.Controls.Add(this.streamerGroupBox10);
            this.Controls.Add(this.streamerGroupBox9);
            this.Controls.Add(this.streamerGroupBox8);
            this.Controls.Add(this.streamerGroupBox7);
            this.Controls.Add(this.streamerGroupBox6);
            this.Controls.Add(this.streamerGroupBox5);
            this.Controls.Add(this.streamerGroupBox4);
            this.Controls.Add(this.streamerGroupBox3);
            this.Controls.Add(this.streamerGroupBox2);
            this.Controls.Add(this.streamerGroupBox1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1180, 525);
            this.MinimumSize = new System.Drawing.Size(1180, 525);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MossCast";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.groupBoxControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal Button btnGenAll;
        private Button btnKillVLC;
        private Button btnMoveResize;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem1;
        private ToolStripMenuItem tsmiSelectAutocompleteFile;
        internal ToolStripMenuItem tsmiEditAutocompleteFile;
        internal ToolStripMenuItem tsmiChangeVLCWindowSize;
        internal ToolStripMenuItem tsmiOpenAppData;
        internal ToolStripMenuItem StreamlinkToolStripMenuItem;
        internal ToolStripMenuItem tsmiResetStreamlinkPath;
        internal ToolStripMenuItem tsmiCombineNamesPronouns;
        internal ProgressBar ProgressBar1;
        private StreamerGroupBox streamerGroupBox1;
        private StreamerGroupBox streamerGroupBox2;
        internal ToolStripStatusLabel statusLabel1;
        internal ToolStripStatusLabel ToolStripStatusLabel1;
        internal StatusStrip StatusStrip1;
        private StreamerGroupBox streamerGroupBox4;
        private StreamerGroupBox streamerGroupBox3;
        private StreamerGroupBox streamerGroupBox8;
        private StreamerGroupBox streamerGroupBox7;
        private StreamerGroupBox streamerGroupBox6;
        private StreamerGroupBox streamerGroupBox5;
        private StreamerGroupBox streamerGroupBox12;
        private StreamerGroupBox streamerGroupBox11;
        private StreamerGroupBox streamerGroupBox10;
        private StreamerGroupBox streamerGroupBox9;
        private GroupBox groupBoxControls;
        private Button btnClearAll;
        private Button btnQuickLoad;
        private Button btnResetScore;
    }
}