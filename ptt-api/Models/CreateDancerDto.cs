﻿using System.ComponentModel.DataAnnotations;

namespace ptt_api.Models
{
    public class CreateDancerDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string Danceclass { get; set; }
        public int NumberofPoints { get; set; }
        [Phone]
        public string ContactNumber { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        public int DanceClubId { get; set; }

    }
}
