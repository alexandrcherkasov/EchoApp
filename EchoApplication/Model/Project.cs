using EchoApplication.Helper;
using EchoApplication.ModalWindow.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EchoApplication.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Project : NotifyProperty
    {
        [JsonProperty]
        private Guid _Id;

        private EditBoreHoleParamsWindow _EBWindow;

        private Dictionary<string, List<ProjectData>> DictionaryData = new();

        [JsonProperty]
        public ObservableCollection<BoreHoleData> BoreHoleCollection { get; set; } = new();


        private BoreHoleData _SelectedBoreHoleData;
        public BoreHoleData SelectedBoreHoleData
        {
            get { return _SelectedBoreHoleData; }
            set
            {
                _SelectedBoreHoleData = value;
                OnPropertyChanged(nameof(SelectedBoreHoleData));
            }
        }


        private RelayCommand _EditBoreHoleParamsButton;
        public RelayCommand EditBoreHoleParamsButton
        {
            get
            {
                return _EditBoreHoleParamsButton = new RelayCommand(obj =>
                {
                    if (_EBWindow == null)
                    {
                        _EBWindow = new EditBoreHoleParamsWindow(SelectedBoreHoleData);
                        _EBWindow.Owner = Application.Current.MainWindow;
                        _EBWindow.Closed += _EBWindow_Closed;
                        _EBWindow.Show();
                    }
                });
            }

        }

        private RelayCommand _ExportBoreHoleParamsButton;
        public RelayCommand ExportBoreHoleParamsButton
        {
            get
            {
                return _ExportBoreHoleParamsButton = new RelayCommand(obj =>
                {
                    ExcelExport.ExportSelectedBoreHole(SelectedBoreHoleData);
                });
            }
        }

        private void _EBWindow_Closed(object sender, EventArgs e)
        {
            if(_EBWindow != null)
            {
                _EBWindow = null;
            }
        }

    
        private string _Name;

        [JsonProperty]
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _FilePath;
        public string FilePath
        {
            get { return _FilePath; }
            set
            {
                _FilePath = value;
                OnPropertyChanged(nameof(FilePath));
            }
        }

        public Project(string ProjectName,string ProjectPath,List<ProjectData> PD)
        {
            _Id = Guid.NewGuid();
            Name = ProjectName;
            FilePath = ProjectPath;
            InitValue(PD);
            TempInit();
        }

        [JsonConstructor]
        public Project(Guid _Id,ObservableCollection<BoreHoleData> BoreHoleCollection,string Name)
        {
            this._Id = _Id;
            this.BoreHoleCollection = BoreHoleCollection;
            this.Name = Name;
        }

        private void InitValue(List<ProjectData> projectDatas)
        {
            foreach(var item in projectDatas)
            {
                if (!DictionaryData.ContainsKey(item.BoreHole))
                {
                    List<ProjectData> ProjectList = new();
                    ProjectList.Add(item);
                    DictionaryData.Add(item.BoreHole, ProjectList);
                }
                else
                {
                    if(DictionaryData.TryGetValue(item.BoreHole,out List<ProjectData> res))
                    {
                        res.Add(item);
                    }
                }
            }
        }

        private void TempInit()
        {
            foreach(var item in DictionaryData)
            {
                BoreHoleCollection.Add(new(item.Key, item.Value));
            }
        }

    }
}
