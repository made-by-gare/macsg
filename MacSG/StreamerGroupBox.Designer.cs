
namespace MacSG
{
    partial class StreamerGroupBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupStreamer = new System.Windows.Forms.GroupBox();
            this.lblPronouns = new System.Windows.Forms.Label();
            this.txtPronouns = new System.Windows.Forms.TextBox();
            this.cbStreamer = new System.Windows.Forms.ComboBox();
            this.cbQuality = new System.Windows.Forms.ComboBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.lblStreamer = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.updScore = new System.Windows.Forms.NumericUpDown();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.btnDeselect = new System.Windows.Forms.Button();
            this.groupStreamer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updScore)).BeginInit();
            this.SuspendLayout();
            // 
            // groupStreamer
            // 
            this.groupStreamer.Controls.Add(this.btnDeselect);
            this.groupStreamer.Controls.Add(this.lblPronouns);
            this.groupStreamer.Controls.Add(this.txtPronouns);
            this.groupStreamer.Controls.Add(this.cbStreamer);
            this.groupStreamer.Controls.Add(this.cbQuality);
            this.groupStreamer.Controls.Add(this.lblDisplayName);
            this.groupStreamer.Controls.Add(this.lblStreamer);
            this.groupStreamer.Controls.Add(this.txtDisplayName);
            this.groupStreamer.Controls.Add(this.updScore);
            this.groupStreamer.Controls.Add(this.btnLaunch);
            this.groupStreamer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupStreamer.Location = new System.Drawing.Point(3, 3);
            this.groupStreamer.Name = "groupStreamer";
            this.groupStreamer.Size = new System.Drawing.Size(241, 132);
            this.groupStreamer.TabIndex = 12;
            this.groupStreamer.TabStop = false;
            this.groupStreamer.Text = "Stream";
            this.groupStreamer.Enter += new System.EventHandler(this.stream1Group_Enter);
            // 
            // lblPronouns
            // 
            this.lblPronouns.AutoSize = true;
            this.lblPronouns.Location = new System.Drawing.Point(26, 71);
            this.lblPronouns.Name = "lblPronouns";
            this.lblPronouns.Size = new System.Drawing.Size(52, 13);
            this.lblPronouns.TabIndex = 27;
            this.lblPronouns.Text = "Pronouns";
            // 
            // txtPronouns
            // 
            this.txtPronouns.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtPronouns.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPronouns.Location = new System.Drawing.Point(84, 68);
            this.txtPronouns.Name = "txtPronouns";
            this.txtPronouns.ReadOnly = true;
            this.txtPronouns.Size = new System.Drawing.Size(135, 20);
            this.txtPronouns.TabIndex = 26;
            this.txtPronouns.WordWrap = false;
            // 
            // cbStreamer
            // 
            this.cbStreamer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStreamer.FormattingEnabled = true;
            this.cbStreamer.Location = new System.Drawing.Point(84, 15);
            this.cbStreamer.Name = "cbStreamer";
            this.cbStreamer.Size = new System.Drawing.Size(135, 21);
            this.cbStreamer.TabIndex = 22;
            this.cbStreamer.SelectedIndexChanged += new System.EventHandler(this.cbStreamer_SelectedIndexChanged);
            // 
            // cbQuality
            // 
            this.cbQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuality.Enabled = false;
            this.cbQuality.FormattingEnabled = true;
            this.cbQuality.Items.AddRange(new object[] {
            "best"});
            this.cbQuality.Location = new System.Drawing.Point(99, 98);
            this.cbQuality.Name = "cbQuality";
            this.cbQuality.Size = new System.Drawing.Size(75, 21);
            this.cbQuality.TabIndex = 25;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Location = new System.Drawing.Point(6, 45);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(72, 13);
            this.lblDisplayName.TabIndex = 24;
            this.lblDisplayName.Text = "Display Name";
            // 
            // lblStreamer
            // 
            this.lblStreamer.AutoSize = true;
            this.lblStreamer.Location = new System.Drawing.Point(29, 18);
            this.lblStreamer.Name = "lblStreamer";
            this.lblStreamer.Size = new System.Drawing.Size(49, 13);
            this.lblStreamer.TabIndex = 22;
            this.lblStreamer.Text = "Streamer";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtDisplayName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDisplayName.Location = new System.Drawing.Point(84, 42);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.ReadOnly = true;
            this.txtDisplayName.Size = new System.Drawing.Size(135, 20);
            this.txtDisplayName.TabIndex = 23;
            this.txtDisplayName.WordWrap = false;
            // 
            // updScore
            // 
            this.updScore.Enabled = false;
            this.updScore.Location = new System.Drawing.Point(180, 98);
            this.updScore.Name = "updScore";
            this.updScore.Size = new System.Drawing.Size(39, 20);
            this.updScore.TabIndex = 8;
            this.updScore.ValueChanged += new System.EventHandler(this.updScore_ValueChanged);
            // 
            // btnLaunch
            // 
            this.btnLaunch.Enabled = false;
            this.btnLaunch.Location = new System.Drawing.Point(9, 98);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(84, 21);
            this.btnLaunch.TabIndex = 1;
            this.btnLaunch.Text = "Launch";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // btnDeselect
            // 
            this.btnDeselect.Enabled = false;
            this.btnDeselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.btnDeselect.Location = new System.Drawing.Point(222, 18);
            this.btnDeselect.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeselect.Name = "btnDeselect";
            this.btnDeselect.Size = new System.Drawing.Size(16, 16);
            this.btnDeselect.TabIndex = 28;
            this.btnDeselect.Text = "X";
            this.btnDeselect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeselect.UseVisualStyleBackColor = true;
            this.btnDeselect.Visible = false;
            this.btnDeselect.Click += new System.EventHandler(this.btnDeselect_Click);
            // 
            // StreamerGroupBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupStreamer);
            this.Name = "StreamerGroupBox";
            this.Size = new System.Drawing.Size(251, 142);
            this.groupStreamer.ResumeLayout(false);
            this.groupStreamer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupStreamer;
        private System.Windows.Forms.Label lblPronouns;
        private System.Windows.Forms.TextBox txtPronouns;
        private System.Windows.Forms.ComboBox cbStreamer;
        private System.Windows.Forms.ComboBox cbQuality;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.Label lblStreamer;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.NumericUpDown updScore;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Button btnDeselect;
    }
}
