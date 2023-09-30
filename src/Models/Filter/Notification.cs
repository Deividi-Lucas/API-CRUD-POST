using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace dotnet_api.src.Models.Filter
{
    public class Notification
    {
        public string Key { get; }

        public string Message { get; }

        public Notification(string key, string message)
        {
            key = Key;
            message = Message;
        }
    }
}