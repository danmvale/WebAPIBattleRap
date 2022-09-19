using System.ComponentModel.DataAnnotations;

namespace BattleRap.API.Models
{
    public class OrganizationSocialMedia
    {
        public int ID { get; set; }
        public int OrganizationID { get; set; }
        public int SocialMediaProfileID { get; set; }

        #region Navigation Properties

        public SocialMediaProfile SocialMediaProfile { get; set; }
        public OrganizationInfo OrganizationInfo { get; set; }

        #endregion
    }
}
