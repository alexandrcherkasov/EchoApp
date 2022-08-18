using EchoApplication.ModalWindow.ViewModel;
using EchoApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для CalculationWindow.xaml
    /// </summary>
    public partial class CalculationWindow : Window
    {
        public CalculationWindow(ProjectData projectData)
        {
            InitializeComponent();
            this.DataContext = new CalculationWindowModel(projectData);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
