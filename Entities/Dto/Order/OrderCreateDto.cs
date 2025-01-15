namespace Entities.Dto.Order
{
    public class OrderCreateDto
    {
        public required string ServiceId { get; set; } = "";
        public required string Description { get; set; } = "";
        public required DateTime DueDate { get; set; }
        public required string Address { get; set; } = "";
        public required string PhoneNumber { get; set; } = "";
        public required string Email { get; set; } = "";
    }
}
