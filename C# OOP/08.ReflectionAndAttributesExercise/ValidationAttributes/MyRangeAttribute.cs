using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            bool valueIsInt = obj is int;

            if (!valueIsInt)
            {
                return false;
            }

            int value = (int)obj;

            return value >= minValue && value <= maxValue;
        }
    }
}
