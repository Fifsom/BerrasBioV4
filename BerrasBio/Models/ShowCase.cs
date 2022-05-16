namespace BerrasBio.Models
{
    public class ShowCase
    {
        public int Id { get; set; }
        public DateTime Starts { get; set; }
        public int AvailableSeats { get; set; }
        public virtual Movie? Movie { get; set; }
        public int? MovieId { get; set; }
        public virtual Salon? Salon { get; set; }
        public int? SalonId { get; set; }
    }
}
