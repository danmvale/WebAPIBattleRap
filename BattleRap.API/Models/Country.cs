using System.ComponentModel.DataAnnotations;

namespace BattleRap.API.Models
{
    public class Country
    {
        public int ID { get; set; }

        [MaxLength(60)]
        public string Name { get; set; }

        #region Navigation Properties

        public List<State> States { get; set; }

        #endregion
    }
}
