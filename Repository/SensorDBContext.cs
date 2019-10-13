using Common.models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Repository
{
    public class SensorDBContext: DbContext
    {
        public SensorDBContext(DbContextOptions<SensorDBContext> options) : base(options)
        {
        }
        public DbSet<SensorData> SensorData { get; set; }
    }
}

