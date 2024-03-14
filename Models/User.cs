using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prospectos.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int nUsuario { get; set; }
        public string login { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public bool activated { get; set; }
        public string langKey { get; set; }
        public int nAuthority { get; set; }
        [ForeignKey("nAuthority")]
        public Authority? Authority { get; set; }
        public string password { get; set; }
        public string imageUrl { get; set; }
    }
}
