using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace GarageLogic
{
    class ElectricalCar : Car, IElectricalVehicle
    {
        private float m_BatteryTimeInHours;
        public float BatteryTimeInHours
        {
            get => m_BatteryTimeInHours;
            set
            {
                if (value > 0 && value <= m_MaximumBatteryTimeInHours)
                    m_BatteryTimeInHours = value;
            }
        }
        private float m_MaximumBatteryTimeInHours;
        public float MaximumBatteryTimeInHours
        {
            get => m_MaximumBatteryTimeInHours;
        }

        public void ChargeAddingByMinutes(float chargeToAddInMinutes)
        {
            if (chargeToAddInMinutes > m_MaximumBatteryTimeInHours * 60 - m_BatteryTimeInHours * 60)
                throw new ValueOutOfRangeException("Fuel to fill", 0, m_MaximumBatteryTimeInHours - m_BatteryTimeInHours);
            m_BatteryTimeInHours += chargeToAddInMinutes * 60;
        }

        public ElectricalCar():base()
        {
            m_MaximumBatteryTimeInHours = 4.7f;
            m_BatteryTimeInHours = 3f;
        }

        public ElectricalCar(float maximumBatteryTimeInHours, float currentBatteryTimeInHours, eCarColor carColor,
                             eCarDoorNumber carDoorNumber,
                             string modelName,
                             string licensePlate,
                             int numOfWheels,
                             Wheel wheelExample)
            : base(carColor,
                carDoorNumber,
                modelName,
                licensePlate,
                currentBatteryTimeInHours/maximumBatteryTimeInHours,
                numOfWheels,
                wheelExample)
        {
            m_MaximumBatteryTimeInHours = maximumBatteryTimeInHours;
            m_BatteryTimeInHours = currentBatteryTimeInHours;
            this.PercentagePowerLeft = m_BatteryTimeInHours * 100 / m_MaximumBatteryTimeInHours;
        }
            public override string ToString()
        {
            return base.ToString() + "\n" + string.Format("Remaining Battery Time:{0}, Maximum Battery:{1}", m_BatteryTimeInHours, m_MaximumBatteryTimeInHours);
        }

    }
}
