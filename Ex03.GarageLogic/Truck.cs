using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    class Truck : Vehicle, IGasVehicle
    {
        public bool m_TakesDangerousMaterial { get; set; }
        private float m_CargoCurrentCapacity;
        public float CargoCapacity
        {
            get => m_CargoCurrentCapacity;
            set
            {
                if(value >= 0)
                    m_CargoCurrentCapacity = value;
            }
        }
        private float m_CurrentFuelInLiter;
        public float CurrentFuelInLiter
        {
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

        public Truck()
            : base()
        {
            m_MaximumFuelInTankLiter = 120f;
            m_FuelTypeOfGasVehicle = eFuelType.Soler;
            CargoCapacity = 200f;

        }
        public Truck(float maximumFuelInTankLiter,
                     eFuelType fuelType,
                     float currentFuelLiter,
                     float cargoCapacity, 
                     bool takesDangerousMaterial, 
                     string modelName,
                     string licensePlate, 
                     int numOfWheels,
                     Wheel wheelExample)
            : base(modelName, licensePlate, currentFuelLiter/maximumFuelInTankLiter, numOfWheels, wheelExample)
        {
            m_MaximumFuelInTankLiter = maximumFuelInTankLiter;
            m_FuelTypeOfGasVehicle = fuelType;
            m_TakesDangerousMaterial = takesDangerousMaterial;
            CargoCapacity = cargoCapacity;
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
            return base.ToString() + "\n" + string.Format("Does this take dangerous material?: {0}, Type of Fuel:{1}, Cargo Capacity:{2}, Current Fuel:{3}", m_TakesDangerousMaterial, m_FuelTypeOfGasVehicle, CargoCapacity, CurrentFuelInLiter) ;
        }
    }
}