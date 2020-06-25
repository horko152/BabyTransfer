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
			optionsBuilder.UseSqlServer(@"Host=ec2-54-246-85-151.eu-west-1.compute.amazonaws.com; Port=5432; Database=d1ev4oevtggnb4; Username=asntnkxuaztbvo; Password = 9c9f8f3faa8054d8f8abfdca04a9375b1c03f574ed9cc7b4114dc43aa1da95e4; SSL Mode = Require; TrustServerCertificate = True", builder =>
			{
				builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
			});
			base.OnConfiguring(optionsBuilder);
		}
	}
}
