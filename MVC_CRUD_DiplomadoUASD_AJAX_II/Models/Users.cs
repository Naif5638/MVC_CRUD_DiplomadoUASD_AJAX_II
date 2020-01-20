using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_CRUD_DiplomadoUASD_AJAX_II.Models
{
    public class Users
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "El nombre debe contener entre {2} y {0} caracteres", MinimumLength = 3)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "El Apellido debe contener entre {2} y {0} caracteres", MinimumLength = 3)]
        public string Apellidos { get; set; }

        [Required]
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        public virtual string ConfirmPassword { get; set; }
    }
}