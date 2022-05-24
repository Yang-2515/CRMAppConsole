using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMApplication.Entities
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        [Required]
        public int Id { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int AddressTypeId { get; set; }
        public virtual AddressType AddressType { get; set; }
    }
}
