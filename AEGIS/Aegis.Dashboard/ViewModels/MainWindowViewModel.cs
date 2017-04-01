using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AEGIS
{
    class MainWindowViewModel
    {

        public ICommand CloseWindowsCommand => new ACommand(ExitSafe);
        private double m_pH;
        private double m_temp;
        private double m_do;
        private double m_humidity;
        private double m_airtemp;
        private double m_waterlevel;
        private double m_Turbidity;
        private double m_salinity;

        private string m_status;

        public string DataStatus
        {
            get => string.IsNullOrEmpty(m_status) ? m_status : "Everything's okay"; 
            set { m_status = value; }
        }



        public double DataSalinity
        {
            get => double.IsNaN(m_salinity) ? m_salinity : 2.0d; 
            set { m_salinity = value; }
        }


        public double DataTurbidity
        {
            get => double.IsNaN(m_Turbidity) ? m_Turbidity : 5.0d; 
            set { m_Turbidity = value; }
        }



        public double DataWaterLevel
        {
            get => double.IsNaN(m_waterlevel) ? m_waterlevel : 3.0d; 
            set { m_waterlevel = value; }
        }


        public double DataTempAir
        {
            get => double.IsNaN(m_airtemp) ? m_airtemp : 27.0d;
            set { m_airtemp = value; }
        }

        public double DataHumidity
        {
            get => double.IsNaN(m_humidity) ? m_humidity : 23.0d; 
            set { m_humidity = value; }
        }


        public double DataDO
        {
            get => double.IsNaN(m_do) ? m_do : 1.0d;
            set => m_do = value;
        }

        public double DataTempWater
        {
            get => double.IsNaN(m_temp) ? m_temp : 26.0d; 
            set { m_temp = value; }
        }

        public double DatapH
        {
            get => double.IsNaN(m_pH) ? m_pH : 7.0d; 
            set { m_pH = value; }
        }


        private void ExitSafe(object o)
        {
            App.Current.Shutdown(0);
        }
        public MainWindowViewModel()
        {
               
        }
    }
}
