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
                    AllowBadQuality = false,
                    IsIgnore = false,
                    IsVerified = false,
                    ParamType = null,
                    Quality = null,
                    Value = null,
                    VerifyIf = null
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
                    var files = Directory.GetFiles(directory, "*" + Configs.GroupListFilePrefix +".txt");
                    if (files.Any())
                    {
                        string line;
                        foreach (var file in files)
                        {
                            var groupName = file.Replace(directory + "\\", "").Replace(Configs.GroupListFilePrefix+".txt", "");
                            var fileBody = new StreamReader(file);
                            while((line = fileBody.ReadLine()) !=null)
                            {
                                var data = SeparateLine(line);
                                if (data !=null)
                                {
                                    data.GroupCaption = groupName;
                                    modelGrid.Add(data);
                                }
                            }
                            fileBody.Close();
                        }
                    } else MessageBox.Show("Папка '" + Configs.GroupListFolder + "' не содержит ни одного файла конфигурации", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //if (File.Exists(Configs.AppFolder + "\\configs\\" + Configs.ConfigFileName))
                    //{
                    //    var xdoc = XDocument.Load(Configs.AppFolder + "\\configs\\" + Configs.ConfigFileName);
                    //    var diagnosticRoot = xdoc.Element("diagnostic");
                    //    if (diagnosticRoot != null)
                    //    {
                    //        var serverList = diagnosticRoot.Elements("server");
                    //        if (serverList != null && serverList.Any())
                    //        {
                    //            foreach (var server in serverList)
                    //            {
                    //                if (server != null)
                    //                {
                    //                    XAttribute captionServer = server.Attribute("caption");
                    //                    XAttribute connectionStringServer = server.Attribute("connection");
                    //                    XAttribute orderServer = server.Attribute("order");
                    //                    XAttribute hostName = server.Attribute("hostname");
                    //                    XAttribute user = server.Attribute("user");
                    //                    XAttribute password = server.Attribute("password");
                    //                    XAttribute domain = server.Attribute("domain");
                    //                    if ((captionServer != null) && (connectionStringServer != null) && (orderServer != null))
                    //                    {
                    //                        var serverItem = new Server
                    //                        {
                    //                            Id = Guid.NewGuid(),
                    //                            Connectionstring = connectionStringServer.Value,
                    //                            Caption = captionServer.Value,
                    //                            HostName = hostName != null ? hostName.Value : null,
                    //                            User = user != null ? user.Value : null,
                    //                            Password = password != null ? password.Value : null,
                    //                            Domain = domain != null ? domain.Value : null,
                    //                            Order = int.TryParse(orderServer.Value, out var order) ? order : 0,
                    //                        };

                    //                        #region Parse <tag>
                    //                        var tagsList = server.Elements("tag");
                    //                        if (tagsList != null && tagsList.Any())
                    //                        {
                    //                            //var tagListItems = new List<OpcStatement>();
                    //                            foreach (var statement in tagsList)
                    //                            {
                    //                                var statementCaption = statement.Attribute("caption");
                    //                                var statementType = statement.Attribute("type");
                    //                                var statementVerifyIf = statement.Attribute("verifyif");
                    //                                var allowQualityBad = statement.Attribute("allowbad");
                    //                                var module = statement.Attribute("module");

                    //                                var statementTag = statement.Value;

                    //                                if (!string.IsNullOrEmpty(statementTag) && statementCaption != null && statementType != null && statementVerifyIf != null)
                    //                                {
                    //                                    var statementItem = new OpcStatement
                    //                                    {
                    //                                        Caption = statementCaption.Value,
                    //                                        TagValue = statementTag,
                    //                                        IsModule = module != null ? true : false,
                    //                                        Id = Guid.NewGuid()
                    //                                    };
                    //                                    if (allowQualityBad != null)
                    //                                    {
                    //                                        if (Boolean.TryParse(allowQualityBad.Value, out bool result))
                    //                                            statementItem.AllowBadQuality = result;
                    //                                        else statementItem.AllowBadQuality = false;
                    //                                    }
                    //                                    else statementItem.AllowBadQuality = false;

                    //                                    switch (statementType.Value)
                    //                                    {
                    //                                        case "bool":
                    //                                            {
                    //                                                statementItem.ParamType = "bool";
                    //                                                statementItem.VerifyIf = Convert.ToBoolean(statementVerifyIf.Value);
                    //                                                break;
                    //                                            }
                    //                                        case "int":
                    //                                            {
                    //                                                statementItem.ParamType = "int";
                    //                                                statementItem.VerifyIf = Convert.ToInt32(statementVerifyIf.Value);
                    //                                                break;
                    //                                            }
                    //                                        default:
                    //                                            {
                    //                                                statementItem.ParamType = "int";
                    //                                                statementItem.VerifyIf = (int)statementVerifyIf;
                    //                                                break;
                    //                                            }
                    //                                    }

                    //                                    modelGrid.Add(new GridData
                    //                                    {
                    //                                        ServerId = serverItem.Id,
                    //                                        Connectionstring = serverItem.Connectionstring,
                    //                                        ServerCaption = serverItem.Caption,
                    //                                        HostName = serverItem.HostName,
                    //                                        User = serverItem.User,
                    //                                        Password = serverItem.Password,
                    //                                        Domain = serverItem.Domain,
                    //                                        Order = serverItem.Order,

                    //                                        StatementId = statementItem.Id,
                    //                                        AllowBadQuality = statementItem.AllowBadQuality,
                    //                                        IsVerified = statementItem.IsVerified,
                    //                                        ParamType = statementItem.ParamType,
                    //                                        StatementCaption = statementItem.Caption,
                    //                                        TagValue = statementItem.TagValue,
                    //                                        VerifyIf = statementItem.VerifyIf,
                    //                                        Quality = statementItem.Quality,
                    //                                        ParameterStatement = ParameterStatement.OpcTag,
                    //                                        IsModule = statementItem.IsModule
                    //                                    });
                    //                                }
                    //                            }
                    //                        }
                    //                        #endregion

                    //                        #region Parse <service>
                    //                        var servicesList = server.Elements("service");
                    //                        if (servicesList != null && servicesList.Any())
                    //                        {
                    //                            var serviceListItems = new List<ServiceStatement>();
                    //                            foreach (var service in servicesList)
                    //                            {
                    //                                var serviceCaption = service.Attribute("caption");
                    //                                var serviceVerifyIf = service.Attribute("verifyif");
                    //                                var serviceName = service.Value;

                    //                                if (!string.IsNullOrEmpty(serviceName) && serviceCaption != null && serviceVerifyIf != null)
                    //                                {
                    //                                    var serviceItem = new ServiceStatement
                    //                                    {
                    //                                        Id = Guid.NewGuid(),
                    //                                        Caption = serviceCaption.Value,
                    //                                        VerifyIf = serviceVerifyIf.Value,
                    //                                        TagValue = serviceName
                    //                                    };
                    //                                    modelGrid.Add(new GridData
                    //                                    {
                    //                                        ServerId = serverItem.Id,
                    //                                        Connectionstring = serverItem.Connectionstring,
                    //                                        ServerCaption = serverItem.Caption,
                    //                                        HostName = serverItem.HostName,
                    //                                        User = serverItem.User,
                    //                                        Password = serverItem.Password,
                    //                                        Domain = serverItem.Domain,
                    //                                        Order = serverItem.Order,

                    //                                        StatementId = serviceItem.Id,
                    //                                        IsVerified = serviceItem.IsVerified,
                    //                                        StatementCaption = serviceItem.Caption,
                    //                                        TagValue = serviceItem.TagValue,
                    //                                        VerifyIf = serviceItem.VerifyIf,
                    //                                        ParameterStatement = ParameterStatement.Service
                    //                                    });
                    //                                }
                    //                            }
                    //                            serverItem.ServiceStatements = serviceListItems;
                    //                        }
                    //                        #endregion
                    //                        //model.Add(serverItem);
                    //                    }
                    //                }
                    //            }
                    //        }
                    //        else MessageBox.Show("Список серверов для диагностики пуст", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    }
                    //    else MessageBox.Show("Корневой элемент 'diagnostic' не обнаружен", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //}
                    //else MessageBox.Show(string.Format("Файл конфигурации '{0}' не обнаружена в дериктории configs", Configs.ConfigFileName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Папка '" + Configs.GroupListFolder +"' не обнаружена в текущей дериктории", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _model.GridDataList = modelGrid;
                _view.SetModel(_model);
                OnRefreshView();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OnRefreshView()
        {
            var data = _model.GridDataList.Where(x => x.GroupCaption == _view.SelectedGroup).ToList();
            if (data.Any()) _view.RenderGrid(new BindingList<GridData>(data)); else _view.RenderGrid(_model.GridDataList);
        }
    }
}
