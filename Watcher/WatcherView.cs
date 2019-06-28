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
        }

        private void InitializeColumnsOfGrid()
        {
            dgWatch.AutoGenerateColumns = false;

            //dgDiagnostic.Columns.Add(new DataGridViewTextBoxColumn
            //{
            //    DataPropertyName = "ServerId"
            //});
            dgWatch.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ServerCaption", Name = "ServerCaption", HeaderText = "Сервер" });
            dgWatch.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StatementCaption", Name = "StatementCaption", HeaderText = "Параметр" });
            dgWatch.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Value", Name = "Value", HeaderText = "Статус" });
            dgWatch.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quality", Name = "Quality", HeaderText = "Качество" });
            //dgDiagnostic.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IsVerified", Name = "IsVerified", HeaderText = "IsVerified" });
        }

        public void RenderGrid(BindingList<GridData> model)
        {
            //cbGroups.DisplayMember = "GroupCaption";
            
            //if (lbMnaList.Items.Count > 0)
            //{
            //    lbMnaList.SelectedIndex = 0;
            //    RenderParametersGrid();
            //}


            //var list = model.GridDataList;

            //if (model.VerificationList != null && model.VerificationList.Any())
            //{
            //    foreach (var vServer in model.VerificationList.OrderBy(x => x.Order))
            //    {
            //        if (vServer.ServiceStatements != null && vServer.ServiceStatements.Any())
            //        {
            //            foreach (var statement in vServer.ServiceStatements)
            //            {
            //                list.Add(new TestData
            //                {
            //                    Server = vServer.Caption,
            //                    Caption = statement.Caption,
            //                    Status = statement.Value
            //                });
            //            }
            //        }

            //        if (vServer.OpcStatements != null && vServer.OpcStatements.Any())
            //        {
            //            foreach (var statement in vServer.OpcStatements)
            //            {
            //                list.Add(new TestData
            //                {
            //                    Server = vServer.Caption,
            //                    Caption = statement.Caption,
            //                    Status = statement.Value,
            //                    Quality = statement.Quality
            //                });
            //            }
            //        }
            //    }
            //}

            dgWatch.DataSource = model;
            var grouper = new Subro.Controls.DataGridViewGrouper(dgWatch);
            grouper.SetGroupOn<GridData>(t => t.GroupCaption);
            grouper.Options.ShowGroupName = false;
            grouper.DisplayGroup += (sender, e) =>
            {
                e.BackColor = Color.Orange;
                //e.BackColor = (e.Group.GroupIndex % 2) == 0 ? Color.Orange : Color.LightBlue;
                //e.Header = "[" + e.Header + "], grp: " + e.Group.GroupIndex;
                //e.DisplayValue = "Value is " + e.DisplayValue;
                //e.Summary = "contains " + e.Group.Count + " rows";
            };
            //grouper.SetGroupOn("TypeProperty");
            //if (dgDiagnostic.CurrentCell != null)
            //{
            //    _selectedRow = dgDiagnostic.CurrentCell.RowIndex;
            //}

            //if (model.VerificationList != null && model.VerificationList.Any())
            //{
            //    dgDiagnostic.Rows.Clear();
            //    var rowNum = 1;
            //    foreach (var vServer in model.VerificationList.OrderBy(x => x.Order))
            //    {
            //        //RenderServerHeader(vServer, rowNum);
            //        //rowNum++;

            //        if (vServer.ServiceStatements != null && vServer.ServiceStatements.Any())
            //        {
            //            foreach (var statement in vServer.ServiceStatements)
            //            {
            //                RenderServerStatement(statement, rowNum);
            //                rowNum++;
            //            }
            //        }

            //        if (vServer.OpcStatements != null && vServer.OpcStatements.Any())
            //        {
            //            foreach (var statement in vServer.OpcStatements)
            //            {
            //                RenderServerStatement(statement, rowNum);
            //                rowNum++;
            //            }
            //        }
            //    }
            //}

            //if (dgDiagnostic.Rows.Count > 0)
            //{
            //    dgDiagnostic.Rows[_selectedRow].Selected = true;
            //    dgDiagnostic.CurrentCell = dgDiagnostic.Rows[_selectedRow].Cells[0];
            //}
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
    }
}
