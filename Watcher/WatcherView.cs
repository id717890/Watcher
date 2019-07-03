using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Watcher.Data;
using Watcher.Interface.Model;
using Watcher.Interface.Presenter;
using Watcher.Interface.View;

namespace Watcher
{
    public partial class WatcherView : Form, IWatcherView
    {
        private Color _colorUndefined = Color.LightGray;
        private Color _colorVerified = Color.LightGreen;
        private Color _colorNotVerified = Color.Red;
        private Color _colorIgnored = Color.BlueViolet;

        public string SelectedGroup { get => cbGroups.Text; set => cbGroups.Text = value; }

        public WatcherView()
        {
            InitializeComponent();
            InitializeColumnsOfGrid();
        }

        public void Attach(IWatcherPresenterCallback callback)
        {
            cbGroups.SelectedIndexChanged += (sender, e) =>
            {
                callback.OnRefreshView();
            };
            btnStartWatch.Click += (sender, e) =>
            {
                callback.OnStarWatch();
                callback.OnCheckOpc();
            };
            btnStopWatch.Click += (sender, e) =>
            {
                callback.OnStopWatch();
            };
        }

        private void InitializeColumnsOfGrid()
        {
            dgWatch.AutoGenerateColumns = false;

            //dgDiagnostic.Columns.Add(new DataGridViewTextBoxColumn
            //{
            //    DataPropertyName = "ServerId"
            //});
            dgWatch.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StatementCaption", Name = "StatementCaption", HeaderText = "Параметр" });
            dgWatch.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Value", Name = "Value", HeaderText = "Статус" });
            dgWatch.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quality", Name = "Quality", HeaderText = "Качество" });
            //dgWatch.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IsVerified", Name = "IsVerified", HeaderText = "IsVerified" });
            //dgWatch.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "VerifyIf", Name = "VerifyIf", HeaderText = "VerifyIf" });
            //dgWatch.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ParamType", Name = "ParamType", HeaderText = "ParamType" });
            //dgWatch.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AllowBadQuality", Name = "AllowBadQuality", HeaderText = "AllowBadQuality" });
            //dgWatch.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Test", Name = "Test", HeaderText = "Test" });

            dgGroupsColor.AutoGenerateColumns = false;
            dgGroupsColor.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GroupCaption", Name = "GroupCaption", HeaderText = "Группа" });
            dgGroupsColor.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IsVerified", Name = "IsVerified", HeaderText = "Статус"});
        }

        public void RenderGrid(BindingList<GridData> model)
        {
            dgWatch.DataSource = model;
            var grouper = new Subro.Controls.DataGridViewGrouper(dgWatch);
            grouper.SetGroupOn<GridData>(t => t.GroupCaption);
            grouper.Options.ShowGroupName = false;
            grouper.DisplayGroup += (sender, e) =>
            {
                e.BackColor = Color.Orange;
            };
        }

        public void RenderGridGroupsColor(BindingList<GroupColorData> model)
        {
            dgGroupsColor.DataSource = model;
        }

        public void SetModel(IWatcherViewModel model)
        {
            if (model.GridDataList != null && model.GridDataList.Any())
            {
                foreach (var group in model.GridDataList.Select(x => x.GroupCaption).Distinct())
                {
                    cbGroups.Items.Add(group);
                }
                cbGroups.Items.Add("Все");
                cbGroups.SelectedIndex = cbGroups.Items.Count - 1;
            }
        }

        private void dgWatch_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var statement = dgWatch.Rows[e.RowIndex].DataBoundItem as GridData;
            if (statement != null)
            {
                if (string.IsNullOrEmpty(statement.Value) && !statement.IsIgnore)
                {
                    dgWatch.Rows[e.RowIndex].DefaultCellStyle.BackColor = _colorUndefined;
                }
                else if ((string.IsNullOrEmpty(statement.Value) && statement.IsIgnore) || (!string.IsNullOrEmpty(statement.Value) && statement.IsIgnore))
                {
                    dgWatch.Rows[e.RowIndex].DefaultCellStyle.BackColor = _colorIgnored;
                }
                else
                {
                    switch (statement.IsVerified)
                    {
                        case true:
                            dgWatch.Rows[e.RowIndex].DefaultCellStyle.BackColor = _colorVerified;
                            break;
                        case false:
                            dgWatch.Rows[e.RowIndex].DefaultCellStyle.BackColor = _colorNotVerified;
                            break;
                    }
                }
            }
        }

        private void dgGroupsColor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var item = dgGroupsColor.Rows[e.RowIndex].DataBoundItem as GroupColorData;
            if (item != null)
            {
                switch (item.IsVerified)
                {
                    case true:
                        dgGroupsColor.Rows[e.RowIndex].DefaultCellStyle.BackColor = _colorVerified;
                        break;
                    case false:
                        dgGroupsColor.Rows[e.RowIndex].DefaultCellStyle.BackColor = _colorNotVerified;
                        break;
                    default:
                        dgGroupsColor.Rows[e.RowIndex].DefaultCellStyle.BackColor = _colorUndefined;
                        break;
                }
            }

        }
    }
}
