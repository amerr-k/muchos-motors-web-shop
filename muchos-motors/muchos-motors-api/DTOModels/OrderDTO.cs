using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.DTOModels
{
    [NotMapped]
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public List<OrderItemDTO> OrderItems {get; set; }
        //public CustomerDTO Customer { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerShippingAddress { get; set; }
        public string CustomerPhone { get; set; }
        public int? CustomerShippingCityId { get; set; }
        public CityDTO? CustomerShippingCity { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippingDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool InvoiceCreated { get; set; }

    }
}
