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
    /// Логика взаимодействия для EditBoreHoleParamsWindow.xaml
    /// </summary>
    public partial class EditBoreHoleParamsWindow : Window
    {
        private EditBoreHoleParamsWindowModel Model;
        public EditBoreHoleParamsWindow(BoreHoleData SelectedBoreHoleData)
        {
            InitializeComponent();
            Model = new EditBoreHoleParamsWindowModel(SelectedBoreHoleData);
            this.DataContext = Model;
            Model.OnRequestClose += (s, e) => Close();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
