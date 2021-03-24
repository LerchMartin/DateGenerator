using System;
using System.Collections.Generic;
using System.Text;
using DateGenerator;

namespace DateGenerator
{
    public static class DateExtensions
    {
        public static List<DayOfWeek> DaysOfWeekFromString(string[] days)
        {
            var result = new List<DayOfWeek>();
            foreach (var day in days)
            {
                var dayOfWeek = DayOfWeekFromString(day);
                result.Add(dayOfWeek);
            }
            return result;
        }

        public static DayOfWeek DayOfWeekFromString(string day)
        {
            switch (day.ToLower())
            {
                case "monday":
                    return DayOfWeek.Monday;
                case "tuesday":
                    return DayOfWeek.Tuesday;
                case "wednesday":
                    return DayOfWeek.Wednesday;
                case "thursday":
                    return DayOfWeek.Thursday;
                case "friday":
                    return DayOfWeek.Friday;
                case "saturday":
                    return DayOfWeek.Saturday;
                case "sunday":
                    return DayOfWeek.Sunday;

                default:
                    return DayOfWeek.Sunday;
            }
        }
        public static DateFrequency FrequencyFromString(string frequency)
        {
            switch (frequency.ToLower())
            {
                case "weekly":
                    return DateFrequency.Weekly;
                case "biweekly":
                    return DateFrequency.Biweekly;
                case "monthly":
                    return DateFrequency.Monthly;
            }

            return DateFrequency.None;
        }

    }
}
