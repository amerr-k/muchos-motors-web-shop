using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerShippingAddress { get; set; }
        public string CustomerPhone { get; set; }
        public int? CustomerShippingCityId { get; set; }
        [ForeignKey("CustomerShippingCityId")]
        public City CustomerShippingCity { get; set; }
        public int? EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippingDate { get; set; }
        public DateTime? InvoiceCreatedDate { get; set; }
        public bool InvoiceCreated { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public bool IsValid { get; set; }

    }
}
