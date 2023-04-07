using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    class GasMotorcycle : Motorcycle, IGasVehicle
    {
        private float m_CurrentFuelInLiter;
        public float CurrentFuelInLiter {
            get => m_CurrentFuelInLiter;
            set
            {
                if(MaximumFuelInTankLiter >= value && value >= 0)
                    m_CurrentFuelInLiter = value;
            }
        }
        private float m_MaximumFuelInTankLiter;
        public float MaximumFuelInTankLiter
        {
            get => m_MaximumFuelInTankLiter;
        }
        private eFuelType m_FuelTypeOfGasVehicle;
        public eFuelType FuelTypeOfGasVehicle
        {
            get => m_FuelTypeOfGasVehicle;
        }

        public GasMotorcycle()
            : base()
        {
            m_MaximumFuelInTankLiter = 6f;
            m_FuelTypeOfGasVehicle = eFuelType.Octan98;
        }
        public GasMotorcycle(float maximumFuelInTankLiter,
                             eFuelType fuelTypeOfGasMotorcycle,
                             float currentFuelLiter,
                             eLicenseTypes licenseType,
                             int engineCapacity,
                             string modelName,
                             string licensePlate,
                             int numOfWheels,
                             Wheel wheelExample)
            : base( licenseType, engineCapacity, modelName, licensePlate, currentFuelLiter/maximumFuelInTankLiter, numOfWheels, wheelExample)
        {
            m_MaximumFuelInTankLiter = maximumFuelInTankLiter;
            m_FuelTypeOfGasVehicle = fuelTypeOfGasMotorcycle;
            CurrentFuelInLiter = currentFuelLiter;
            this.PercentagePowerLeft = CurrentFuelInLiter * 100 / m_MaximumFuelInTankLiter;
        }


        public void FuelAddingByType(float fuelToAdd, eFuelType fuel)
        {
            if (fuelToAdd > MaximumFuelInTankLiter - CurrentFuelInLiter)
                throw new ValueOutOfRangeException("Fuel to fill", 0, MaximumFuelInTankLiter - CurrentFuelInLiter);
            if (fuel != FuelTypeOfGasVehicle)
                throw new ArgumentException(String.Format("Incorrect fuel type for vehicle. Expected {0}", FuelTypeOfGasVehicle));
              CurrentFuelInLiter += fuelToAdd;
        }
        public override string ToString()
        {
            return base.ToString() + "\n" + string.Format("Fuel type:{0}, Current Fuel:{1}, Maximum Fuel:{2}", m_FuelTypeOfGasVehicle, m_CurrentFuelInLiter, m_MaximumFuelInTankLiter);
        }
    }
}
