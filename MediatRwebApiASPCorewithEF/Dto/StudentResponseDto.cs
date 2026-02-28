namespace MediatRwebApiASPCorewithEF.Dto
{
    public class StudentResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Standard { get; set; }
        public List<AddressResponseDto> Addresses { get; set; }
    }

}
