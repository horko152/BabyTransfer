using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
	[Table("addresses")]
	public class Address
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; set; }

		[Column("address")]
		public string AddressName { get; set; }

		[Column("city_id")]
		public int CityId { get; set; }

		[ForeignKey("CityId")]
		[JsonIgnore]
		public City City { get; set; }

	}
}
