using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BattleRap.API.Models
{
    public class Address
    {
        public int ID { get; set; }
        public int CityID { get; set; }

        [MaxLength(9)]
        [Column(TypeName = "char(9)")]
        public string ZipCode { get; set; }

        [MaxLength(60)]
        public string AddressLine1 { get; set; }

        public int Number { get; set; }

        [MaxLength(60)]
        public string Neighborhood { get; set; }

        [MaxLength(100)]
        public string? AddressLine2 { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        #region Navigation Properties

        public City City { get; set; }

        #endregion
    }
}
