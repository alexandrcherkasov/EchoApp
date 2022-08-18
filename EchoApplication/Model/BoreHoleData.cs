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
    public class BoreHoleData : NotifyProperty
    {

        private CalculationWindow _CWindow;

        private string _BoreHoleName;

        [JsonProperty]
        public string BoreHoleName
        {
            get { return _BoreHoleName; }
            set
            {
                _BoreHoleName = value;
                OnPropertyChanged(nameof(BoreHoleName));
            }
        }

        [JsonProperty]
        public ObservableCollection<ProjectData> ProjectDataCollection { get; set; }

        private ProjectData _SelectedProjectData;
        public ProjectData SelectedProjectData
        {
            get { return _SelectedProjectData; }
            set
            {
                _SelectedProjectData = value;
                OnPropertyChanged(nameof(SelectedProjectData));
            }
        }

        private RelayCommand _EditProjectDataButton;
        public RelayCommand EditProjectDataButton
        {
            get
            {
                return _EditProjectDataButton = new RelayCommand(obj =>
                {
                    if(_CWindow == null)
                    {
                        _CWindow = new CalculationWindow(SelectedProjectData);
                        _CWindow.Owner = Application.Current.MainWindow;
                        _CWindow.Closed += _CWindow_Closed;
                        _CWindow.Show();
                    }
                });
            }
        }

        private void _CWindow_Closed(object sender, EventArgs e)
        {
            if (_CWindow != null)
            {
                _CWindow = null;
            }
        }

        private RelayCommand _DeleteProjectDataButton;
        public RelayCommand DeleteProjectDataButton
        {
            get
            {
                return _DeleteProjectDataButton = new RelayCommand(obj =>
               {
                   ProjectDataCollection.Remove(SelectedProjectData);
               });
            }
        }

        public BoreHoleData(string BoreHoleName,List<ProjectData> ProjectDataList)
        {
            try
            {
                this.BoreHoleName = BoreHoleName;
                ProjectDataCollection = new ObservableCollection<ProjectData>(ProjectDataList);
            }
            catch(Exception e)
            {

            }
            
        }
    }
}
