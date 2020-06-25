using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
	[Table("children")]
	public class Child
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; set; }

		[Column("baby")]
		public DateTime Baby { get; set; }

		[Column("order_id")]
		public int OrderId { get; set; }

		[ForeignKey("OrderId")]
		[JsonIgnore]
		public Order Orders { get; set; }

		[Column("customer_id")]
		public int CustomerId { get; set; }

		[ForeignKey("CustomerId")]
		[JsonIgnore]
		public Customer Customer { get; set; }
	}
}