using System;

namespace MinDate.ViewModels
{
    public class LocalNowResponse : NowResponse
    {
        public LocalNowResponse(DateTimeOffset now) : base(TimeZoneInfo.Local, now)
        {
        }
    }
}
