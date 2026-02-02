using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Nmea2000Viewer
{
    public class N2kData : INotifyPropertyChanged
    {
        private double? _latitude;
        private double? _longitude;
        private double? _sog;
        private double? _cog;
        private double? _yaw;
        private double? _pitch;
        private double? _roll;
        private string _statusMessage;

        public double? Latitude
        {
            get => _latitude;
            set { _latitude = value; OnPropertyChanged(); }
        }

        public double? Longitude
        {
            get => _longitude;
            set { _longitude = value; OnPropertyChanged(); }
        }

        public double? SOG
        {
            get => _sog;
            set { _sog = value; OnPropertyChanged(); }
        }

        public double? COG
        {
            get => _cog;
            set { _cog = value; OnPropertyChanged(); }
        }

        public double? Yaw
        {
            get => _yaw;
            set { _yaw = value; OnPropertyChanged(); }
        }

        public double? Pitch
        {
            get => _pitch;
            set { _pitch = value; OnPropertyChanged(); }
        }

        public double? Roll
        {
            get => _roll;
            set { _roll = value; OnPropertyChanged(); }
        }

        private double? _heading;
        public double? Heading
        {
            get => _heading;
            set { _heading = value; OnPropertyChanged(); }
        }

        private double? _deviation;
        public double? Deviation
        {
            get => _deviation;
            set { _deviation = value; OnPropertyChanged(); }
        }

        private double? _variation;
        public double? Variation
        {
            get => _variation;
            set { _variation = value; OnPropertyChanged(); }
        }

        private ObservableCollection<SatelliteInfo> _satellites = new ObservableCollection<SatelliteInfo>();
        public ObservableCollection<SatelliteInfo> Satellites
        {
            get => _satellites;
            set { _satellites = value; OnPropertyChanged(); }
        }

        private int _countPGN129029;
        public int CountPGN129029
        {
            get => _countPGN129029;
            set { _countPGN129029 = value; OnPropertyChanged(); }
        }

        private int _countPGN129026;
        public int CountPGN129026
        {
            get => _countPGN129026;
            set { _countPGN129026 = value; OnPropertyChanged(); }
        }

        private int _countPGN127257;
        public int CountPGN127257
        {
            get => _countPGN127257;
            set { _countPGN127257 = value; OnPropertyChanged(); }
        }

        private int _countPGN127250;
        public int CountPGN127250
        {
            get => _countPGN127250;
            set { _countPGN127250 = value; OnPropertyChanged(); }
        }

        private int _countPGN129540;
        public int CountPGN129540
        {
            get => _countPGN129540;
            set { _countPGN129540 = value; OnPropertyChanged(); }
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class SatelliteInfo
    {
        public int PRN { get; set; }
        public double Elevation { get; set; } // degrees
        public double Azimuth { get; set; }   // degrees
        public double SNR { get; set; }       // dB
    }
}
