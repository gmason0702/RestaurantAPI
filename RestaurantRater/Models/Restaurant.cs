using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class Restaurant
    {
        [Key]//sets primary key
        public int Id { get; set; }

        [Required]
        public string Style { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0d,5d)]
        public double Rating { get; set; }

        [Required]
        [Range(1,5)]
        public int DollarSigns { get; set; }

    }
}