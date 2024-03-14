namespace Prospectos.Models
{
    public class PaginationTable
    {
        public IEnumerable<dynamic> results { get; set; }
        public int count { get; set; }
    }
}
