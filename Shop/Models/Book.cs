using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Shop.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Display(Name = "Tytuł")]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Display(Name = "Data Wydania")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Cena")]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Autor")]
        [StringLength(60, MinimumLength = 3)]
        public string Author { get; set; }

        [Display(Name = "Wydawnictwo")]
        [StringLength(60, MinimumLength = 3)]
        public string PublishingHouse { get; set; }

        public TypeOfBook TypeOfBook { get; set; }

        public Storage Storage { get; set; }

        [Required]
        public bool GreatDeal { get; set; }
    }
}