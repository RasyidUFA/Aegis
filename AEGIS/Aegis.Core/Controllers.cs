/*
 * Created by SharpDevelop.
 * User: Rasyid
 * Date: 24/03/2017
 * Time: 08.02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
namespace AEGIS
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public sealed class Controllers
	{
		List<SerialPort> PortConnection = new List<SerialPort>();
		List<Control> Items = new List<Control>();
		void EstabilishConnection(string COM){
			using (var myPort = new SerialPort(COM, 9600, Parity.None, 9, StopBits.One) {
				Encoding = Encoding.ASCII,
				DtrEnable = true
			}) {
				try {
					myPort.Open();
					PortConnection.Add(myPort);
				} catch (Exception) {
					// retry();
					return;
				}
				
			}
		}

        public Controllers()
        {
            Items.Add(new PHControl(PortConnection[0],0));
            Items.Add(new TempControl(PortConnection[0], 1));
            Items.Add(new AeratorControl(PortConnection[0], 2));
        }
        public void Refresh()
        {
            foreach (DataControl i in Items)
            {
                i.Refresh();
            }
        }
    }
}

