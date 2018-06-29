using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhoneAPP.Models
{
    public class PhoneBook
    {
        [Key]
        [Required(ErrorMessage = "Check field.")]
        public int clientID { get; set; }
        [Required(ErrorMessage = "Check field.")]
        public string clientName { get; set; }
        [Required(ErrorMessage = "Check field.")]
        public string clientSurname { get; set; }
        [Required(ErrorMessage = "Check field.")]
        public string clientPID { get; set; }
        [Required(ErrorMessage = "Check field.")]
        public string clientCity { get; set; }
        [Required(ErrorMessage = "Check field.")]
        public string clientStreet { get; set; }
        [Required(ErrorMessage = "Check field.")]
        public int clientNumber { get; set; }
        [Required(ErrorMessage = "Check field.")]
        public string clientPostalCode { get; set; }
        [Required(ErrorMessage = "Check field.")]
        public string clientPhoneNumber { get; set; }


    }

    public class PhoneBookDBC : DbContext
    {
        public PhoneBookDBC() : base("PhoneBookDB")
        { }
        public DbSet<PhoneBook> clientsList { get; set; }

    }
}
