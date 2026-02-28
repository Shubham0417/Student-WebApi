namespace MediatRwebApiASPCorewithEF.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string HouseNo { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string IsPermanent { get; set; }
        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
