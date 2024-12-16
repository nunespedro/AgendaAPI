using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaAPI.Domain.Model
{
    public class Contact
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? Phone { get; set; }

        public Contact(string name, string email, string phone)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Phone = phone;
        }
    }
}
