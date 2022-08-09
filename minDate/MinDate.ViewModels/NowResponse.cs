using System;

namespace MinDate.ViewModels
{
    public class NowResponse
    {
        public NowResponse()
        {

        }

        public NowResponse(TimeZoneInfo tz, DateTimeOffset now)
        {
            Name = tz.DisplayName;
            Id = tz.Id;
            Now = TimeZoneInfo.ConvertTime(now, tz);
        }

        public string Name { get; set; }

        public string Id { get; set; }

        public DateTimeOffset Now { get; set; }
    }
}
