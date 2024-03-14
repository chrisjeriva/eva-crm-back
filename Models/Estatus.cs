using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prospectos.Models
{
    public class Estatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int nEstatus { get; set; }
        public string cEstatus { get; set; }
        public bool bActivo { get; set; }
    }
}
