using System;

namespace GarageManager.Extensions.DateTimeProviders
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetDateTime()
        {
            return DateTime.UtcNow;
        }
    }
}
