using EchoApplication.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace EchoApplication.Model
{
    class CustomLine : NotifyProperty
    {
        public  Line MyLine { get; set; }

        private int _Degrees;
        public int Degrees
        {
            get { return _Degrees; }
            set
            {
                _Degrees = value;
                OnPropertyChanged(nameof(Degrees));
            }
        }

        public CustomLine(Line _Line)
        {
            MyLine = _Line;
            Degrees = 0;
        }

        public string GetCoord()
        {
            return "X1: " + MyLine.X1.ToString() + "Y1: " + MyLine.Y1.ToString() + "X2: " + MyLine.X2.ToString() + "Y2: " + MyLine.X2.ToString();
        }
    }
}
