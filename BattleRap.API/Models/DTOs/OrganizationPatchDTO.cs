namespace BattleRap.API.Models.DTOs
{
    public class OrganizationPatchDTO
    {
        public DayOfWeek DayOfWeek { get; set; }

        public void UpdateOrganization(Organization organization)
        {
            organization.Info.DayOfWeek = DayOfWeek;
        }
    }
}
