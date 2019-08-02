using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.Common.ValidationAttributes
{
    public class ProductionYearAttribute : ValidationAttribute
    {
        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
        public class YearRangeAttribute : ValidationAttribute
        {
            private int m_min;
            private RangeAttribute m_range;

            public YearRangeAttribute(int min)
            {
                m_min = min;
                m_range = new RangeAttribute(min, DateTime.Now.Year);
            }

            public override bool IsValid(object value)
            {
                return m_range.IsValid(value);
            }

            public override string FormatErrorMessage(string name)
            {
                return m_range.FormatErrorMessage(name);
            }
        }
    }
}
