using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

		[Column("role_id")]
		public int RoleId { get; set; }

		[Column("city_id")]
		public int? CityId { get; set; }

		[ForeignKey("CityId")]
		[JsonIgnore]
		public City City { get; set; }

		[JsonIgnore]
		[ForeignKey("RoleId")]
		public Role Role { get; set; }

		[JsonIgnore]
		public ICollection<Customer> Customers { get; set; }

		[JsonIgnore]
		public ICollection<Driver> Drivers { get; set; }

	}
}
