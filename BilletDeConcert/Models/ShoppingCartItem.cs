﻿using System.ComponentModel.DataAnnotations;

namespace BilletDeConcert.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Concert Concert{ get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }

    }
}
