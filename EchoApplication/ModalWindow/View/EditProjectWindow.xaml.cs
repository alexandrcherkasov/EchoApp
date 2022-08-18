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
    /// Логика взаимодействия для EditProjectWindow.xaml
    /// </summary>
    public partial class EditProjectWindow : Window
    {
        private EditProjectWindowModel Model;
        public EditProjectWindow(Project SelectedProject)
        {
            InitializeComponent();

            if (Model == null)
            {
                Model = new EditProjectWindowModel(SelectedProject);
                DataContext = Model;
                Model.OnRequestClose += (s, e) => Close();
            }
        }

        public bool CanEditProject()
        {
            return Model.CanEditProject;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
