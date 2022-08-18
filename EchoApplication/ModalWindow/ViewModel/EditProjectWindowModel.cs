using EchoApplication.Helper;
using EchoApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EchoApplication.ModalWindow.ViewModel
{
    public class EditProjectWindowModel : NotifyProperty
    {
        Project SelectedProject;

        public event EventHandler OnRequestClose;

        public bool CanEditProject;

        private List<ProjectData> _ProjectDataList = new();

        public EditProjectWindowModel(Project project)
        {
            SelectedProject = project;
            ProjectNameText = project.Name;
        }
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

        private RelayCommand _BrowseFolderButton;
        public RelayCommand BrowseFolderButton
        {
            get
            {
                return _BrowseFolderButton = new RelayCommand(obj =>
                {
                    GetFilePath();
                });
            }
        }

        private RelayCommand _ChangeButton;
        public RelayCommand ChangeButton
        {
            get
            {
                return _ChangeButton = new RelayCommand(obj =>
                {
                    CanEditProject = true;
                    SelectedProject.Name = ProjectNameText;
                    OnRequestClose(this, new EventArgs());
                });
            }
        }

        private RelayCommand _CloseButton;
        public RelayCommand CloseButton
        {
            get
            {
                return _CloseButton = new RelayCommand(obj =>
                {
                    CanEditProject = false;
                    OnRequestClose(this, new EventArgs());
                });
            }
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
                    ExcelFolder = ofd.FileName;
                    ExcelParser EP = new(ExcelFolder);
                    _ProjectDataList = new(EP.GetDataFromExcelFile());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
