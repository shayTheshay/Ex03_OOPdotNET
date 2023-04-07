using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    interface IElectricalVehicle
    {
        float BatteryTimeInHours { get; set; }
        public float MaximumBatteryTimeInHours { get; }
        public abstract void ChargeAddingByMinutes(float chargeToAdd);
    }
}
