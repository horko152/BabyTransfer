using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
	[Table("drivers")]
	public class Driver : User
	{
		[Column("vehicletype")]
		public string VehicleType { get; set; }
		[Column("vehiclenumber")]
		public string VehicleNumber { get; set; }
		[Column("vehicledescription")]
		public string VehicleDescription { get; set; }
		[Column("cardnumber")]
		public string CardNumber { get; set; }
		[Column("priceforcall")]
		public decimal PriceForCall { get; set; }
		[Column("priceforkm")]
		public decimal PriceForKm { get; set; }
		[Column("startworking")]
		public TimeSpan StartWorking { get; set; }
		[Column("stopworking")]
		public TimeSpan StopWorking { get; set; }
		[Column("pausefrom")]
		public TimeSpan PauseFrom { get; set; }
		[Column("pauseto")]
		public TimeSpan PauseTo { get; set; }
		[JsonIgnore]
		public ICollection<Order> Orders { get; set; }

	}
}
