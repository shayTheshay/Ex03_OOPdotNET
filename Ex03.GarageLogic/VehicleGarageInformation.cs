using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public enum eCarState
    {
        BeingFixed,
        Fixed,
        Paid
    }
    public class VehicleGarageInformation
    {
        private readonly string m_OwnerName;
        public string OwnerName
        {
            get { return m_OwnerName; }
        }

        private readonly string m_OwnerPhone;
        public string OwnerPhone
        {
            get { return m_OwnerPhone; }
        }
        private eCarState m_CurrentStateOfCar;
        public eCarState CurrentStateOfCar
        {
            get { return m_CurrentStateOfCar; }
            set { m_CurrentStateOfCar = value; }
        }
        private Vehicle m_Vehicle;
        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }
        public VehicleGarageInformation()
        {
            this.m_OwnerName = "shay";
            this.m_OwnerPhone = "0547500576";
            this.m_CurrentStateOfCar = eCarState.BeingFixed;
            this.m_Vehicle = new Truck();
        }
        public VehicleGarageInformation(string ownerName, string phoneNumber, Vehicle vehicle)
        {
            this.m_OwnerName = ownerName;
            this.m_OwnerPhone = phoneNumber;
            this.m_CurrentStateOfCar = eCarState.BeingFixed;
            this.m_Vehicle = vehicle;
        }


        public override string ToString()
        {
            return Vehicle.ToString() + "\n" + string.Format("Owner Name: {0}, Owner Phone:{1}, State of Vehicle{2}", OwnerName, OwnerPhone, CurrentStateOfCar);
        }
      


    }
}
