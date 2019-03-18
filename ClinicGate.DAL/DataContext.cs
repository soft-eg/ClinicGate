using ClinicGate.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClinicGate.DAL
{
    public class DataContext : DbContext
    {


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<Patient> Patients { get; set; }

         

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }




    }
}
