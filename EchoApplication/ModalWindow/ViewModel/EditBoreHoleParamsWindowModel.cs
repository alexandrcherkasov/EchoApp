using EchoApplication.Helper;
using EchoApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoApplication.ModalWindow.ViewModel
{
    class EditBoreHoleParamsWindowModel : NotifyProperty
    {

        public event EventHandler OnRequestClose;

        private BoreHoleData _BoreHoleData;

        public EditBoreHoleParamsWindowModel(BoreHoleData SelectedBoreHoleData)
        {
            _BoreHoleData = SelectedBoreHoleData;
            _UniversalGasConstant = 8.314;
            _AdiabaticExponent = 1.36;
        }
        private double _AdiabaticExponent;
        public double AdiabaticExponent
        {
            get { return _AdiabaticExponent; }
            set
            {
                _AdiabaticExponent = value;
                OnPropertyChanged(nameof(AdiabaticExponent));
            }
        }

        private double _UniversalGasConstant;
        public double UniversalGasConstant
        {
            get { return _UniversalGasConstant; }
            set
            {
                _UniversalGasConstant = value;
                OnPropertyChanged(nameof(UniversalGasConstant));
            }
        }

        private double _Temperature;
        public double Temperature
        {
            get { return _Temperature; }
            set
            {
                _Temperature = value;
                OnPropertyChanged(nameof(Temperature));
            }
        }

        private double _Oxygen;
        public double Oxygen
        {
            get { return _Oxygen; }
            set
            {
                _Oxygen = value;
                OnPropertyChanged(nameof(Oxygen));
            }
        }

        private double _Methane;
        public double Methane
        {
            get { return _Methane; }
            set
            {
                _Methane = value;
                OnPropertyChanged(nameof(Methane));
            }
        }

        private double _Azote;
        public double Azote
        {
            get { return _Azote; }
            set
            {
                _Azote = value;
                OnPropertyChanged(nameof(Azote));
            }
        }

        private RelayCommand _ConfirmButton;
        public RelayCommand ConfirmButton
        {
            get 
            {
                return _ConfirmButton = new RelayCommand(obj =>
                {
                    ConfirmData();
                });
            }
        }

        private void ConfirmData()
        {
            foreach(var item in _BoreHoleData.ProjectDataCollection)
            {
                item.AdiabaticExponent = AdiabaticExponent;
                item.UniversalGasConstant = UniversalGasConstant;
                item.Temperature = Temperature;
                item.Oxygen = Oxygen;
                item.Methane = Methane;
                item.Azote = Azote;
                OnRequestClose(this, new EventArgs());
            }
        }



    }
}
