﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VinylStore.ViewModels.Account
{
    public class LoginVM
    {
        [Required(ErrorMessage = "This field is required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public string Password { get; set; }
    }
}