using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.Models
{
    public class AuthenticationToken
    {
        public int AuthenticationTokenId { get; set; }
        public string Value { get; set; }

        [ForeignKey(nameof(UserAccountId))]
        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }

        public string? IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsValid { get; set; }
    }
}


