using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{

    public enum ePowerSource
    {
        gasPowered,
        electricPowered
    }

    public enum eVehicleType
    {
        Car,
        Motorcycle,
        Truck
    }

    internal class VehicleCreator
    {
        public static VehicleGarageInformation CreateVehicle(Dictionary<string,string> vehicleFeatures)
        {
            Vehicle vehicle = null;
            ePowerSource powerSource = (ePowerSource)int.Parse(vehicleFeatures["Power Source"]);
            switch ((eVehicleType)int.Parse(vehicleFeatures["Type"]))
            {
                case eVehicleType.Car: 
                    if (powerSource == ePowerSource.gasPowered)
                        vehicle = new GasCar(maximumFuelInTankLiter: float.Parse(vehicleFeatures["Maximum Gas"]), fuelTypeOfGasCar:eFuelType.Octan95,currentFuelLiter:float.Parse(vehicleFeatures["Current Gas"]),carColor: (eCarColor)int.Parse(vehicleFeatures["Color"]),
                                             carDoorNumber:(eCarDoorNumber)int.Parse(vehicleFeatures["Doors"]),modelName:vehicleFeatures["Model Name"],licensePlate:vehicleFeatures["License Plate"],
                                             numOfWheels:5,wheelExample: new Wheel(i_creatorName: vehicleFeatures["Tire Manufacturer"],i_currentAirPressure: float.Parse(vehicleFeatures["Current Air Pressure"]),i_maximumAirPressure: float.Parse(vehicleFeatures["Maximum Air Pressure"])));
                    else
                        vehicle = new ElectricalCar(maximumBatteryTimeInHours: float.Parse(vehicleFeatures["Maximum Charge"]), currentBatteryTimeInHours:float.Parse(vehicleFeatures["Current Charge"]), carColor: (eCarColor)int.Parse(vehicleFeatures["Color"]),
                                             carDoorNumber: (eCarDoorNumber)int.Parse(vehicleFeatures["Doors"]), modelName: vehicleFeatures["Model Name"], licensePlate: vehicleFeatures["License Plate"],
                                             numOfWheels: 5, wheelExample: new Wheel(i_creatorName: vehicleFeatures["Tire Manufacturer"], i_currentAirPressure: float.Parse(vehicleFeatures["Current Air Pressure"]), i_maximumAirPressure: float.Parse(vehicleFeatures["Maximum Air Pressure"])));
                    break;
                case eVehicleType.Motorcycle: 
                    if (powerSource == ePowerSource.gasPowered)
                        vehicle = new GasMotorcycle(maximumFuelInTankLiter: float.Parse(vehicleFeatures["Maximum Gas"]), fuelTypeOfGasMotorcycle: eFuelType.Octan98, currentFuelLiter: float.Parse(vehicleFeatures["Current Gas"]),
                                             licenseType:(eLicenseTypes)int.Parse(vehicleFeatures["License Type"]),engineCapacity:int.Parse(vehicleFeatures["Engine Capacity"]),modelName: vehicleFeatures["Model Name"], licensePlate: vehicleFeatures["License Plate"],
                                             numOfWheels: 2, wheelExample: new Wheel(i_creatorName: vehicleFeatures["Tire Manufacturer"], i_currentAirPressure: float.Parse(vehicleFeatures["Current Air Pressure"]), i_maximumAirPressure: float.Parse(vehicleFeatures["Maximum Air Pressure"])));
                    else
                        vehicle = new ElectricalMotorcycle(maximumBatteryTimeInHours: float.Parse(vehicleFeatures["Maximum Charge"]), currentBatteryTimeInHours: float.Parse(vehicleFeatures["Current Charge"]), licenseType: (eLicenseTypes)int.Parse(vehicleFeatures["License Type"]), 
                                                            engineCapacity: int.Parse(vehicleFeatures["Engine Capacity"]),modelName: vehicleFeatures["Model Name"], licensePlate: vehicleFeatures["License Plate"],
                                                            numOfWheels: 2, wheelExample: new Wheel(i_creatorName: vehicleFeatures["Tire Manufacturer"], i_currentAirPressure: float.Parse(vehicleFeatures["Current Air Pressure"]), i_maximumAirPressure: float.Parse(vehicleFeatures["Maximum Air Pressure"])));
                    break;
                case eVehicleType.Truck:
                    if (powerSource == ePowerSource.gasPowered)
                        vehicle = new Truck(maximumFuelInTankLiter: float.Parse(vehicleFeatures["Maximum Gas"]), fuelType: eFuelType.Soler, currentFuelLiter: float.Parse(vehicleFeatures["Current Gas"]),
                                             cargoCapacity: float.Parse(vehicleFeatures["Cargo Capacity"]), takesDangerousMaterial: bool.Parse(vehicleFeatures["Dangerous Cargo"]), modelName: vehicleFeatures["Model Name"],
                                             licensePlate: vehicleFeatures["License Plate"], numOfWheels: 41, wheelExample: new Wheel(i_creatorName: vehicleFeatures["Tire Manufacturer"], i_currentAirPressure: float.Parse(vehicleFeatures["Current Air Pressure"]), i_maximumAirPressure: float.Parse(vehicleFeatures["Maximum Air Pressure"])));
                    else
                        throw new ArgumentException("No electric truck implemented");
                    break;
                default:
                    ValueOutOfRangeException valeOufOfRangeException = new ValueOutOfRangeException("Vehicle Type", 0, 2);
                    throw valeOufOfRangeException;
            }
            VehicleGarageInformation returnValue = new VehicleGarageInformation(vehicleFeatures["Owner Name"], vehicleFeatures["Owner Number"],vehicle);
            return returnValue;
        }



    }
}
