using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VinylStore.ViewModels.Users
{
    public class EditVM
    {
        public int Id { get; set; }

        [DisplayName("Никнейм: ")]
        [Required(ErrorMessage = "Полето е задължително!")]
        public string Username { get; set; }

        [DisplayName("Парола: ")]
        [Required(ErrorMessage = "Полето е задължително!")]
        public string Password { get; set; }

        [DisplayName("Име: ")]
        [Required(ErrorMessage = "Полето е задължително!")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия: ")]
        [Required(ErrorMessage = "Полето е задължително!")]
        public string LastName { get; set; }
    }
}