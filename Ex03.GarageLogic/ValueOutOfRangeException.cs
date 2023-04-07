using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
       

        public ValueOutOfRangeException(
            string i_Variable,
            float i_MinValue,
            float i_MaxValue)
            : base
                (string.Format("The value of {0} was not in the correct range between {1} and {2}",i_Variable, i_MinValue, i_MaxValue))
        { }
    }
}
