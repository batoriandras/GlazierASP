namespace Entities.Models
{
    public enum OrderStatus
    {
        Pending,
        InProgress,
        Completed
    }
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
