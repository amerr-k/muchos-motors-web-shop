using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.Models
{
    public class Appointment
    {
        
        [Key]
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentTimeStart { get; set; }
        public DateTime AppointmentTimeEnd { get; set; }
        public string Description { get; set; }
        public bool IsAuthorized { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public bool IsValid { get; set; }

    }
}
