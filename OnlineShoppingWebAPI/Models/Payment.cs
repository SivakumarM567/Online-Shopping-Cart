﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingWebAPI.Models
{
    public class Payment
    {
        [Key]
        public int Paymentid { get; set; }
        public string PaymentType { get; set; }
        public int? Orderid { get; set; }
        [ForeignKey("Orderid")]
        public Order? Order { get; set; }
        public int? Userid { get; set; }
        [ForeignKey("Userid")]
        public User? User { get; set; }
    }
}