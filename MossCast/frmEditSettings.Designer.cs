
namespace MossCast
{
    partial class frmEditSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditSettings));
            this.groupBoxStreamlink = new System.Windows.Forms.GroupBox();
            this.buttonClearStreamlink = new System.Windows.Forms.Button();
            this.buttonBrowseStreamlink = new System.Windows.Forms.Button();
            this.textBoxStreamlink = new System.Windows.Forms.TextBox();
            this.groupBoxStreamerFile = new System.Windows.Forms.GroupBox();
            this.buttonClearStreamerFile = new System.Windows.Forms.Button();
            this.buttonBrowseStreamerFile = new System.Windows.Forms.Button();
            this.textBoxStreamerFile = new System.Windows.Forms.TextBox();
            this.groupBoxWinDimensions = new System.Windows.Forms.GroupBox();
            this.updWindowHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.updWindowWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.updWindowStartY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.updWindowStartX = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.updWindowMaxRows = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxCombineNameAndPronouns = new System.Windows.Forms.CheckBox();
            this.buttonResetAll = new System.Windows.Forms.Button();
            this.groupBoxStreamlink.SuspendLayout();
            this.groupBoxStreamerFile.SuspendLayout();
            this.groupBoxWinDimensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updWindowHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updWindowWidth)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updWindowStartY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updWindowStartX)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updWindowMaxRows)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxStreamlink
            // 
            this.groupBoxStreamlink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxStreamlink.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxStreamlink.Controls.Add(this.buttonClearStreamlink);
            this.groupBoxStreamlink.Controls.Add(this.buttonBrowseStreamlink);
            this.groupBoxStreamlink.Controls.Add(this.textBoxStreamlink);
            this.groupBoxStreamlink.Location = new System.Drawing.Point(12, 12);
            this.groupBoxStreamlink.Name = "groupBoxStreamlink";
            this.groupBoxStreamlink.Size = new System.Drawing.Size(660, 75);
            this.groupBoxStreamlink.TabIndex = 0;
            this.groupBoxStreamlink.TabStop = false;
            this.groupBoxStreamlink.Text = "Path to Streamlink";
            // 
            // buttonClearStreamlink
            // 
            this.buttonClearStreamlink.Location = new System.Drawing.Point(87, 45);
            this.buttonClearStreamlink.Name = "buttonClearStreamlink";
            this.buttonClearStreamlink.Size = new System.Drawing.Size(75, 23);
            this.buttonClearStreamlink.TabIndex = 2;
            this.buttonClearStreamlink.Text = "Reset";
            this.buttonClearStreamlink.UseVisualStyleBackColor = true;
            this.buttonClearStreamlink.Click += new System.EventHandler(this.buttonClearStreamlink_Click);
            // 
            // buttonBrowseStreamlink
            // 
            this.buttonBrowseStreamlink.Location = new System.Drawing.Point(6, 45);
            this.buttonBrowseStreamlink.Name = "buttonBrowseStreamlink";
            this.buttonBrowseStreamlink.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseStreamlink.TabIndex = 1;
            this.buttonBrowseStreamlink.Text = "Browse";
            this.buttonBrowseStreamlink.UseVisualStyleBackColor = true;
            this.buttonBrowseStreamlink.Click += new System.EventHandler(this.buttonBrowseStreamlink_Click);
            // 
            // textBoxStreamlink
            // 
            this.textBoxStreamlink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStreamlink.Enabled = false;
            this.textBoxStreamlink.Location = new System.Drawing.Point(6, 19);
            this.textBoxStreamlink.Name = "textBoxStreamlink";
            this.textBoxStreamlink.ReadOnly = true;
            this.textBoxStreamlink.Size = new System.Drawing.Size(648, 20);
            this.textBoxStreamlink.TabIndex = 0;
            // 
            // groupBoxStreamerFile
            // 
            this.groupBoxStreamerFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxStreamerFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxStreamerFile.Controls.Add(this.buttonClearStreamerFile);
            this.groupBoxStreamerFile.Controls.Add(this.buttonBrowseStreamerFile);
            this.groupBoxStreamerFile.Controls.Add(this.textBoxStreamerFile);
            this.groupBoxStreamerFile.Location = new System.Drawing.Point(12, 93);
            this.groupBoxStreamerFile.Name = "groupBoxStreamerFile";
            this.groupBoxStreamerFile.Size = new System.Drawing.Size(660, 75);
            this.groupBoxStreamerFile.TabIndex = 3;
            this.groupBoxStreamerFile.TabStop = false;
            this.groupBoxStreamerFile.Text = "Path to Streamer File";
            // 
            // buttonClearStreamerFile
            // 
            this.buttonClearStreamerFile.Location = new System.Drawing.Point(87, 45);
            this.buttonClearStreamerFile.Name = "buttonClearStreamerFile";
            this.buttonClearStreamerFile.Size = new System.Drawing.Size(75, 23);
            this.buttonClearStreamerFile.TabIndex = 2;
            this.buttonClearStreamerFile.Text = "Reset";
            this.buttonClearStreamerFile.UseVisualStyleBackColor = true;
            this.buttonClearStreamerFile.Click += new System.EventHandler(this.buttonClearStreamerFile_Click);
            // 
            // buttonBrowseStreamerFile
            // 
            this.buttonBrowseStreamerFile.Location = new System.Drawing.Point(6, 45);
            this.buttonBrowseStreamerFile.Name = "buttonBrowseStreamerFile";
            this.buttonBrowseStreamerFile.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseStreamerFile.TabIndex = 1;
            this.buttonBrowseStreamerFile.Text = "Browse";
            this.buttonBrowseStreamerFile.UseVisualStyleBackColor = true;
            this.buttonBrowseStreamerFile.Click += new System.EventHandler(this.buttonBrowseStreamerFile_Click);
            // 
            // textBoxStreamerFile
            // 
            this.textBoxStreamerFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStreamerFile.Enabled = false;
            this.textBoxStreamerFile.Location = new System.Drawing.Point(6, 19);
            this.textBoxStreamerFile.Name = "textBoxStreamerFile";
            this.textBoxStreamerFile.ReadOnly = true;
            this.textBoxStreamerFile.Size = new System.Drawing.Size(648, 20);
            this.textBoxStreamerFile.TabIndex = 0;
            // 
            // groupBoxWinDimensions
            // 
            this.groupBoxWinDimensions.Controls.Add(this.updWindowHeight);
            this.groupBoxWinDimensions.Controls.Add(this.label2);
            this.groupBoxWinDimensions.Controls.Add(this.updWindowWidth);
            this.groupBoxWinDimensions.Controls.Add(this.label1);
            this.groupBoxWinDimensions.Location = new System.Drawing.Point(12, 174);
            this.groupBoxWinDimensions.Name = "groupBoxWinDimensions";
            this.groupBoxWinDimensions.Size = new System.Drawing.Size(180, 79);
            this.groupBoxWinDimensions.TabIndex = 4;
            this.groupBoxWinDimensions.TabStop = false;
            this.groupBoxWinDimensions.Text = "Stream Window Dimensions";
            // 
            // updWindowHeight
            // 
            this.updWindowHeight.Location = new System.Drawing.Point(47, 49);
            this.updWindowHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.updWindowHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updWindowHeight.Name = "updWindowHeight";
            this.updWindowHeight.Size = new System.Drawing.Size(120, 20);
            this.updWindowHeight.TabIndex = 4;
            this.updWindowHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updWindowHeight.ValueChanged += new System.EventHandler(this.updWindowHeight_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height";
            // 
            // updWindowWidth
            // 
            this.updWindowWidth.Location = new System.Drawing.Point(47, 23);
            this.updWindowWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.updWindowWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updWindowWidth.Name = "updWindowWidth";
            this.updWindowWidth.Size = new System.Drawing.Size(120, 20);
            this.updWindowWidth.TabIndex = 2;
            this.updWindowWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updWindowWidth.ValueChanged += new System.EventHandler(this.updWindowWidth_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Width";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.updWindowStartY);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.updWindowStartX);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(198, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 79);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stream Window Start Position";
            // 
            // updWindowStartY
            // 
            this.updWindowStartY.Location = new System.Drawing.Point(31, 49);
            this.updWindowStartY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.updWindowStartY.Name = "updWindowStartY";
            this.updWindowStartY.Size = new System.Drawing.Size(120, 20);
            this.updWindowStartY.TabIndex = 4;
            this.updWindowStartY.ValueChanged += new System.EventHandler(this.updWindowStartY_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Y";
            // 
            // updWindowStartX
            // 
            this.updWindowStartX.Location = new System.Drawing.Point(31, 23);
            this.updWindowStartX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.updWindowStartX.Name = "updWindowStartX";
            this.updWindowStartX.Size = new System.Drawing.Size(120, 20);
            this.updWindowStartX.TabIndex = 2;
            this.updWindowStartX.ValueChanged += new System.EventHandler(this.updWindowStartX_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "X";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.updWindowMaxRows);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(368, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 53);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stream Window Layout";
            // 
            // updWindowMaxRows
            // 
            this.updWindowMaxRows.Location = new System.Drawing.Point(69, 23);
            this.updWindowMaxRows.Name = "updWindowMaxRows";
            this.updWindowMaxRows.Size = new System.Drawing.Size(120, 20);
            this.updWindowMaxRows.TabIndex = 2;
            this.updWindowMaxRows.ValueChanged += new System.EventHandler(this.updWindowMaxRows_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Max Rows";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxCombineNameAndPronouns);
            this.groupBox3.Location = new System.Drawing.Point(12, 259);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 47);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output File Settings";
            // 
            // checkBoxCombineNameAndPronouns
            // 
            this.checkBoxCombineNameAndPronouns.AutoSize = true;
            this.checkBoxCombineNameAndPronouns.Location = new System.Drawing.Point(6, 19);
            this.checkBoxCombineNameAndPronouns.Name = "checkBoxCombineNameAndPronouns";
            this.checkBoxCombineNameAndPronouns.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxCombineNameAndPronouns.Size = new System.Drawing.Size(148, 17);
            this.checkBoxCombineNameAndPronouns.TabIndex = 1;
            this.checkBoxCombineNameAndPronouns.Text = "Combine Name/Pronouns";
            this.checkBoxCombineNameAndPronouns.UseVisualStyleBackColor = true;
            this.checkBoxCombineNameAndPronouns.CheckedChanged += new System.EventHandler(this.checkBoxCombineNameAndPronouns_CheckedChanged);
            // 
            // buttonResetAll
            // 
            this.buttonResetAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResetAll.Location = new System.Drawing.Point(568, 326);
            this.buttonResetAll.Name = "buttonResetAll";
            this.buttonResetAll.Size = new System.Drawing.Size(104, 23);
            this.buttonResetAll.TabIndex = 8;
            this.buttonResetAll.Text = "Reset All Settings";
            this.buttonResetAll.UseVisualStyleBackColor = true;
            this.buttonResetAll.Click += new System.EventHandler(this.buttonResetAll_Click);
            // 
            // frmEditSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.buttonResetAll);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxWinDimensions);
            this.Controls.Add(this.groupBoxStreamerFile);
            this.Controls.Add(this.groupBoxStreamlink);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1200, 400);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "frmEditSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmEditSettings_Load);
            this.groupBoxStreamlink.ResumeLayout(false);
            this.groupBoxStreamlink.PerformLayout();
            this.groupBoxStreamerFile.ResumeLayout(false);
            this.groupBoxStreamerFile.PerformLayout();
            this.groupBoxWinDimensions.ResumeLayout(false);
            this.groupBoxWinDimensions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updWindowHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updWindowWidth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updWindowStartY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updWindowStartX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updWindowMaxRows)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxStreamlink;
        private System.Windows.Forms.Button buttonClearStreamlink;
        private System.Windows.Forms.Button buttonBrowseStreamlink;
        private System.Windows.Forms.TextBox textBoxStreamlink;
        private System.Windows.Forms.GroupBox groupBoxStreamerFile;
        private System.Windows.Forms.Button buttonClearStreamerFile;
        private System.Windows.Forms.Button buttonBrowseStreamerFile;
        private System.Windows.Forms.TextBox textBoxStreamerFile;
        private System.Windows.Forms.GroupBox groupBoxWinDimensions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown updWindowHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown updWindowWidth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown updWindowStartY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown updWindowStartX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown updWindowMaxRows;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxCombineNameAndPronouns;
        private System.Windows.Forms.Button buttonResetAll;
    }
}