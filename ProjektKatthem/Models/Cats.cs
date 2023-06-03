using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektKatthem.Models
{
    public class Cats
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Namn:")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Kön:")]
        //Plockar upp partial från display templates för att skrivas ut som vald text ist för true/false
        [UIHint("HeShe")]
        public bool? Gender { get; set; }

        [Display(Name = "Ålder:")]
        public int? Age { get; set; }


        [Display(Name = "Kattras:")]
        public string? Breed { get; set; }

        [Display(Name = "Bildnamn:")]
        public string? ImgName { get; set; }

        [Display(Name = "Tillgänglighet:")]
        //Plockar upp partial från display templates för att skrivas ut som vald text ist för true/false
        [UIHint("IsTrue")]
        public bool? Adopted { get; set; }


        [Display(Name = "Inskrivningsdatum:")]
        [DataType(DataType.Date)]
        public DateTime Registered { get; set; }

        [NotMapped]
        [Display(Name = "Ladda upp bild:")]
        public IFormFile? ImgFile { get; set; }

        [Display(Name = "Information:")]
        public string? Info { get; set; }

        public Adopt? Adopt { get; set; }
    }

    public class Adopt
    {
        public int AdoptId { get; set; }
        [Display(Name = "Förnamn Efternamn")]
        public string? AdoptName { get; set; }
        [Display(Name = "Epost:")]
        public string? Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefonnummer:")]
        public string? Number { get; set; }

        [Display(Name = "Upphämtnigsdatum:")]

        [DataType(DataType.Date)]
        public DateTime Pickup { get; set; }

        [Display(Name = "Katt:")]
        public int? CatsId { get; set; }

        public bool? CatsAdopted { get; set; }
        public Cats? Cats { get; set; }


    }
}
