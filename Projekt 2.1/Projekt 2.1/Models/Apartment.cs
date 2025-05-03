
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

//Mieszkanie 

namespace Projekt_2._1.Models
{

    public class Apartment
    {
        // Identyfikator mieszkania
        public int Id { get; set; }

        // Adres mieszkania (wymagany)
        [Required]
        public string Address { get; set; }

        // Powierzchnia mieszkania (w zakresie 1 - 1000 m²)
        [Range(1, 1000)]
        public int Area { get; set; }

        // Cena wynajmu
        [Range(0, 1000000)]
        public decimal Price { get; set; }

        // Opis mieszkania
        public string Description { get; set; }

        // Lista ogłoszeń związanych z mieszkaniem
        public List<Advertisement> Advertisements { get; set; }
    }

}
