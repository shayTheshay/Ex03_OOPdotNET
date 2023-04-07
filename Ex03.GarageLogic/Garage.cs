using System;
using System.Collections.Generic;
using System.Reflection;



namespace GarageLogic
{
    public class Garage
    {
        private List<VehicleGarageInformation> m_CarsInGarage;

        public List<VehicleGarageInformation> CarsInGarage
        {
            get { return m_CarsInGarage; }
        }

        public Garage()
        {
            m_CarsInGarage = new List<VehicleGarageInformation>();
        }

        public void EnterNewVehicle(Dictionary<string,string> vehicleFeatures)
        {
            if (m_CarsInGarage.Find(x => x.Vehicle.LicensePlate == vehicleFeatures["License Plate"]) != null)
                throw new ArgumentException("There already exists a vehicle with this license plate");
            m_CarsInGarage.Add(VehicleCreator.CreateVehicle(vehicleFeatures));
        }

        public void SortGarageByCondition(bool repairFirst = true)
        {
            m_CarsInGarage.Sort();
        }

        public void ChangeVehicleState(string i_LicensePlate, eCarState i_NewCondition)
        {
            getVehicle(i_LicensePlate).CurrentStateOfCar = i_NewCondition;
        }

        public void FillWheelsToMaximum(string i_LicensePlate)
        {
            VehicleGarageInformation toFill = getVehicle(i_LicensePlate);
            foreach (Wheel wheel in toFill.Vehicle.Wheels)
            {
                wheel.InflateAirInTire(wheel.MaximumAirPressure - wheel.CurrentWheelAirPressure);
            }
        }

        public void FillGasVehicle(string i_LicensePlate, eFuelType i_GasType,float i_AmountToFill)
        {
            object oMyObject = getVehicle(i_LicensePlate).Vehicle;
            switch (oMyObject.GetType().Name)
            {
                case "GasCar":
                    GasCar gasCar = (GasCar)oMyObject;
                    gasCar.FuelAddingByType(i_AmountToFill, i_GasType);
                    break;
                case "GasMotorcycle":
                    GasMotorcycle gasMotorcycle = (GasMotorcycle)oMyObject;
                    gasMotorcycle.FuelAddingByType(i_AmountToFill, i_GasType);
                    break;
                case "Truck":
                    Truck truck = (Truck)oMyObject;
                    truck.FuelAddingByType(i_AmountToFill, i_GasType);
                    break;
                default:
                    throw new ArgumentException("Not an electric Vehicle!");
            }
        }
        public void FillElectricVehicle(string i_LicensePlate, float i_MinutesToFill)
        {
            object oMyObject = getVehicle(i_LicensePlate).Vehicle;
            switch (oMyObject.GetType().Name)
            {
                case "ElectricalCar":
                    ElectricalCar electricalCar = (ElectricalCar)oMyObject;
                    electricalCar.ChargeAddingByMinutes(i_MinutesToFill);
                    break;
                case "ElectricalMotorcycle":
                    ElectricalMotorcycle electricalMotorcycle = (ElectricalMotorcycle)oMyObject;
                    electricalMotorcycle.ChargeAddingByMinutes(i_MinutesToFill);
                    break;
                default:
                    throw new ArgumentException("Not an electric Vehicle!");
            }

        }

        public string GetAllDetailsOfVehicles(string i_LicensePlate)
        {
            return getVehicle(i_LicensePlate).ToString();
        }

        public bool isInGarage(string i_LicensePlate)
        {
            return m_CarsInGarage.Find(x => x.Vehicle.LicensePlate == i_LicensePlate) != null;
        }

        internal VehicleGarageInformation getVehicle(string i_LicensePlate)
        {
            VehicleGarageInformation returnValue = m_CarsInGarage.Find(x => x.Vehicle.LicensePlate == i_LicensePlate);
            if (returnValue == null)
                throw new Exception("Car not in garage!");
            return returnValue;
        }
     




    }
}
