
using System;
using System.Collections.Generic;
using System.IO.Ports;
namespace AEGIS
{
    class Engines
    { 
        bool EngineActive;

        void setup()
        {

        }

        void loop()
        { 
            // Other Option
            if (EngineActive)
                StartEngine(); 
            else
                StopEngine();        
            EngineActive = !EngineActive;

            DelayHour(4);
			
        }

        private void StartEngine()
        {
            throw new NotImplementedException();
        }

        private void StopEngine()
        {
            throw new NotImplementedException();
        }
		void delay(int a)
        {

        }
        // Time Delays
        void DelaySecond(int interval)
        {
            for (int i = 0; i < interval; i++)
                delay(1000); // in milliseconds
        }

        void DelayMinute(int interval)
        {
            if (interval < 0) interval = 0;
            for (int i = 0; i < interval; i++)
                DelaySecond(60);
        }

        void DelayHour(int interval)
        {
            if (interval < 0) interval = 0;
            for (int i = 0; i < interval; i++)
                DelayMinute(60);
        }

        void DelayDay(int interval)
        {
            if (interval < 0) interval = 0;
            for (int i = 0; i < interval; i++)
                DelayHour(24);
        }

    }
}