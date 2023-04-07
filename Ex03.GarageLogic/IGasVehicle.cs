using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public enum eFuelType
    {
        Octan98,
        Octan96,
        Octan95,
        Soler
    }
    interface IGasVehicle
    {
        float CurrentFuelInLiter { get; set; }
        float MaximumFuelInTankLiter { get; }
        eFuelType FuelTypeOfGasVehicle { get; }
        public abstract void FuelAddingByType(float fuelToAdd, eFuelType fuel);

    }
}
