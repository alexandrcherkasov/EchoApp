using EchoApplication.Helper;
using EchoApplication.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace EchoApplication.ViewModel
{
    class ProjectElementWindowModel : ViewModelBase
    {
        public ObservableCollection<CustomLine> Lines { get; set; } = new ();

        private RelayCommand _AngleButtonPlus;
        public RelayCommand AngleButtonPlus
        {
            get 
            {
                return _AngleButtonPlus = new RelayCommand(obj =>
                {
                    AnglePlus();
                });
            }
        }

        private RelayCommand _AngleButtonMinus;
        public RelayCommand AngleButtonMinus
        {
            get
            {
                return _AngleButtonMinus = new RelayCommand(obj =>
                {
                    AngleMinus();
                });
            }
        }


        private void AnglePlus()
        {
            Lines[0].Degrees++;
            Lines[0].MyLine.GeometryTransform.Value.Rotate(Lines[0].Degrees);
            //Lines[0].MyLine.LayoutTransform.Value.Rotate(Lines[0].Degrees);
        }

        private void AngleMinus()
        {
            Lines[0].Degrees--;
            Lines[0].MyLine.GeometryTransform.Value.Rotate(Lines[0].Degrees);
            //Lines[0].MyLine.LayoutTransform.Value.Rotate(Lines[0].Degrees);
        }


        public ProjectElementWindowModel()
        {
            Lines.Add(new CustomLine(new Line { X1 = 100, Y1 = 100, X2 = 300, Y2 = 100 }));
            Lines.Add(new CustomLine(new Line { X1 = 300, Y1 = 100, X2 = 300, Y2 = 200 }));
            Lines.Add(new CustomLine(new Line { X1 = 300, Y1 = 200, X2 = 100, Y2 = 200 }));
            Lines.Add(new CustomLine(new Line { X1 = 100, Y1 = 200, X2 = 100, Y2 = 100 }));
        }
    }
}
