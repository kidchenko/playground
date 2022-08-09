using System;

namespace MinDate.ViewModels
{
    public class TimeZoneResponse
    {
        public TimeZoneResponse(TimeZoneInfo tz)
        {
            Id = tz.Id;
            Name = tz.DisplayName;
            StandardName = tz.StandardName;
            UtcOffset = tz.BaseUtcOffset.Hours;
        }

        public TimeZoneResponse()
        {

        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string StandardName { get; set; }

        public int UtcOffset { get; set; }

    }
}
