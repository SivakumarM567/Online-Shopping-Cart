﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Pass { get; set; }
    }
}
