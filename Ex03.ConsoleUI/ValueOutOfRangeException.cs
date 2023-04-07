using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }
        private float m_MinValue;
        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }
        public ValueOutOfRangeException(
            Exception i_InnerException,
            int i_MinValue,
            int i_MaxValue) 
            :base
                (string.Format("The value given was not in the correct range between {0} and {1}",i_MinValue,i_MaxValue))
        { }

        public ValueOutOfRangeException(
            int i_MinValue,
            int i_MaxValue)
            : base
                (string.Format("The value given was not in the correct range between {0} and {1}", i_MinValue, i_MaxValue))
        { }
    }
}
