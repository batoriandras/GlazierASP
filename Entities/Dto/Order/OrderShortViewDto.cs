using Entities.Models;

namespace Entities.Dto.Order
{
    internal class OrderShortViewDto
    {
        public Models.Service Service { get; set; }
        public string Description { get; set; } = "";
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string Address { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
    }
}
