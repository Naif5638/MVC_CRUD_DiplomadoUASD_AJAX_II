using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_CRUD_DiplomadoUASD_AJAX_II.Models
{

    public class UserLogin
    {
        string cs = ConfigurationManager.ConnectionStrings["ConnectionStrDB"].ConnectionString;

        [EmailAddress]
        [Required(ErrorMessage = "El email es requerido")]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "El numero de {0} debe ser al menos {2}", MinimumLength = 3)]
        [Required(ErrorMessage = "El password es requerido")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        public string UserName { get; set; }

        public bool Login()
        {
            Users user = new Users();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand("select * from Users" +
                    "Where Email = @email AND Password = @password", con);
                command.Parameters.AddWithValue("@email", Email);
                command.Parameters.AddWithValue("@password", Password);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user.UserId = Convert.ToInt32(reader["UserId"].ToString());
                    user.Nombres = reader["Nombres"].ToString();
                    user.Apellidos = reader["Apellidos"].ToString();
                    user.UserName = reader["UserName"].ToString();
                    user.Email = Email;                    
                }              
            }

            if (user != null)
            {
                return true;
            }
            else
                return false;
        }
    }
}