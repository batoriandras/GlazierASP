using Entities.Models;

namespace Entities.Dto.Order
{
    public class OrderUpdateDto
    {
        public required OrderStatus Status { get; set; } = OrderStatus.Pending;
    }
}
