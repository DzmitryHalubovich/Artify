﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Artify.WEB.Models
{
    public class AuthorProfile
    {
        [Key]
        public Guid AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]

        public string Name { get; set; }

        public string Profession { get; set; }

        public string City { get; set; }

        public string Country { get; set; }


    }
}
