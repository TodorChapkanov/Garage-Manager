using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;

namespace GarageManager.Web.Infrastructure.Filters
{
    public class LogExceptionFilter: IExceptionFilter
    {
        private readonly ILogger<LogExceptionFilter> logger;

        public LogExceptionFilter(ILogger<LogExceptionFilter> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var path = context.RouteData;
            var innerException = context.Exception.InnerException == null
                ? string.Empty
                : context.Exception.InnerException.Message;

            var eventId = context.HttpContext.TraceIdentifier;
            var stackTrace = context.Exception.StackTrace.ToString();
           var source = context
                .ExceptionDispatchInfo
                .SourceException
                .TargetSite
                .ReflectedType
                .FullName != null
                ? $"Source : {context.ExceptionDispatchInfo.SourceException.TargetSite.ReflectedType.FullName}"
                : string.Empty;

            var method = context
                .ExceptionDispatchInfo
                .SourceException
                .TargetSite
                .Name != null
                ? $" Method: {context.ExceptionDispatchInfo.SourceException.TargetSite.Name}"
                : string.Empty;
            var sourceException = context.ExceptionDispatchInfo.SourceException;

            this.logger.LogError($"[EventId: {eventId}]  {Environment.NewLine}" +
                $"{string.Join('/', path.Values)}  {Environment.NewLine}" +
                $"{source}  {Environment.NewLine}" +
                $"{method} {Environment.NewLine}" +
                $"{sourceException}  {Environment.NewLine}" +
                $"{innerException} {Environment.NewLine}" +
                $"{new String('-',60)}");
        }
    }
}
