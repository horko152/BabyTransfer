using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
	[Table("drivers")]
	public class Driver
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

		[Column("vehicletype_id")]
		public int VehicleTypeId { get; set; }

		[Column("cardnumber")]
		public string CardNumber { get; set; }

		[Column("time_id")]
		public int TimeId { get; set; }

		[ForeignKey("VehicleTypeId")]
		[JsonIgnore]
		public VehicleType VehicleType { get; set; }

		[ForeignKey("TimeId")]
		[JsonIgnore]
		public Time Time { get; set; }

		[JsonIgnore]
		public ICollection<CarSeat> CarSeats { get; set; }

		[JsonIgnore]
		public ICollection<Order> Orders { get; set; }

	}
}
