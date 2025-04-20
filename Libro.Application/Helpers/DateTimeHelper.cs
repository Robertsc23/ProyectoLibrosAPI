using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime Normalize(DateTime? dateTime)
        {
            if (!dateTime.HasValue)
                return DateTime.Now; 

            var dt = dateTime.Value;
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
        }
    }
}
