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
        public virtual Users User { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "El email es requerido")]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "El numero de {0} debe ser al menos {2}", MinimumLength = 3)]
        [Required(ErrorMessage = "El password es requerido")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Login()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand command = new SqlCommand("select * from Users" +
                    " Where Email = @email AND Password = @password", con);
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.AddWithValue("@email", Email);
                command.Parameters.AddWithValue("@password", Password);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User = new Users
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        UserName = reader["UserName"].ToString(),
                        Email = Email
                    };

                }
            }
            if (User == null)
            {
                return false;
            }
            else
                return true;
        }
    }
}