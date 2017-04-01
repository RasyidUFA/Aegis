/*
 * Created by SharpDevelop.
 * User: Rasyid
 * Date: 24/03/2017
 * Time: 08.31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO.Ports; 
namespace AEGIS
{
    public class PHControl : DataControl, Controller
    {
        public PHControl(SerialPort port, int index) : base(port, index)
        {
            base.Min = 0;
            base.Max = 14;
            base.Default = 7;
        }

        public string Name => "pH";

        public string Status
        {
            get
            {
                if (Double.IsNaN(Data))
                {
                    if (Data >= 9 && Data <= 14) return "Alcalic Danger";
                    if (Data >= 7.5 && Data < 9) return "Alcalic Warning";
                    if (Data >= 6.5 && Data < 7.5) return "Normal";
                    if (Data >= 4.5 && Data < 6.5) return "Acid Warning";
                    if (Data >= 0 && Data < 4.5) return "Acid Danger";
                }

                return "Unknown";
            }
        }
    }
}
