using System.ComponentModel.DataAnnotations;

namespace BattleRap.API.Models
{
    public class City
    {
        public int ID { get; set; }
        public int StateID { get; set; }

        [MaxLength(60)]
        public string Name { get; set; }

        #region Navigation Properties

        public List<Address> Addresses { get; set; }
        public State State { get; set; }

        #endregion
    }
}
