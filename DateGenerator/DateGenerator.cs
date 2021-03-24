using System;
using System.Collections.Generic;
using System.Linq;

namespace DateGenerator
{
    /// <summary>
    /// Generates list of dates by selected days in week and frequency between startDate and endDate and stores them in 'Generated' property
    /// </summary>
    public class DateGenerator
    {
        private const int _daysInWeek = 7;

        private DateTime StartDate { get; set; }
        private DateTime EndDate { get; set; }
        private DateFrequency Frequency { get; set; }
        private List<DayOfWeek> Days { get; set; }
        public List<DateTime> Generated { get; set; } = new List<DateTime>();


        /// <summary>
        /// Automatically generates Dates and stores them in 'Generated' property
        /// </summary>
        /// <param name="startDate">Start of generated sequence</param>
        /// <param name="endDate">End of generated sequence</param>
        /// <param name="days">Array of string days in week</param>
        /// <param name="frequency">Accepted values: 'Weekly', 'Biweekly', 'Monthly'</param>
        public DateGenerator(DateTime startDate, DateTime endDate, List<DayOfWeek> days, DateFrequency frequency)
        {
            StartDate = startDate;
            EndDate = endDate;
            Days = days;
            Frequency = frequency;

            Generate();

        }

        /// <summary>
        /// Automatically generates Dates and stores them in 'Generated' property
        /// </summary>
        /// <param name="startDate">Start of generated sequence</param>
        /// <param name="endDate">End of generated sequence</param>
        /// <param name="days">Array of string days in week. Accepted values: 'Monday', 'Tuesday', 'Wednesday', 'Friday', 'Saturday', 'Sunday'</param>
        /// <param name="frequency">Accepted values: 'Weekly', 'Biweekly', 'Monthly'</param>
        public DateGenerator(DateTime startDate, DateTime endDate, string[] days, string frequency)
        {
            StartDate = startDate;
            EndDate = endDate;
            Days = DateExtensions.DaysOfWeekFromString(days);
            Frequency = DateExtensions.FrequencyFromString(frequency);

            Generate();
        }

        public List<DateTime> Generate()
        {
            Generated.Clear();

            foreach (var day in Days)
            {
                var daysInRange = GetDaysInRange(day);
                var resultDays = FilterDaysByFrequency(daysInRange);
                Generated.AddRange(resultDays);
            }
            FilterRemainderDates();
            Generated = Generated.OrderByDescending(u => u.Date).ToList();

            return Generated;
        }

        private void FilterRemainderDates()
        {
            Generated = Generated.Where(u => u <= EndDate).ToList();
        }

        private List<DateTime> FilterDaysByFrequency(List<DateTime> days)
        {
            switch (Frequency)
            {
                case DateFrequency.Weekly:
                    return days;
                case DateFrequency.Biweekly:
                    return days.Where((x, i) => i % 2 == 0).ToList();
                case DateFrequency.Monthly:
                    var firstDay = days.First();
                    var filtered = days.Where((x, i) => i % 4 == 0);
                    filtered.Prepend(firstDay);
                    return filtered.ToList();
            }
            return null;
        }

        private List<DateTime> GetDaysInRange(DayOfWeek day)
        {
            var localOffsetDay = StartDate;
            var result = new List<DateTime>();
            var daysToAdd = ((int)day - (int)localOffsetDay.DayOfWeek + _daysInWeek) % _daysInWeek;
            do
            {
                localOffsetDay = localOffsetDay.AddDays(daysToAdd);
                result.Add(localOffsetDay);
                daysToAdd = _daysInWeek;
            }
            while (localOffsetDay < EndDate);

            return result;
        }
    }

    public enum DateFrequency
    {
        Weekly,
        Biweekly,
        Monthly,
        None
    }
}
