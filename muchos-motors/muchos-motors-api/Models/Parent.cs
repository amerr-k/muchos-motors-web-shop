using System.ComponentModel.DataAnnotations;

namespace muchos_motors_api.Models
{
    public class Parent
    {
        [Key]
        public int ParentId { get; set; }
        public string Name { get; set; }
        public Child? Child => this as Child;

    }
}
