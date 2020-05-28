using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
	public class TransferDbContext : DbContext
	{
		public TransferDbContext() { }
		//Нижче будуть DbSet


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(@"Host=ec2-54-246-85-151.eu-west-1.compute.amazonaws.com; Port=5432; Database=d1ev4oevtggnb4; Username=asntnkxuaztbvo; Password = 9c9f8f3faa8054d8f8abfdca04a9375b1c03f574ed9cc7b4114dc43aa1da95e4; Use SSL Stream = True; SSL Mode = Require; TrustServerCertificate = True");
		}
	}
}
