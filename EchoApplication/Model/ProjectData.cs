using EchoApplication.Helper;
using Newtonsoft.Json;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoApplication.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ProjectData : NotifyProperty
    {
        public ProjectData(int number, DateTime dt, string boreHole, string responseTime)
        {
            _Number = number;
            _DT = dt;
            _BoreHole = boreHole;

            _ResponseTime = SplitResponse(responseTime);
            //_ResponseTime = responseTime;
            _MeasureTime = dt.ToShortTimeString();
            _UniversalGasConstant = 8.314;
            _AdiabaticExponent = 1.36;
            _ConstSpeedOfSound = 322;   
        }

        private void MolarMassCalculation()
        {
            MolarMass = 32 * (Oxygen / 100) + (16 * (Methane / 100)) + (28 * (Azote / 100));
            SpeedOfSoundCalculation();
            DistanceCalulation();
        }

        private string SplitResponse(string responseTime)
        { 
            return string.Join(".", responseTime.Split(","));
        }
        private void SpeedOfSoundCalculation()
        {            
            SpeedOfSound = (Math.Sqrt(AdiabaticExponent * UniversalGasConstant * CalvinTemperature * 1000 / MolarMass)).ToString();
        }
        private void DistanceCalulation()
        {
            if (Double.TryParse(string.Join(",", ResponseTime.Split(".")), out double ResponseRes))
            {
                if(Double.TryParse(SpeedOfSound,out double SpeedRes))
                {
                    Distance = (ResponseRes * SpeedRes).ToString();
                }
            }
        }

        [JsonProperty]
        private double CalvinTemperature;

        [JsonProperty]
        private double MolarMass;

        private int _Number;

        [JsonProperty]
        public int Number
        {
            get { return _Number; }
            set
            {
                _Number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        private string _MeasureTime;

        [JsonProperty]
        public string MeasureTime
        {
            get { return _MeasureTime; }
            set
            {
                _MeasureTime = value;
                OnPropertyChanged(nameof(MeasureTime));
            }
        }

        private DateTime _DT;

        [JsonProperty]
        public DateTime DT
        {
            get { return _DT; }
            set
            {
                _DT = value;
                OnPropertyChanged(nameof(DT));
            }
        }

        private string _BoreHole;

        [JsonProperty]
        public string BoreHole
        {
            get { return _BoreHole; }
            set
            {
                _BoreHole = value;
                OnPropertyChanged(nameof(BoreHole));
            }
        }

        private string _ResponseTime;

        [JsonProperty]
        public string ResponseTime
        {
            get { return _ResponseTime; }
            set
            {
                _ResponseTime = value;
                OnPropertyChanged(nameof(ResponseTime));
            }
        }

        private string _SpeedOfSound;

        [JsonProperty]
        public string SpeedOfSound
        {
            get { return _SpeedOfSound; }
            set
            {
                _SpeedOfSound = value;
                OnPropertyChanged(nameof(SpeedOfSound));
            }
        }

        private double _ConstSpeedOfSound;

        [JsonProperty]
        public double ConstSpeedOfSound
        {
            get { return _ConstSpeedOfSound; }
            set
            {
                _ConstSpeedOfSound = value;
                OnPropertyChanged(nameof(ConstSpeedOfSound));
            }
        }

        private string _Distance;

        [JsonProperty]
        public string Distance
        {
            get { return _Distance; }
            set
            {
                _Distance = value;
                OnPropertyChanged(nameof(Distance));
            }
        }



        private double _AdiabaticExponent;

        [JsonProperty]
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

        [JsonProperty]
        public double UniversalGasConstant
        {
            get { return _UniversalGasConstant; }
            set
            {
                _UniversalGasConstant = value;
                OnPropertyChanged(nameof(UniversalGasConstant));
            }
        }

        private double _Oxygen;

        [JsonProperty]
        public double Oxygen
        {
            get { return _Oxygen; }
            set
            {
                _Oxygen = value;
                MolarMassCalculation();
                OnPropertyChanged(nameof(Oxygen));
            }
        }

        private double _Methane;

        [JsonProperty]
        public double Methane
        {
            get { return _Methane; }
            set
            {
                _Methane = value;
                MolarMassCalculation();
                OnPropertyChanged(nameof(Methane));
            }
        }

        private double _Azote;

        [JsonProperty]
        public double Azote
        {
            get { return _Azote; }
            set
            {
                _Azote = value;
                MolarMassCalculation();
                OnPropertyChanged(nameof(Azote));
            }
        }

        private double _Temperature;


        public double Temperature
        {
            get { return _Temperature; }
            set
            {
                _Temperature = value;
                CalvinTemperature = value + 273;
                OnPropertyChanged(nameof(Temperature));
            }
        }

    }
}
