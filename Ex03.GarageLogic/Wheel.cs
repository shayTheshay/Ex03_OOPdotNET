using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Wheel
    {
        private string m_CreatorName;
        public string CreatorName
        {
            get { return m_CreatorName; }
        }
        private float m_CurrentWheelAirPressure;
        public float CurrentWheelAirPressure
        {
            get => m_CurrentWheelAirPressure;
            set
            {
                if(m_MaximumAirPressure >= value && value >= 0)
                    m_CurrentWheelAirPressure = value;
            }
        }
        private float m_MaximumAirPressure;
        public float MaximumAirPressure
        {
            get => m_MaximumAirPressure;
        }
        public Wheel()
        {
            m_CreatorName = "BasicName";
            m_CurrentWheelAirPressure = 28f;
            m_MaximumAirPressure = 32f;
        }
        public Wheel(string i_creatorName, float i_currentAirPressure, float i_maximumAirPressure)
        {
            this.m_CreatorName = i_creatorName;
            this.m_CurrentWheelAirPressure = i_currentAirPressure;
            this.m_MaximumAirPressure = i_maximumAirPressure;
            if (i_currentAirPressure > i_maximumAirPressure)
            {
                throw new ValueOutOfRangeException("Current Air Pressure", 0, i_maximumAirPressure);
            }
        }
        public void InflateAirInTire(float i_addAir)
        {
            if (m_MaximumAirPressure >= m_CurrentWheelAirPressure + i_addAir)
                m_CurrentWheelAirPressure += i_addAir;
        }
        public override string ToString()
        {
            return string.Format("Creator Name:{0}, Maximum Air Pressure:{1}, Current Air Pressure:{2}", m_CreatorName, m_MaximumAirPressure, m_CurrentWheelAirPressure);
        }
    }
}
