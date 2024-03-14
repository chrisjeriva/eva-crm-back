namespace Prospectos.Models
{
    public class Sort
    {
        public string property { get; set; } = string.Empty;
        public string direction { get; set; } = "DESC";
        public Sort(string sort) 
        {
            if (sort != null)
            {
                this.property = sort.Split(',')[0];
                this.direction = sort.Split(",")[1];
            }
        }
    }
    public class Parameters
    {
        public int page { get; set; }
        public int size { get; set; }
        public Sort sort { get; set; } = new Sort("nProspecto,DESC");
    }
    
}
