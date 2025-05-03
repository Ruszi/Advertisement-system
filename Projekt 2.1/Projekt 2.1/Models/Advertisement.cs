using System;
using System.ComponentModel.DataAnnotations;

//  OgŁoszenia 
namespace Projekt_2._1.Models
{
    public class Advertisement
    {
        // Identyfikator ogłoszenia
        public int Id { get; set; }

        // Tytuł ogłoszenia (wymagany)
        [Required]
        public string Title { get; set; }

        // Data dodania ogłoszenia
        public DateTime DateAdded { get; set; } = DateTime.Now;

        // Id mieszkania, z którym powiązane jest ogłoszenie
        public int ApartmentId { get; set; }

        // Powiązane mieszkanie
        public Apartment Apartment { get; set; }
    }
}
