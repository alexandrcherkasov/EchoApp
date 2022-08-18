using EchoApplication.Helper;
using EchoApplication.Model;
using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace EchoApplication.ModalWindow.ViewModel
{

    public class CreateProjectWindowModel : NotifyProperty
    {

        public event EventHandler OnRequestClose;

        public bool CanCreateProject;

        private bool _Error;

        private  List<ProjectData> _ProjectDataList = new();

        private string _ProjectNameText;
        public string ProjectNameText
        {
            get { return _ProjectNameText; }
            set
            {
                _ProjectNameText = value;
                OnPropertyChanged(nameof(ProjectNameText));
            }
        }

        private string _ExcelFolder;
        public string ExcelFolder
        {
            get { return _ExcelFolder; }
            set
            {
                _ExcelFolder = value;
                OnPropertyChanged(nameof(ExcelFolder));
            }
        }

        private RelayCommand _AddButton;
        public RelayCommand AddButton => _AddButton ??= new RelayCommand(obj =>
                                                       {

                                                           CanCreateProject = true;
                                                           CanCreateProjectErrorCheck();
                                                           OnRequestClose(this, new EventArgs());
                                                       });
        private RelayCommand closeButton;
        public RelayCommand CloseButton => closeButton ??= new RelayCommand(obj =>
                                                         {
                                                             CanCreateProject = false;
                                                             CanCreateProjectErrorCheck();
                                                             OnRequestClose(this, new EventArgs());
                                                         });

        private RelayCommand _BrowseFolderButton;
        public RelayCommand BrowseFolderButton
        {
            get
            {
                return _BrowseFolderButton ??= new RelayCommand(obj =>
                {
                    GetFilePath();
                });
            }
        }

        private void CanCreateProjectErrorCheck()
        {
            CanCreateProject = _Error ? false : true;
        }

        private void GetFilePath()
        {
            OpenFileDialog ofd = new();
            ofd.Filter = "Text files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            var res = ofd.ShowDialog();
            if (res == DialogResult.OK)
            {
                try
                {
                    ExcelParser EP = new(ofd.FileName);
                    if (EP.GetDataFromExcelFile().Count == 0)
                    {
                        System.Windows.MessageBox.Show("Ошибка при открытии файла или файл пустой");
                        _Error = true;
                    }
                    else
                    {
                        ExcelFolder = ofd.FileName;
                        _ProjectDataList = new(EP.GetDataFromExcelFile());
                    }
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show("Ошибка при открытии файла");
                    _Error = true;
                }
            }
        }

        public List<ProjectData> GetProjectDataList()
        {
            return _ProjectDataList;
        }
    }
}
