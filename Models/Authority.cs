using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prospectos.Models
{
    public class Authority
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int nAuthority { get; set; }
        public string name { get; set; }
    }
}
