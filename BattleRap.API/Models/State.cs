using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BattleRap.API.Models
{
    public class State
    {
        public int ID { get; set; }
        public int CountryID { get; set; }

        [MaxLength(60)]
        public string Name { get; set; }

        [MaxLength(2)]
        [Column(TypeName = "char(2)")]
        public string Abbreviation { get; set; }

        #region Navigation Properties

        public List<City> Cities { get; set; }
        public Country Country { get; set; }

        #endregion
    }
}
