using EchoApplication.ModalWindow.ViewModel;
using EchoApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EchoApplication.ModalWindow.View
{
    /// <summary>
    /// Логика взаимодействия для CreateProjectWindow.xaml
    /// </summary>
    public partial class CreateProjectWindow : Window
    {
        private CreateProjectWindowModel Model;
        public CreateProjectWindow()
        {
            InitializeComponent();
            if (Model == null)
            {
                Model = new CreateProjectWindowModel();
                DataContext = Model;
                Model.OnRequestClose += (s, e) => Close();
            }
        }

        public bool CanCreateNewProject()
        {
            return Model.CanCreateProject;
        }

        public List<ProjectData> GetData()
        {
            return Model.GetProjectDataList();
        }
        public string GetFolder()
        {
            return Model.ExcelFolder;
        }
        public string GetName()
        {
            return Model.ProjectNameText;
        }
    }
}
