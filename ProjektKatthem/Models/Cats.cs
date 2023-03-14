using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektKatthem.Models
{
    public class Cats
    {
        public int Id { get; set; }
        [Display(Name = "Namn")]
        public string? Name { get; set; }
        [Display(Name = "Ålder")]
        public int? Age { get; set; }
        [Display(Name = "Kattras")]
        public string? Breed { get; set; }
        [Display(Name = "Bildnamn")]
        public string? ImgName { get; set; }


        //Plockar upp partial från display templates för att skrivas ut som vald text ist för true/false
        [UIHint("IsTrue")]
        public bool? Adopted { get; set; }
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

        public bool? CatsAdopted { get; set; }
        public Cats? Cats { get; set; }


    }
}
