using System;

namespace MinDate.ViewModels
{
    public class UtcNowResponse : NowResponse
    {
        public UtcNowResponse(DateTimeOffset now) : base(TimeZoneInfo.Utc, now)
        {
        }
    }
}
