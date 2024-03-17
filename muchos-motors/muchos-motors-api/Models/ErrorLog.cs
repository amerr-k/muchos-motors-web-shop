using System;
using System.ComponentModel.DataAnnotations;

namespace muchos_motors_api.Models
{
    public class ErrorLog
    {
        [Key]
        public int ErrorAuditId { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public string StackTrace { get; set; }
        public int StatusCode { get; set; }

    }
}
