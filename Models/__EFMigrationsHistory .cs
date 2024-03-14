using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prospectos.Models
{
    public class __EFMigrationsHistory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MigrationId { get; set; }
        public string ProductVersion { get; set; }
    }
}
