using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prospectos.Models
{
    public class DocumentoProspecto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int nDocumentoProspecto { get; set; }
        public int nProspecto { get; set; }
        public string cDocumento { get; set; }
        public string cDocumentoB64 { get; set; }
        public bool bActivo { get; set; }
    }
}
