using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Models
{
    [Table("Client")]

    public class Client
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? clientID { get; set; }

        [Required(ErrorMessage = "The client first name is required")]
        [DisplayName("Client First Name")]
        [StringLength(30)]
        public String firstName { get; set; }

        [Required(ErrorMessage = "The client last name is required")]
        [DisplayName("Client Last Name")]
        [StringLength(30)]
        public String lastName { get; set; }

        [Required(ErrorMessage = "The address is required")]
        [DisplayName("Client Address")]
        [StringLength(30)]
        public String address { get; set; }

        [Required(ErrorMessage = "The city is required")]
        [DisplayName("City")]
        [StringLength(30)]
        public String city { get; set; }

        [Required(ErrorMessage = "The state is required")]
        [DisplayName("State")]
        [StringLength(30)]
        public String state { get; set; }

        [Required(ErrorMessage = "The zip is required")]
        [DisplayName("Zip Code")]
        [StringLength(5, MinimumLength = 5)]
        public String zip { get; set; }

        [Required(ErrorMessage = "The client phone number is required")]
        [DisplayName("Client Phone Number")]
<<<<<<< HEAD
=======
        [StringLength(30)]
>>>>>>> a19b5e53ebe8825cf3822cfdd7ddb9dc8e450eba
        [RegularExpression(@"^\(\d{3}\)\s?\d{3}[-]\d{4}$", ErrorMessage = "Please format phone number (XXX)XXX-XXXX")]
        public String phone { get; set; }

        [Required(ErrorMessage = "The client email is required")]
        [DisplayName("Client Email")]
        [StringLength(30)]
        [EmailAddress]
        public String email { get; set; }

    }
}