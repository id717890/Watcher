using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Watcher.Data;
using Watcher.Infrastructure;
using Watcher.Interface.Model;
using Watcher.Interface.Presenter;
using Watcher.Interface.View;

namespace Watcher
{
    public class WatcherPresenter : IWatcherPresenter, IWatcherPresenterCallback
    {
        private readonly IWatcherView _view;
        private readonly IWatcherViewModel _model;
        private bool _isWatching;
        private IDictionary<Guid, Opc.Da.Server> _opcServers;

        private string[] _badQualityVariants = Configs.BadQualityVariants();
        private string[] _goodQualityVariants = Configs.GoodQualityVariants();

        public WatcherPresenter(IWatcherView view, IWatcherViewModel model)
        {
            _view = view;
            _model = model;
        }


        public object Ui => _view;

        public void Initialize()
        {
            _view.Attach(this);
            ReadFiles();
        }

        private GridData SeparateLine(string str)
        {
            var separated = str.Split(';');
            try
            {
                return new GridData()
                {
                    Id = Guid.NewGuid(),
                    Tag = separated[0],
                    StatementCaption = separated[1],
                    ParamType = separated[2],
                    AllowBadQuality = bool.Parse(separated[3]),
                    VerifyIf = Convert.ToBoolean(separated[4]),
                    IsIgnore = false,
                    IsVerified = false,
                    Quality = null,
                    Value = null
                };
            }
            catch
            {
                return null;
            }
        }

        private void ReadFiles()
        {
            try
            {
                var modelGrid = new BindingList<GridData>();
                var directory = Configs.AppFolder + "\\" + Configs.GroupListFolder;
                if (Directory.Exists(directory))
                {
                    var files = Directory.GetFiles(directory, "*" + Configs.GroupListFilePrefix + ".txt");
                    if (files.Any())
                    {
                        string line;
                        foreach (var file in files)
                        {
                            var groupName = file.Replace(directory + "\\", "").Replace(Configs.GroupListFilePrefix + ".txt", "");
                            var fileBody = new StreamReader(file);
                            while ((line = fileBody.ReadLine()) != null)
                            {
                                var data = SeparateLine(line);
                                if (data != null)
                                {
                                    data.GroupCaption = groupName;
                                    modelGrid.Add(data);
                                }
                            }
                            fileBody.Close();
                        }
                    }
                    else MessageBox.Show("Папка '" + Configs.GroupListFolder + "' не содержит ни одного файла конфигурации", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Папка '" + Configs.GroupListFolder + "' не обнаружена в текущей дериктории", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _model.GridDataList = modelGrid;
                _view.SetModel(_model);
                OnRefreshView();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OnCheckOpc()
        {
            _opcServers = new Dictionary<Guid, Opc.Da.Server>();
                
            // 1st: Create a server object and connect to the RSLinx OPC Server
            //var url = new Opc.URL("opcda://10.85.5.111/Infinity.OPCServer");
            var url = new Opc.URL(Configs.OpcConnectionString);
            var fact = new OpcCom.Factory();
            var opcServer = new Opc.Da.Server(fact, null);

            //2nd: Connect to the created server
            try
            {
                try
                {
                    opcServer.Connect(url, new Opc.ConnectData(new System.Net.NetworkCredential()));

                    var id = Guid.NewGuid();
                    _opcServers.Add(id, opcServer);

                    var tags = _model.GridDataList.Distinct();
                    if (tags != null && tags.Any())
                    {
                        //3rd Create a group if items            
                        var groupState = new Opc.Da.SubscriptionState();
                        groupState.Name = "Group of " + id;
                        groupState.UpdateRate = 1000;// this isthe time between every reads from OPC server
                        groupState.Active = true;//this must be true if you the group has to read value
                        var groupRead = (Opc.Da.Subscription)opcServer.CreateSubscription(groupState);
                        groupRead.DataChanged += new Opc.Da.DataChangedEventHandler(TagValue_DataChanged);//callback when the data are readed
                        var items = new List<Opc.Da.Item>();

                        foreach (var tagItem in tags)
                        {
                            items.Add(new Opc.Da.Item
                            {
                                ItemName = tagItem.Tag,
                                ClientHandle = id
                            });
                        }
                        groupRead.AddItems(items.ToArray());
                    }
                }
                catch
                {
                    MessageBox.Show("Сервер " + url + " недостпуен.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка при чтении тега OPC с сервера " + url + ". " + e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //VerifyAllStatements();





            //// 1st: Create a server object and connect to the RSLinx OPC Server
            ////var url = new Opc.URL("opcda://10.85.5.111/Infinity.OPCServer");
            //var url = new Opc.URL(Configs.OpcConnectionString);
            //var fact = new OpcCom.Factory();
            //var opcServer = new Opc.Da.Server(fact, null);

            ////2nd: Connect to the created server
            //try
            //{
            //    try
            //    {
            //        opcServer.Connect(url, new Opc.ConnectData(new System.Net.NetworkCredential()));
            //        var tags = _model.GridDataList.Distinct();
            //        if (tags != null && tags.Any())
            //        {
            //            //3rd Create a group if items            
            //            var groupState = new Opc.Da.SubscriptionState();
            //            groupState.Name = "Group of OPC";
            //            groupState.UpdateRate = 1000;// this isthe time between every reads from OPC server
            //            groupState.Active = true;//this must be true if you the group has to read value
            //            var groupRead = (Opc.Da.Subscription)opcServer.CreateSubscription(groupState);
            //            groupRead.DataChanged += new Opc.Da.DataChangedEventHandler(TagValue_DataChanged);//callback when the data are readed
            //            var items = new List<Opc.Da.Item>();

            //            foreach (var tagItem in tags)
            //            {
            //                items.Add(new Opc.Da.Item
            //                {
            //                    ItemName = tagItem.Tag,
            //                    ClientHandle = Guid.NewGuid()
            //                });
            //            }
            //            groupRead.AddItems(items.ToArray());
            //        }
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Сервер " + url + " недостпуен.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("Ошибка при чтении тега OPC с сервера " + url + ". " + e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            ////VerifyAllStatements();
        }

        private void TagValue_DataChanged(object subscriptionHandle, object requestHandle, Opc.Da.ItemValueResult[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                var tagGrid = _model.GridDataList.SingleOrDefault(x => x.Tag == values[i].ItemName);
                if (tagGrid != null)
                {
                    tagGrid.Value = values[i].Value.ToString();
                    tagGrid.Quality = values[i].Quality.ToString();
                }
            }
            VerifyAllStatements();
        }

        public void OnRefreshView()
        {
            var data = _model.GridDataList.Where(x => x.GroupCaption == _view.SelectedGroup).ToList();
            if (data.Any()) _view.RenderGrid(new BindingList<GridData>(data)); else _view.RenderGrid(_model.GridDataList);
        }

        private void DisconnectOpcServers()
        {
            if (_opcServers != null && _opcServers.Any()) foreach (var server in _opcServers.Where(x => x.Value.IsConnected)) server.Value.Disconnect();
        }

        private void SetModelNotVerified()
        {
            if (_model != null && _model.GridDataList != null)
                foreach (var statement in _model.GridDataList)
                {
                    statement.Quality = string.Empty;
                    statement.Value = null;
                    statement.IsVerified = false;
                }
        }

        public void OnStarWatch()
        {
            _isWatching = true;
        }

        public void OnStopWatch()
        {
            DisconnectOpcServers();
            SetModelNotVerified();
            _isWatching = false;
        }

        public void VerifyAllStatements()
        {
            if (_isWatching)
            {
                if (_model.GridDataList != null && _model.GridDataList.Any())
                {
                    foreach (var tag in _model.GridDataList)
                    {
                        if (!tag.AllowBadQuality && _badQualityVariants.Contains(tag.Quality.ToLower()))
                        {
                            tag.IsVerified = false;
                            tag.Test = "1";
                        }
                        else if (tag.AllowBadQuality && _badQualityVariants.Contains(tag.Quality.ToLower()))
                        {
                            tag.IsVerified = true;
                            tag.Test = "2";
                        }
                        else if ((tag.AllowBadQuality && _goodQualityVariants.Contains(tag.Quality.ToLower()))
                            || (!tag.AllowBadQuality && _goodQualityVariants.Contains(tag.Quality.ToLower())))
                        {
                            switch (tag.ParamType)
                            {
                                case "bool":
                                    {
                                        try
                                        {
                                            tag.Test = "3";
                                            var value = bool.Parse(tag.Value);
                                            tag.IsVerified = value == (bool)tag.VerifyIf;
                                            tag.Test = "33";
                                        }
                                        catch (Exception e) { tag.Test = e.Message; }
                                        break;
                                    }
                                default:
                                    tag.IsVerified = false;
                                    tag.Test = "4";
                                    break;
                            }
                        }
                        else
                        {
                            tag.IsVerified = false;
                            tag.Test = "5";
                        }
                    }
                }
            }
        }
    }
}
