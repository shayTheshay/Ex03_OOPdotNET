using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GarageLogic;

namespace Ex03.ConsoleUI
{
    public class ConsoleUI
    {
        
        private List<VehicleGarageInformation> m_InGarage = new List<VehicleGarageInformation>();
        private Garage m_Garage;

        public ConsoleUI()
        {
            m_Garage = new Garage();
        }

        public void MainLoop()
        {
            Console.WriteLine(
                "To insert new vehicle to garage, please press 0. \n"
                + "To see all vehicles in garage, please press 1. \n"
                + "To change status of vehicle, please press 2. \n"
                + "To maximize tire pressure of vehicle, please press 3. \n"
                + "To fill fuel of gas powered vehicle, please press 4. \n"
                + "To fill power for electric powered vehicle, please press 5. \n"
                + "To print all details about a vehicle, please press 6.");
            string input;
            try
            {
                input = Console.ReadLine();
                ChosenMode modeInputValue = (ChosenMode)int.Parse(input);
                switch(modeInputValue)
                {
                    case ChosenMode.InsertVehicle:
                        insertVehicle();
                        break;
                    case ChosenMode.PrintLicensePlateVehicles:
                        printLicensePlateVehicles();
                        break;
                    case ChosenMode.ChangeVehicleStatus:
                        changeVehicleStatus();
                        break;
                    case ChosenMode.MaximizeVehicleTirePressure:
                        maximizeVehicleTirePressure();
                        break;
                    case ChosenMode.FillGasVehicle:
                        fillGasVehicle();
                        break;
                    case ChosenMode.FillElectricVehicle:
                        fillElectricVehicle();
                        break;
                    case ChosenMode.PrintAllDataVehicle:
                        printAllDataVehicle();
                        break;
                    default:
                        throw new ValueOutOfRangeException(i_MinValue: 0, i_MaxValue: 6);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                MainLoop();
            }
        }

        private int readInputInRange(int minValue, int maxValue)
        {
            string returnValue = Console.ReadLine();
            if(returnValue == "Q")
                System.Environment.Exit(0);
            if(int.Parse(returnValue) > maxValue || int.Parse(returnValue) < minValue)
            {
                ValueOutOfRangeException valeOufOfRangeException = new ValueOutOfRangeException(minValue, maxValue);
                throw valeOufOfRangeException;
            }

            return int.Parse(returnValue);
        }

        private void insertVehicle()
        {
            Dictionary<string, string> vehicleFeatures = new Dictionary<string, string>();
            Console.WriteLine(
                "For car, press 0. \n" + "For motorcycle, press 1. \n" + "For truck press 2.");
            vehicleFeatures["Type"] = Console.ReadLine();
            Console.WriteLine("Please insert your name");
            vehicleFeatures["Owner Name"] = Console.ReadLine();
            Console.WriteLine("Please insert your telephone number");
            vehicleFeatures["Owner Number"] = Console.ReadLine();
            Console.WriteLine("Please insert vehicle license plate");
            vehicleFeatures["License Plate"] = Console.ReadLine();
            Console.WriteLine("Please insert vehicle model name");
            vehicleFeatures["Model Name"] = Console.ReadLine();

            switch ((eVehicleType)int.Parse(vehicleFeatures["Type"]))
            {
                case eVehicleType.Car: //Car
                    vehicleFeatures["Maximum Gas"] = "50";
                    vehicleFeatures["Maximum Charge"] = "4.7";
                    vehicleFeatures["Maximum Air Pressure"] = "32";
                    Console.WriteLine("Please input number of doors (between 2 and 5)");
                    vehicleFeatures["Doors"] = Console.ReadLine();
                    Console.WriteLine(
                       "For red car, please press 0. \n"
                       + "For blue car, please press 1. \n"
                       + "For white car, please press 2. \n"
                       + "For gray car, please press 3.");
                    vehicleFeatures["Color"] = Console.ReadLine();
                    break;
                case eVehicleType.Motorcycle:
                    vehicleFeatures["Maximum Gas"] = "6";
                    vehicleFeatures["Maximum Charge"] = "1.6";
                    vehicleFeatures["Maximum Air Pressure"] = "28";
                    Console.WriteLine("Please input engine capacity");
                    vehicleFeatures["Engine Capacity"] = Console.ReadLine();
                    Console.WriteLine(
                       "For A license, please press 0. \n"
                       + "For AA license, please press 1. \n"
                       + "For A1 license, please press 2. \n"
                       + "For B license, please press 3.");
                    vehicleFeatures["License Type"] = Console.ReadLine();
                    break;
                case eVehicleType.Truck:
                    vehicleFeatures["Maximum Gas"] = "120";
                    vehicleFeatures["Maximum Air Pressure"] = "34";
                    Console.WriteLine("Please input cargo capacity");
                    vehicleFeatures["Cargo Capacity"] = Console.ReadLine();
                    Console.WriteLine("If the vehicle can take dangerous cargo, press 0. Otherwise, press any other button.");
                    vehicleFeatures["Dangerous Cargo"] = (Console.ReadLine() == "0").ToString();
                    break;
            }
            Console.WriteLine("Please insert you wheel manufacturer");
            vehicleFeatures["Tire Manufacturer"] = Console.ReadLine();
            Console.WriteLine("Please insert current air pressure in tires. Can't exceed " + vehicleFeatures["Maximum Air Pressure"]);
            vehicleFeatures["Current Air Pressure"] = Console.ReadLine();

            vehicleFeatures["Power Source"] =((int)ePowerSource.gasPowered).ToString();
            if ((eVehicleType)int.Parse(vehicleFeatures["Type"]) != eVehicleType.Truck) //there are no electric trucks therfor check is irrelevant
            {
                Console.WriteLine(
                "For gas powered vehicle, press 0. \n" + "For electrical vehicle, press 1.");
                vehicleFeatures["Power Source"] = Console.ReadLine();
            }

            if ((ePowerSource)int.Parse(vehicleFeatures["Power Source"]) == ePowerSource.gasPowered)
            {
                Console.WriteLine("Please input current fuel in tank. Can't be exceed " + vehicleFeatures["Maximum Gas"]);
                vehicleFeatures["Current Gas"] = Console.ReadLine();
            }

            if ((ePowerSource)int.Parse(vehicleFeatures["Power Source"]) == ePowerSource.electricPowered)
            {
                Console.WriteLine("Please input current charge in battery. Can't be exceed " + vehicleFeatures["Maximum Charge"]);
                vehicleFeatures["Current Charge"] = Console.ReadLine();
            }

            m_Garage.EnterNewVehicle(vehicleFeatures);
        }

        private void printLicensePlateVehicles()
        {
            Console.WriteLine(
                "If you would like to sort by condition in garage, input 1 \n" 
                + "Otherwise, press any  other button");
            string input = Console.ReadLine();
            if(input == "1")
            { 
                Console.WriteLine("If you would like to display in order in repair - fixed - paid, press 1 \n"
                + "Otherwise, press any other button");
                bool order = Console.ReadLine() == "1";
                m_Garage.SortGarageByCondition(order);
            }

            foreach(VehicleGarageInformation garageVehicle in m_Garage.CarsInGarage)
            {
                Console.WriteLine("License Plate: " + garageVehicle.Vehicle.LicensePlate + "Condition: " + garageVehicle.CurrentStateOfCar);
            }
        }

        private void changeVehicleStatus()
        {
            Console.WriteLine("Please insert the vehicle license plate");
            string licensePlate = Console.ReadLine();
            Console.WriteLine("To change condition to in repair, enter 0. \n"
                              + "To change condition to fixed, enter 1."
                              + "To change condition to paid, enter 2");
            eCarState newCondition = (eCarState) readInputInRange(0, 2);
            m_Garage.ChangeVehicleState(licensePlate, newCondition);
        }

        private void maximizeVehicleTirePressure()
        {
            Console.WriteLine("Please insert the vehicle license plate");
            string licensePlate = Console.ReadLine();
            m_Garage.FillWheelsToMaximum(licensePlate);
        }

        private void fillGasVehicle()
        {
            Console.WriteLine("Please insert the vehicle license plate");
            string licensePlate = Console.ReadLine();
            Console.WriteLine("For Octan98, press 0.\n"
                + "For Octan96, press 1. \n"
                + "For Octan95, press 2 \n"
                + "For Soler, press 3");
            eFuelType fuelType = (eFuelType)int.Parse(Console.ReadLine());
            Console.WriteLine("Please insert desired amount of fuel to fill.");
            int fuelToFill = int.Parse(Console.ReadLine());
            m_Garage.FillGasVehicle(licensePlate,fuelType,fuelToFill);
        }

        private void fillElectricVehicle()
        {
            Console.WriteLine("Please insert the vehicle license plate");
            string licensePlate = Console.ReadLine();
            Console.WriteLine("Please insert desired amount of minutes to charge.");
            int minutesToCharge = int.Parse(Console.ReadLine());
            m_Garage.FillElectricVehicle(licensePlate,minutesToCharge);
        }

        private void printAllDataVehicle()
        {
            Console.WriteLine("Please insert the vehicle license plate");
            string licensePlate = Console.ReadLine();
            Console.WriteLine(m_Garage.GetAllDetailsOfVehicles(licensePlate));
        }
    }


    enum ChosenMode
    {
        InsertVehicle,
        PrintLicensePlateVehicles,
        ChangeVehicleStatus,
        MaximizeVehicleTirePressure,
        FillGasVehicle,
        FillElectricVehicle,
        PrintAllDataVehicle
    }
    enum eLicenseType
    {
        A,
        A1,
        AA,
        B
    }

}
