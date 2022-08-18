using EchoApplication.Helper;
using EchoApplication.Interface;
using EchoApplication.ModalWindow.View;
using EchoApplication.ModalWindow.ViewModel;
using EchoApplication.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EchoApplication.ViewModel
{
    class ProjectWindowModel : ViewModelBase
    {
        private EditProjectWindow _EProject;

        public ObservableCollection<Project> ProjectCollection { get; set; }
        public ObservableCollection<ViewModelBase> ViewModelCollection;
        //public ViewModelBase CurrentViewModel;


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

        private Project _SelectedProjectItem;
        public Project SelectedProjectItem
        {
            get { return _SelectedProjectItem; }
            set
            {
                _SelectedProjectItem = value;
                OnPropertyChanged(nameof(SelectedProjectItem));
            }
        }

        private RelayCommand _DeleteProjectButton;
        public RelayCommand DeleteProjectButton
        {
            get
            {
                return _DeleteProjectButton = new RelayCommand(obj =>
                {
                    ProjectCollection.Remove(SelectedProjectItem);
                });
            }
        }

        private RelayCommand _DrawButton;
        public RelayCommand DrawButton
        {
            get
            {
                return _DrawButton ??= new RelayCommand(obj =>
                {
                    Console.WriteLine(CurrentViewModel);
                    if (ViewModelCollection.Count != 2)
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
        }

        private RelayCommand _EditProjectButton;
        public RelayCommand EditProjectButton
        {
            get
            {
                return _EditProjectButton = new RelayCommand(obj =>
                {
                    CreateChangeWindow();
                });
            }
        }

        private RelayCommand _ExportProjectButton;
        public RelayCommand ExportProjectButton
        {
            get
            {
                return _ExportProjectButton = new RelayCommand(obj =>
                {
                    ExcelExport.ExportSelectedProject(SelectedProjectItem);
                });
            }
        }

        private void CreateChangeWindow()
        {
            if (_EProject == null)
            {
                _EProject = new(SelectedProjectItem);
                _EProject.Owner = Application.Current.MainWindow;
                _EProject.Closing += _EProject_Closing;
                _EProject.Closed += _EProject_Closed;
                _EProject.Show();
            }
        }

        private void _EProject_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_EProject != null)
            {
                _EProject = null;
            }
        }

        private void _EProject_Closed(object sender, EventArgs e)
        {
            Application.Current.MainWindow.Focus();
        }

        public void SetVieModelCollection(ObservableCollection<ViewModelBase> ViewModelCollection)
        {
            this.ViewModelCollection = ViewModelCollection;
        }

        public void SetCurrentViewModel(ViewModelBase CurrentViewModel)
        {
            this.CurrentViewModel = CurrentViewModel;
        }

        public ProjectWindowModel(ObservableCollection<Project> ProjectSource)
        {
            ProjectCollection = ProjectSource;
        }
    }
}
