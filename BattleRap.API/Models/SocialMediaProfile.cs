using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace BattleRap.API.Models
{
    public class SocialMediaProfile
    {
        public int ID { get; set; }
        public int SocialMediaPlatformID { get; set; }

        [MaxLength(200)]
        public string URL { get; set; }

        #region Navigation Properties

        public SocialMediaPlatform Platform { get; set; }

        #endregion
    }
}
