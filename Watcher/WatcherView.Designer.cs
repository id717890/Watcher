﻿namespace Watcher
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
            this.components = new System.ComponentModel.Container();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStopWatch = new System.Windows.Forms.Button();
            this.btnStartWatch = new System.Windows.Forms.Button();
            this.cbGroups = new System.Windows.Forms.ComboBox();
            this.dgWatch = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgGroupsColor = new System.Windows.Forms.DataGridView();
            this.cmWatcher = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmStartIgnore = new System.Windows.Forms.ToolStripMenuItem();
            this.cmEndIgnore = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWatch)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGroupsColor)).BeginInit();
            this.cmWatcher.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpMain.Controls.Add(this.panel1, 0, 0);
            this.tlpMain.Controls.Add(this.dgWatch, 0, 1);
            this.tlpMain.Controls.Add(this.panel2, 1, 1);
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
            this.panel1.Size = new System.Drawing.Size(667, 44);
            this.panel1.TabIndex = 0;
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
            this.dgWatch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgWatch.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgWatch.ContextMenuStrip = this.cmWatcher;
            this.dgWatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgWatch.Location = new System.Drawing.Point(3, 53);
            this.dgWatch.MultiSelect = false;
            this.dgWatch.Name = "dgWatch";
            this.dgWatch.ReadOnly = true;
            this.dgWatch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgWatch.Size = new System.Drawing.Size(667, 394);
            this.dgWatch.TabIndex = 1;
            this.dgWatch.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgWatch_CellFormatting);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgGroupsColor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(676, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(357, 394);
            this.panel2.TabIndex = 4;
            // 
            // dgGroupsColor
            // 
            this.dgGroupsColor.AllowUserToAddRows = false;
            this.dgGroupsColor.AllowUserToDeleteRows = false;
            this.dgGroupsColor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgGroupsColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGroupsColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgGroupsColor.Location = new System.Drawing.Point(0, 0);
            this.dgGroupsColor.Name = "dgGroupsColor";
            this.dgGroupsColor.ReadOnly = true;
            this.dgGroupsColor.Size = new System.Drawing.Size(357, 394);
            this.dgGroupsColor.TabIndex = 4;
            this.dgGroupsColor.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgGroupsColor_CellFormatting);
            // 
            // cmWatcher
            // 
            this.cmWatcher.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmStartIgnore,
            this.cmEndIgnore});
            this.cmWatcher.Name = "cmWatcher";
            this.cmWatcher.Size = new System.Drawing.Size(170, 48);
            // 
            // cmStartIgnore
            // 
            this.cmStartIgnore.Name = "cmStartIgnore";
            this.cmStartIgnore.Size = new System.Drawing.Size(169, 22);
            this.cmStartIgnore.Text = "Cнять с контроля";
            // 
            // cmEndIgnore
            // 
            this.cmEndIgnore.Name = "cmEndIgnore";
            this.cmEndIgnore.Size = new System.Drawing.Size(169, 22);
            this.cmEndIgnore.Text = "Взять на контроль";
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
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tlpMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgWatch)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgGroupsColor)).EndInit();
            this.cmWatcher.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbGroups;
        private System.Windows.Forms.DataGridView dgWatch;
        private System.Windows.Forms.Button btnStartWatch;
        private System.Windows.Forms.Button btnStopWatch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgGroupsColor;
        private System.Windows.Forms.ContextMenuStrip cmWatcher;
        private System.Windows.Forms.ToolStripMenuItem cmStartIgnore;
        private System.Windows.Forms.ToolStripMenuItem cmEndIgnore;
    }
}