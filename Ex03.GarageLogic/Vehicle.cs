using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Vehicle
    {

        private List<Wheel> m_Wheels;
        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
        }
        private readonly string r_ModelName;
        public string ModelName
        {
            get => r_ModelName;
        }
        private readonly string r_LicensePlate;
        public string LicensePlate
        {
            get => r_LicensePlate;
        }
        private float m_PercentageOfPowerLeft;
        public float PercentagePowerLeft
        {
            get => m_PercentageOfPowerLeft;
            set
            {
                if(value is > 0 and < 100)
                    m_PercentageOfPowerLeft = value;
            }
        }
        protected Vehicle()
        {
            r_ModelName = "basic_car";
            r_LicensePlate = "6trj244";
            Wheel generalWheel = new();
            m_Wheels = new List <Wheel>
            {
                generalWheel,
                generalWheel,
                generalWheel,
                generalWheel
            };
        }
        protected Vehicle(string modelName,
                          string licensePlate,
                          float percentagePowerLeft,
                          int numOfWheels,
                          Wheel wheelExample)
        {
            if (percentagePowerLeft > 1)
            {
                ValueOutOfRangeException valeOufOfRangeException = new ValueOutOfRangeException("Percentage Power in Vehicle",0, 1);
                throw valeOufOfRangeException;
            }
            this.r_ModelName = modelName;
            this.r_LicensePlate = licensePlate;
            this.PercentagePowerLeft = percentagePowerLeft;
            this.m_Wheels = WheelsAsRequestedList(numOfWheels, wheelExample);
        }

        public List<Wheel> WheelsAsRequestedList(int numOfWheels, Wheel wheelExample)
        {
            List<Wheel> temporaryListOfWheels = new List<Wheel>(numOfWheels);
            for(int i = 0; i < numOfWheels; i++)
            {
                temporaryListOfWheels.Add(wheelExample);
            }
            return temporaryListOfWheels;
        }

        public override string ToString()
        {
            string toReturn = string.Format("Model name:{0}, License Plate:{1}, Percantage Power Left:{2} \n Wheels:(", r_ModelName, LicensePlate, PercentagePowerLeft);
            int i = 0;
                foreach (Wheel wheel in m_Wheels)
                {
                toReturn = string.Concat(toReturn,string.Format("Wheel {0}: {1}", i, wheel));
                i++;
                }
                toReturn = string.Concat(toReturn, ")");

            return toReturn;
        }
    }
}