using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.Models
{
    public class AuthenticationCode
    {
        [Key]
        public int AuthenticationCodeId { get; set; }
        public int Code { get; set; }
        public DateTime TimeSent { get; set; }
        
        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public bool isValid { get; set; }
    }
}
