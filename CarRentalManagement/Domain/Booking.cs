namespace CarRentalManagement.Domain
{
    public class Booking : BaseDomainModel
    {
        public DateTime Dateout { get; set; }
        public DateTime Datein { get; set; }
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
    }
}