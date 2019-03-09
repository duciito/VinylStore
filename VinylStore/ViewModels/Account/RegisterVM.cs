using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VinylStore.ViewModels.Account
{
    public class RegisterVM
    {
        [DisplayName("Никнейм")]
        [Required(ErrorMessage = "Това поле е задължително!")]
        public string Username { get; set; }

        [DisplayName("Име")]
        [Required(ErrorMessage = "Това поле е задължително!")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия")]
        [Required(ErrorMessage = "Това поле е задължително!")]
        public string LastName { get; set; }

        [DisplayName("Парола")]
        [Required(ErrorMessage = "Това поле е задължително!")]
        public string Password { get; set; }
    }
}