using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public enum eLicenseTypes
    {
        A,
        AA,
        A1,
        B
    }
    public abstract class Motorcycle : Vehicle
    {
        private eLicenseTypes m_CurrentActiveLicenseType;
        public eLicenseTypes CurrentActiveLicenseType
        {
            get => m_CurrentActiveLicenseType;
            set
            {
                m_CurrentActiveLicenseType = value switch
                {
                    eLicenseTypes.A => eLicenseTypes.A,
                    eLicenseTypes.A1 => eLicenseTypes.A1,
                    eLicenseTypes.AA => eLicenseTypes.AA,
                    _ => eLicenseTypes.B,
                };
            }
        }
        private int m_EngineCapacity;
        public int EngineCapacity
        {
            get => m_EngineCapacity;
        }
        protected Motorcycle()
        {
            m_CurrentActiveLicenseType = eLicenseTypes.A;
            m_EngineCapacity = 700;
        }
        protected Motorcycle(eLicenseTypes licenseType,
                             int engineCapacity,
                             string modelName,
                             string licensePlate,
                             float percentagePowerLeft,
                             int numOfWheels,
                             Wheel wheelExample) :
            base(modelName, licensePlate, percentagePowerLeft, numOfWheels, wheelExample)
        {
            if (!Enum.IsDefined(typeof(eLicenseTypes), licenseType))
                throw new ValueOutOfRangeException("License Type", 0, 3);
            m_CurrentActiveLicenseType = licenseType;
            m_EngineCapacity = engineCapacity;
        }
 
        public override string ToString()
        {
            return base.ToString() + string.Format("License Type:{0}, Engine Capacity:{1}", m_CurrentActiveLicenseType, m_EngineCapacity);
        } 
        
      
    }

}
