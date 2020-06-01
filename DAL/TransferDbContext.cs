using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
	public class TransferDbContext : DbContext
	{
		public TransferDbContext() { }
		public DbSet<User> Users { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Driver> Driverss { get; set; }
		public DbSet<VehicleType> VehicleTypes { get; set; }
		public DbSet<Time> Times { get; set; }
		public DbSet<Order> Orders { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=DESKTOP-MFSAQ2U;Database=BabyTransferDb;Trusted_Connection=True;");
		}
	}
}
