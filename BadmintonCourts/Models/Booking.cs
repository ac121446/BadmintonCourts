﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BadmintonRentals.Models;

namespace BadmintonCourts.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [ForeignKey("UserID"), Required]
        public int UserID { get; set; }

        [ForeignKey("CourtID"), Required]
        public int CourtID { get; set; }

        public int EquipmentID { get; set; }
 

        [Required(ErrorMessage = "Enter your booking date")]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        [Required(ErrorMessage = "Enter your booking time")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Enter your end time")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public ICollection<Payment> Payments { get; set; }
        public Court Court { get; set; }
        public Equipment Equipment { get; set; }


    }
}
