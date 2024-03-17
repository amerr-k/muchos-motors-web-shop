using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace muchos_motors_api.Utils
{
    public static class DateTimeUtils
    {
        public static DateTime ConvertToCET(this DateTime dateTime)
        {
            TimeZoneInfo cetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");

            return TimeZoneInfo.ConvertTimeFromUtc(dateTime.ToUniversalTime(), cetTimeZone);
        }
    }
}
