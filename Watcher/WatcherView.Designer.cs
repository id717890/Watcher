namespace Watcher
{
    partial class WatcherView
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStartWatch = new System.Windows.Forms.Button();
            this.cbGroups = new System.Windows.Forms.ComboBox();
            this.dgWatch = new System.Windows.Forms.DataGridView();
            this.btnStopWatch = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWatch)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.panel1, 0, 0);
            this.tlpMain.Controls.Add(this.dgWatch, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1036, 450);
            this.tlpMain.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStopWatch);
            this.panel1.Controls.Add(this.btnStartWatch);
            this.panel1.Controls.Add(this.cbGroups);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 44);
            this.panel1.TabIndex = 0;
            // 
            // btnStartWatch
            // 
            this.btnStartWatch.Location = new System.Drawing.Point(240, 7);
            this.btnStartWatch.Name = "btnStartWatch";
            this.btnStartWatch.Size = new System.Drawing.Size(75, 23);
            this.btnStartWatch.TabIndex = 1;
            this.btnStartWatch.Text = "start";
            this.btnStartWatch.UseVisualStyleBackColor = true;
            // 
            // cbGroups
            // 
            this.cbGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbGroups.FormattingEnabled = true;
            this.cbGroups.Location = new System.Drawing.Point(9, 9);
            this.cbGroups.Name = "cbGroups";
            this.cbGroups.Size = new System.Drawing.Size(164, 21);
            this.cbGroups.TabIndex = 0;
            // 
            // dgWatch
            // 
            this.dgWatch.AllowUserToAddRows = false;
            this.dgWatch.AllowUserToDeleteRows = false;
            this.dgWatch.AllowUserToOrderColumns = true;
            this.dgWatch.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgWatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgWatch.Location = new System.Drawing.Point(3, 53);
            this.dgWatch.MultiSelect = false;
            this.dgWatch.Name = "dgWatch";
            this.dgWatch.ReadOnly = true;
            this.dgWatch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgWatch.Size = new System.Drawing.Size(1030, 394);
            this.dgWatch.TabIndex = 1;
            this.dgWatch.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgWatch_CellFormatting);
            // 
            // btnStopWatch
            // 
            this.btnStopWatch.Location = new System.Drawing.Point(321, 7);
            this.btnStopWatch.Name = "btnStopWatch";
            this.btnStopWatch.Size = new System.Drawing.Size(75, 23);
            this.btnStopWatch.TabIndex = 2;
            this.btnStopWatch.Text = "stop";
            this.btnStopWatch.UseVisualStyleBackColor = true;
            // 
            // WatcherView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 450);
            this.Controls.Add(this.tlpMain);
            this.Name = "WatcherView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Watcher";
            this.tlpMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgWatch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbGroups;
        private System.Windows.Forms.DataGridView dgWatch;
        private System.Windows.Forms.Button btnStartWatch;
        private System.Windows.Forms.Button btnStopWatch;
    }
}