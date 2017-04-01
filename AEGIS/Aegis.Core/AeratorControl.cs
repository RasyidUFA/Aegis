using System;
using System.IO.Ports;

namespace AEGIS
{
    internal class AeratorControl : ActivationControl,Controller
    {
        public AeratorControl(SerialPort port, int index) : base(port, index)
        {
        }

        public string Status => throw new NotImplementedException();

        public string Name => "Aeration";
    }
}