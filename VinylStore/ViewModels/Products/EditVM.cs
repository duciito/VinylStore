using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VinylStore.Entities;

namespace VinylStore.ViewModels.Products
{
    public class EditVM
    {
        public int Id { get; set; }

        [DisplayName("Жанр")]
        [Required(ErrorMessage = "Полето е задължително!")]
        public int GenreId { get; set; }

        [DisplayName("Артист/група")]
        [Required(ErrorMessage = "Полето е задължително!")]
        public string Artist { get; set; }

        [DisplayName("Заглавие")]
        [Required(ErrorMessage = "Полето е задължително!")]
        public string Title { get; set; }

        [DisplayName("Цена")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Полето е задължително!")]
        public decimal Price { get; set; }

        [DisplayName("Път към снимка")]
        [Required(ErrorMessage = "Полето е задължително!")]
        public string VinylImgPath { get; set; }

        [DisplayName("Промоция")]
        [Required(ErrorMessage = "Полето е задължително!")]
        public bool OnSale { get; set; }

        public SelectList Genres { get; set; }
        public IDictionary<bool, string> Options { get; set; }

        public EditVM()
        {
            Options = new Dictionary<bool, string>();
            Options.Add(false, "Не");
            Options.Add(true, "Да");
        }
    }
}