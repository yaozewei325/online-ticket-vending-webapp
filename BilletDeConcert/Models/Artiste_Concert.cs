namespace BilletDeConcert.Models
{
    public class Artiste_Concert
    {
        public int ConcertId { get; set; }
        public Concert Concert { get; set; }
        public Artiste Artiste{ get; set; }
        public int ArtisteId { get; set; }
    }
}
