namespace MediatRwebApiASPCorewithEF.Dto
{
    public class StudentCreateDto
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Standard { get; set; }

        public AddressDto PermanentAddress { get; set; }
        public AddressDto TemporaryAddress { get; set; }
    }

}
