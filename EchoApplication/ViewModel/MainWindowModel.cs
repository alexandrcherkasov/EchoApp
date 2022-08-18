using EchoApplication.Helper;
using EchoApplication.ModalWindow.View;
using EchoApplication.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EchoApplication.ViewModel
{
    class MainWindowModel : ViewModelBase
    {
        public ObservableCollection<Project> ProjectCollection { get; set; } = new();
        public ObservableCollection<ViewModelBase> ViewModelCollection { get; set; } = new();



        private string _SelectedProjectNameText;
        public string SelectedProjectNameText
        {
            get { return _SelectedProjectNameText; }
            set
            {
                _SelectedProjectNameText = value;
                OnPropertyChanged(nameof(SelectedProjectNameText));
            }
        }

        private CreateProjectWindow _CProject;

        private ViewModelBase _CurrentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set
            {
                _CurrentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        private RelayCommand _AddButton;
        public RelayCommand AddButton
        {
            get
            {
                return _AddButton ??= new RelayCommand(obj =>
               {
                   CreateNewProject();
               });
            }
        }

     /*   private RelayCommand _DrawButton;
        public RelayCommand DrawButton
        {
            get
            {
                return _DrawButton ??= new RelayCommand(obj =>
                {
                    if(ViewModelCollection.Count != 2)
                    {
                        CurrentViewModel = new ProjectElementWindowModel();
                        ViewModelCollection.Add(CurrentViewModel);
                    }
                    else
                    {
                        CurrentViewModel = ViewModelCollection[1];
                    }
                    
                });
            }
        }*/

        private RelayCommand _ProjectButton;
        public RelayCommand ProjectButton
        {
            get
            {
                return _ProjectButton ??= new RelayCommand(obj =>
                {
                    CurrentViewModel = ViewModelCollection[0];
                });
            }
        }

        public MainWindowModel()
        {
            CurrentViewModel = new ProjectWindowModel(ProjectCollection);
            CurrentViewModel.PropertyChanged += CurrentViewModel_PropertyChanged;
            SelectedProjectNameText = "Необходимо выбрать проект";
            ViewModelCollection.Add(CurrentViewModel);
            LoadData();
            ((ProjectWindowModel)CurrentViewModel).SetCurrentViewModel(CurrentViewModel);
            ((ProjectWindowModel)CurrentViewModel).SetVieModelCollection(ViewModelCollection);
            DataSaver.ProjectCollectionForSave = ProjectCollection;
        }

        private void LoadData()
        {
            try
            {
                List<Project> ProjectList = JsonConvert.DeserializeObject<List<Project>>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\dataFile.json"));
                foreach(var item in ProjectList)
                {
                    ProjectCollection.Add(item);
                }
            }
            catch (Exception e)
            {

            }
        }

        private void CurrentViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "SelectedProjectItem")
                {
                    if(((ProjectWindowModel)sender).SelectedProjectItem != null)
                    {
                        SelectedProjectNameText = ((ProjectWindowModel)sender).SelectedProjectItem.Name;
                    }
                }
            }
            catch(Exception er) { }
        
        }

        private void CreateNewProject()
        {
            if (_CProject == null)
            {
                _CProject = new();
                _CProject.Owner = Application.Current.MainWindow;
                _CProject.Closing += _CProject_Closing;
                _CProject.Closed += _CProject_Closed;
                _CProject.Show();
            }
        }

        private void _CProject_Closed(object sender, EventArgs e)
        {
            Application.Current.MainWindow.Focus();
        }

        private void _CProject_Closing(object sender, EventArgs e)
        {
            if (_CProject != null)
            {
                if (_CProject.CanCreateNewProject())
                {
                    Project pj = new Project(_CProject.GetName(),_CProject.GetFolder(),_CProject.GetData());
                    ProjectCollection.Add(pj);
                }
                _CProject = null;
            }
        }
    }
}
