﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class ShoppingCartItems
    {
        [Key]
        public int Id { get; set; }

        public MovieM Movie { get; set; }
        public int Amount { get; set; }


        public string ShoppingCardId { get; set; }
    }
}
