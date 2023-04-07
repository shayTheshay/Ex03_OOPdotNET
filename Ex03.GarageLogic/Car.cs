using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public enum eCarDoorNumber
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }
    public enum eCarColor
    {
        Red,
        Blue,
        White,
        Gray
    }
    public abstract class Car : Vehicle
    {
        private eCarColor m_CarColor;
        public eCarColor CarcolorProperty
        {
            get => m_CarColor;
            set
            {
                switch(value)
                {
                    case eCarColor.Blue:
                        m_CarColor = eCarColor.Blue;
                        break;
                    case eCarColor.Red:
                        m_CarColor = eCarColor.Red;
                        break;
                    case eCarColor.Gray:
                        m_CarColor = eCarColor.Gray;
                        break;
                    default:
                        m_CarColor = eCarColor.White;
                        break;
                }
            }
        }
        private eCarDoorNumber m_CarDoorNumber;
        public eCarDoorNumber CardoorNumberProperty
        {
            get => m_CarDoorNumber;
        }
        protected Car()
        {
            this.m_CarColor = eCarColor.Blue;
            this.m_CarDoorNumber = eCarDoorNumber.Three;
        }

        protected Car(
            eCarColor carColor,
            eCarDoorNumber carDoorNumber,
            string modelName,
            string licensePlate,
            float percentagePowerLeft,
            int numOfWheels,
            Wheel wheelExample)
            : base(modelName, licensePlate, percentagePowerLeft, numOfWheels, wheelExample)
        {
            if (!Enum.IsDefined(typeof(eCarColor), carColor))
                throw new FormatException("Invalid color for vehicle");
            if (!Enum.IsDefined(typeof(eCarDoorNumber), carDoorNumber))
                throw new ValueOutOfRangeException("Car Door Number", 2, 5);
            this.m_CarColor = carColor ;
            this.m_CarDoorNumber = carDoorNumber;
        }

        public override string ToString()
        {
            return base.ToString() + "\n" + string.Format("Car Color:{0}, Number Of Doors:{1}", m_CarColor, m_CarDoorNumber);
        }

        
    }
}
