using muchos_motors_api.Models;
using System;
using System.Collections.Generic;

namespace muchos_motors_api.Invoice
{
    public class InvoiceModel
    {
        public int InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }

        public AddressInvoiceModel SellerAddress { get; set; }
        public AddressInvoiceModel CustomerAddress { get; set; }

        public List<OrderItemInvoiceModel> Items { get; set; }
        public string Comments { get; set; }
    }

    public class OrderItemInvoiceModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class AddressInvoiceModel
    {
        public string CompanyName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}