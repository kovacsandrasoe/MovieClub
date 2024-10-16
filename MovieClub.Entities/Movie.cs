using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieClub.Entities
{
    public class Movie
    {
        public Movie(string title, string genre)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Genre = genre;
        }

        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Genre { get; set; }

        [NotMapped]
        public virtual ICollection<Rating>? Ratings { get; set; }

    }
}
