using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
	[Table("users")]
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; set; }

		[Column("firstname")]
		public string FirstName { get; set; }

		[Column("lastname")]
		public string LastName { get; set; }

		[Column("phone")]
		public string Phone { get; set; }

		[Column("email")]
		public string Email { get; set; }

		[Column("password")]
		public string Password { get; set; }

		[Column("role")]
		[DefaultValue(Entities.Role.Customer)]
		public string Role { get; set; }

		[Column("city")]
		public string City { get; set; }

		[JsonIgnore]
		public ICollection<Customer> Customers { get; set; }

		[JsonIgnore]
		public ICollection<Driver> Drivers { get; set; }

	}
}
