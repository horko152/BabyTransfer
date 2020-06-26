using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

namespace DAL
{
	public class TransferDbContext : DbContext
	{
		public TransferDbContext() { }
		public DbSet<User> Users { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Driver> Drivers { get; set; }
		public DbSet<VehicleType> VehicleTypes { get; set; }
		public DbSet<Time> Times { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<CarSeat> CarSeats { get; set; }
		public DbSet<Child> Children { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Status> Statuses { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"", builder =>
			{
				builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
			});
			base.OnConfiguring(optionsBuilder);
		}
	}
}
