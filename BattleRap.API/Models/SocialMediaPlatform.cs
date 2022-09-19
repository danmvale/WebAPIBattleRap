using System.ComponentModel.DataAnnotations;

namespace BattleRap.API.Models
{
    public class SocialMediaPlatform
    {
        public int ID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string? Logo { get; set; }

        #region Navigation Properties

        public List<SocialMediaProfile> Profiles { get; set; }

        #endregion
    }
}
