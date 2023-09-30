using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace dotnet_api.src.Models.Filter
{
    public class NotificationFilter
    {
        private readonly NotificationContext _notificationContext;

        public NotificationFilter(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutedContext context, ResultExecutionDelegate next)
        {
            if (_notificationContext.HasNotification)
            {
                context.HttpContext.Response.StatusCode = GetStatusCode(_notificationContext.notifications);
                context.HttpContext.Response.ContentType = "application/json";

                var notifications = JsonConvert.SerializeObject(_notificationContext.notifications);
                await context.HttpContext.Response.WriteAsync(notifications);

                return;
            }
            await next();
        }

        private int GetStatusCode(List<Notification> notifications)
        {
            var notifi = notifications.ToList();
            if (notifi.Exists(x => x.Key == "Erro"))
            {
                return (int)HttpStatusCode.BadRequest;
            }

            if (notifi.Exists(x => x.Key == "Alerta"))
            {
                return (int)HttpStatusCode.InternalServerError;
            }

            if (notifi.Exists(x => x.Key == "Informacao"))
            {
                return (int)HttpStatusCode.Accepted;
            }
            return (int)HttpStatusCode.BadRequest;
        }
    }
}