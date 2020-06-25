using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
	[Table("orders")]
	public class Order
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; set; }

		[Column("customer_id")]
		public int? CustomerId { get; set; }

		[Column("status_id")]
		public int StatusId { get; set; }

		[Column("driver_id")]
		public int? DriverId { get; set; }

		[Column("timeofcall")]
		public DateTime TimeOfCall { get; set; }

		[Column("city_id")]
		public int? CityId { get; set; }

		[Column("addressofcall")]
		public string AddressOfCall { get; set; }

		[Column("addressoftransfer")]
		public string AddressOfTransfer { get; set; }

		[Column("vehicletype_id")]
		public int VehicleTypeId { get; set; }

		[Column("backandforth")]
		public bool BackAndForth { get; set; }

		[Column("comment")]
		public string Comment { get; set; }

		[Column("distance")]
		public double Distance { get; set; }

		[Column("arrivaltime")]
		public DateTime ArrivalTime { get; set; }

		[Column("cost")]
		public decimal Cost { get; set; }

		[ForeignKey("CustomerId")]
		[JsonIgnore]
		public Customer Customer { get; set; }

		[ForeignKey("StatusId")]
		[JsonIgnore]
		public Status Status { get; set; }

		[ForeignKey("DriverId")]
		[JsonIgnore]
		public Driver Driver { get; set; }

		[ForeignKey("VehicleTypeId")]
		[JsonIgnore]
		public VehicleType VehicleType { get; set; }

		[ForeignKey("CityId")]
		[JsonIgnore]
		public City City { get; set; }

		public ICollection<Child> Children { get; set; }
	}
}
