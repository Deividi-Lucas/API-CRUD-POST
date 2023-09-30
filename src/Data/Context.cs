using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_api.src.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<ToDo> ToDo { get; set; }
    }
}