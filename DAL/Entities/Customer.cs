using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
	[Table("customers")]
	public class Customer
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; set; }

		[Column("user_id")]
		public int UserId { get; set; }

		[ForeignKey("UserId")]
		[JsonIgnore]
		public User User { get; set; }

		[Column("photo")]
		public byte Photo { get; set; }

		[Column("address")]
		public string Address { get; set; }

		[Column("lovelyvehicletype")]
		public string VehicleType { get; set; }

		[Column("listofchildren")]
		public ICollection<Child> Children { get; set; }

		[JsonIgnore]
		public ICollection<Order> Orders { get; set; }
	}
}
