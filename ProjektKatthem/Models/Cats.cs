using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektKatthem.Models
{
    public class Cats
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Breed { get; set; }
        [Display(Name = "Bildnamn")]
        public string? ImgName { get; set; }
        public string? Adopted { get; set; }
        [DataType(DataType.Date)]
        public DateTime Registered { get; set; }

        [NotMapped]
        [Display(Name = "Ladda upp bild")]
        public IFormFile? ImgFile { get; set; }
    }

    public class Adopt
    {
        public int AdoptId { get; set; }
        public string? AdoptName { get; set; }
        public string? Email { get; set; }
        public int? Number { get; set; }

        [DataType(DataType.Date)]
        public DateTime Pickup { get; set; }

        public int? CatsId { get; set; }
        public Cats? Cats { get; set; }


    }
}
