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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditStreamerList));
            this.dgdStreamerList = new System.Windows.Forms.DataGridView();
            this.lblStreamerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PronounsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgdStreamerList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgdStreamerList
            // 
            this.dgdStreamerList.AllowUserToResizeRows = false;
            this.dgdStreamerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgdStreamerList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgdStreamerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgdStreamerList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lblStreamerName,
            this.DisplayNameColumn,
            this.PronounsColumn});
            this.dgdStreamerList.Location = new System.Drawing.Point(13, 13);
            this.dgdStreamerList.Name = "dgdStreamerList";
            this.dgdStreamerList.Size = new System.Drawing.Size(550, 413);
            this.dgdStreamerList.TabIndex = 0;
            // 
            // lblStreamerName
            // 
            this.lblStreamerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lblStreamerName.HeaderText = "Streamer name";
            this.lblStreamerName.Name = "lblStreamerName";
            // 
            // DisplayNameColumn
            // 
            this.DisplayNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DisplayNameColumn.HeaderText = "Display Name";
            this.DisplayNameColumn.Name = "DisplayNameColumn";
            // 
            // PronounsColumn
            // 
            this.PronounsColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PronounsColumn.HeaderText = "Pronouns";
            this.PronounsColumn.Name = "PronounsColumn";
            // 
            // frmEditStreamerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 438);
            this.Controls.Add(this.dgdStreamerList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditStreamerList";
            this.Text = "Edit streamer file";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgdStreamerList)).EndInit();
            this.ResumeLayout(false);

        }

        internal DataGridView dgdStreamerList;
        private DataGridViewTextBoxColumn lblStreamerName;
        private DataGridViewTextBoxColumn DisplayNameColumn;
        private DataGridViewTextBoxColumn PronounsColumn;
    }
}