using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
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

		[Column("carseat")]
		public DateTime CarSeatType { get; set; }

		[Column("driver_id")]
		public int DriverId { get; set; }

		[ForeignKey("DriverId")]
		[JsonIgnore]
		public Driver Driver { get; set; }
	}
}
