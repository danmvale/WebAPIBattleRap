namespace BattleRap.API.Models
{
    public class Organization
    {
        public int ID { get; set; }
        public int OrganizationInfoID { get; set; }
        public int? OrganizationSuggestionID { get; set; }

        #region Navigation Properties

        public OrganizationInfo Info { get; set; }
        public OrganizationSuggestion? OrganizationSuggestion { get; set; }

        #endregion
    }
}
