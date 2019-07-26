using System;

namespace GarageManager.Extensions.DateTimeProviders
{
    public interface IDateTimeProvider
    {
        DateTime GetDateTime();
    }
}
