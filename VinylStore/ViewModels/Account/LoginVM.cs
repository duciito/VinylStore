using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VinylStore.ViewModels.Account
{
    public class LoginVM
    {
        [DisplayName("Никнейм")]
        [Required(ErrorMessage = "Това поле е задължително!")]
        public string Username { get; set; }

        [DisplayName("Парола")]
        [Required(ErrorMessage = "Това поле е задължително!")]
        public string Password { get; set; }
    }
}