using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prospectos.Models
{
    public class UserAuthority
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int nUserAuthority { get; set; }
        public int nUser { get; set; }
        public int nAuthority {  get; set; }  
    }
}
