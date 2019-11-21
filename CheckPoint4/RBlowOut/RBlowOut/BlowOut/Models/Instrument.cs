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
    [Table("Instrument")]

    public class Instrument
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int? instrumentID { get; set; }

        [Required(ErrorMessage = "The instrument description is required")]
        [DisplayName("Instrument Description")]
        [StringLength(30)]
        public String instrumentDesc { get; set; }

        [Required(ErrorMessage = "The instrument type is required")]
        [DisplayName("Instrument Type")]
        [StringLength(30)]
        public String instrumentType { get; set; }

        [Required(ErrorMessage = "The instrument price required")]
        [DisplayName("Instrument Price")]
        [StringLength(30)]
        public String price { get; set; }

        [Required(ErrorMessage = "The clientID required")]
        [DisplayName("Client ID")]
        public int clientID { get; set; }

    }
}