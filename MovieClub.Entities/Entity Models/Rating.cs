using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieClub.Entities.Helpers;

namespace MovieClub.Entities
{
    public class Rating : IIdEntity
    {
        public Rating(string movieId, string text, int rate)
        {
            Id = Guid.NewGuid().ToString();
            MovieId = movieId;
            Text = text;
            Rate = rate;
        }

        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [StringLength(50)]
        public string MovieId { get; set; }

        [NotMapped]
        public virtual Movie? Movie { get; set; }

        [StringLength(200)]
        public string Text { get; set; }

        [Range(1,5)]
        public int Rate { get; set; }

    }
}
