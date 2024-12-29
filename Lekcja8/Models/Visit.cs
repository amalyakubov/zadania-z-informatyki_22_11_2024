namespace Lekcja8.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int AnimalId { get; set; }
        public string VisitDescription { get; set; }
        public float Price { get; set; }
    }
}
