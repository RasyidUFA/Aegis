using System;
using System.IO.Ports;

namespace AEGIS
{
    internal class TempControl : DataControl, Controller
    {
        public TempControl(SerialPort port, int index) : base(port, index)
        {
            base.Min = 10;
            base.Max = 40;
            base.Default = 29;
        }

        public string Name => "Temperature Control";

        public string Status
        {
            get
            {
                if (Double.IsNaN(Data))
                {
                    if (Data >= 32 && Data <= 40) return "Overheat Danger";
                    if (Data >= 29 && Data < 32) return "Overheat Warning";
                    if (Data >= 24 && Data < 29) return "Normal";
                    if (Data >= 19 && Data < 24) return "Lowheat Warning";
                    if (Data >= 0 && Data < 19) return "Lowheat Danger";
                }

                return "Unknown";
            }
        }
    }
}