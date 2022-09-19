namespace BattleRap.API.Models
{
    public class OrganizationSuggestion
    {
        public int ID { get; set; }
        public int OrganizationInfoID { get; set; }
        public bool Approved { get; set; } = false;

        #region Navigation Properties

        public OrganizationInfo Info { get; set; }

        #endregion
    }
}
