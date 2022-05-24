using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMApplication.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        [Required]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        /// <summary>
        /// Ngày tạo dữ liệu
        /// </summary>
        public DateTimeOffset CreatedAt { set; get; }
        /// <summary>
        /// Ngày cập nhật dữ liệu
        /// </summary>
        public DateTimeOffset? UpdatedAt { set; get; }
        public bool IsDelete { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public override string ToString()
        {
            return "Name: " + Name + ", Gender: " + Gender;
        }
        public void Show()
        {
            Console.WriteLine("Customer");
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Gender: " + Gender);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("\n");
        }
    }
}
