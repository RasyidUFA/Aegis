/* 
 * User: Rasyid
 * Date: 24/03/2017
 * Time: 08.02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace AEGIS
{
    public interface Controller
    {
        string Status { get; }
        string Name { get; }
    }
    public class Control
    {

        public SerialPort serial;
        public int index;

        public Control(SerialPort port, int index)
        {
            this.serial = port;
            this.index = index;
        }
         
        public int SetDataToDevice(SerialPort COM, int index,string value,string defaults = "")
        {
            var lists = new List<string>();
            string raw;
            string data;
            try
            {
                raw = COM.ReadLine();
                var parted = raw.Split(';');
                lists = new List<string>(parted);
                var selected = parted[index];
                data = value ?? defaults;
            }
            catch (Exception)
            {
                return 1;
            }
            try
            {
                lists.Insert(index, data);
                lists.RemoveAt(index + 1);

            }
            catch (Exception)
            {
                return 2;
            }
            try
            {
                COM.WriteLine(String.Join(";", lists));
            }
            catch (Exception)
            {
                return 3;
            }
            return 0;
        }
        public int GetDataFromDevice(SerialPort COM, int index, string defaults,out string data)
        {
            var selected = defaults;
            try
            {
                var raw = COM.ReadLine();
                var parted = raw.Split(';');
                selected = parted[index];

            }
            catch (Exception ex)
            {
                return ex.GetHashCode();
            }
            finally
            {
                data = selected;
            }

            return 0;
        }
    }

    public class ActivationControl:Control
    {
        public ActivationControl(SerialPort port, int index): base(port,index)
        { 
        }

        private bool mDefault;
        private bool mData;
        private int mState;

        public bool Default
        {
            get
            {
                return mDefault;
            }
            set
            {
                mDefault = value;
            }
        }
        public bool Data
        {
            get
            {
                return mData;
            }
            set
            {
                mData = value;
            }
        }
        public int State
        {
            get
            {
                return mState;
            }
            set
            {
                mState = value;
            }
        }

        public void SetData()
        {
            SetDataToDevice(serial, index,mData.ToString(),mDefault.ToString());
        }

        public void GetData()
        {
            string  b;
            GetDataFromDevice(serial, index,mDefault.ToString(),out b);
            mData = Convert.ToBoolean(b); 
        } 
        public int Refresh()
        {
            return 0;
        }
    }


    public class DataControl : Control
    {
        public DataControl(SerialPort port, int index): base(port,index)
        {
        }
         

        private Double mDefault;
        private Double mData;
        private int mState;

        public Double Default
        {
            get
            {
                return mDefault;
            }
            set
            {
                mDefault = value;
            }
        }
        public Double Data
        {
            get
            {
                return mData;
            }
            set
            {
                mData = value;
            }
        }
        public int State
        {
            get
            {
                return mState;
            }
            set
            {
                mState = value;
            }
        }

        public int Max { get; internal set; }
        public int Min { get; internal set; }
         
        public int Refresh()
        {
            return 0;
        }
        public void SetData()
        {
            SetDataToDevice(serial, index, mData.ToString(), mDefault.ToString());
        }

        public void GetData()
        {
            string b;
            GetDataFromDevice(serial, index, mDefault.ToString(), out b);
            mData = Convert.ToDouble(b);
        }
    }

}