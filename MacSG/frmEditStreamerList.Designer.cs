using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MacSG
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmEditStreamerList : Form
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditStreamerList));
            dgdStreamerList = new DataGridView();
            lblStreamerName = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgdStreamerList).BeginInit();
            SuspendLayout();
            // 
            // dgdStreamerList
            // 
            dgdStreamerList.AllowUserToResizeRows = false;
            dgdStreamerList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgdStreamerList.Columns.AddRange(new DataGridViewColumn[] { lblStreamerName });
            dgdStreamerList.Location = new Point(13, 13);
            dgdStreamerList.MaximumSize = new Size(328, 212);
            dgdStreamerList.MinimumSize = new Size(328, 212);
            dgdStreamerList.Name = "dgdStreamerList";
            dgdStreamerList.Size = new Size(328, 212);
            dgdStreamerList.TabIndex = 0;
            // 
            // lblStreamerName
            // 
            lblStreamerName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            lblStreamerName.HeaderText = "Streamer name";
            lblStreamerName.Name = "lblStreamerName";
            lblStreamerName.Resizable = DataGridViewTriState.False;
            // 
            // frmEditRacerList
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 236);
            Controls.Add(dgdStreamerList);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmEditRacerList";
            Text = "Edit streamer file";
            ((System.ComponentModel.ISupportInitialize)dgdStreamerList).EndInit();
            Load += new EventHandler(Form2_Load);
            FormClosing += new FormClosingEventHandler(Form2_FormClosing);
            ResumeLayout(false);

        }

        internal DataGridView dgdStreamerList;
        internal DataGridViewTextBoxColumn lblStreamerName;
    }
}