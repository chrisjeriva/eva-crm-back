using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prospectos.Models
{
    public class Account
    {
        public bool activated { get; set; }
        public List<string>? authorities { get; set; }
        public string? email { get; set; }
        public string? firstName { get; set; }
        public string? langKey { get; set; }
        public string? lastName { get; set; }
        public string? login { get; set; }
        public string? imageUrl { get; set; }
    }
    
}
