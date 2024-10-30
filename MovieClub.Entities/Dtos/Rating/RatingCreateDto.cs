using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClub.Entities.Dtos.Rating
{
    public class RatingCreateDto
    {
        public required string MovieId { get; set; } = "";

        [MinLength(10)]
        [MaxLength(500)]
        public required string Text { get; set; } = "";
        
        [Range(1,5)]
        public required int Rate { get; set; }

    }
}
