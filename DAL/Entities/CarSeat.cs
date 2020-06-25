using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
	[Table("carseats")]
	public class CarSeat
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; set; }

		[Column("carseatfrom")]
		public DateTime CarSeatFrom { get; set; }

		[Column("carseatto")]
		public DateTime CarseatTo { get; set; }

		[Column("driver_id")]
		public int DriverId { get; set; }

		[ForeignKey("DriverId")]
		[JsonIgnore]
		public Driver Driver { get; set; }
	}
}
