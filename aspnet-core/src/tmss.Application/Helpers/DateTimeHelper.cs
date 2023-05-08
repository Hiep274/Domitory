using System;

namespace tmss.Helpers
{
    public static class DateTimeHelper
    {
        public static bool InRange(DateTime? dateToCheck, DateTime? startDate, DateTime? endDate)
        {
            if (dateToCheck.HasValue && startDate.HasValue && endDate.HasValue)
            {
                return dateToCheck.Value.Date >= startDate.Value.Date && dateToCheck.Value.Date <= endDate.Value.Date;
            }
            return false;
        }
        public static bool InRangeWithoutYear(DateTime? dateToCheck, DateTime? startDate, DateTime? endDate)
        {
            if (dateToCheck.HasValue && startDate.HasValue && endDate.HasValue)
            {
                try
                {
                    var dateCheck = new DateTime(DateTime.Now.Year, dateToCheck.Value.Month, dateToCheck.Value.Day);
                    return dateCheck.Date >= startDate.Value.Date && dateCheck.Date <= endDate.Value.Date;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}
