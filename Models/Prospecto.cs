using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prospectos.Models
{
    public class Prospecto
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int nProspecto { get; set; }
        public string cNombre { get; set; }
        public string cApellidoPaterno { get; set; }
        public string cApellidoMaterno { get; set; }
        public string cCalle { get; set; }
        public string cNoExt { get; set; }
        public string cColonia { get; set; }
        public string cCodigoPostal { get; set; }
        public string cTelefono { get; set; }
        public string cRFC { get; set; }
        public int nEstatus { get; set; }

        [ForeignKey("nEstatus")]
        public Estatus? Estatus { get; set; }

        [NotMapped]
        public ICollection<DocumentoProspecto>? Documentos { get; set; }

        public bool bActivo { get; set; }

        public string? cObservacionesRechazo { get; set; }
    }
}
