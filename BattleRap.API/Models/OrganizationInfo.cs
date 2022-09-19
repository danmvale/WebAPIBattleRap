using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BattleRap.API.Models
{
    public class OrganizationInfo
    {
        public int ID { get; set; }
        public int AddressID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? Description { get; set; }

        public DayOfWeek? DayOfWeek { get; set; }

        [MaxLength(200)]
        public string? Logo { get; set; }

        #region Navigation Properties

        public Address Address { get; set; }
        public List<OrganizationSocialMedia> SocialMedias { get; set; } = new();

        #endregion
    }
}
