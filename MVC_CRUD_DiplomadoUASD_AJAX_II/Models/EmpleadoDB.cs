﻿using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_CRUD_DiplomadoUASD_AJAX_II.Models
{
    public class EmpleadoDB
    {
        string cs = ConfigurationManager.ConnectionStrings["ConnectionStrDB"].ConnectionString;

        public List<Empleado> ListAll()
        {
            List<Empleado> lst = new List<Empleado>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand command = new SqlCommand("SelectEmpleado", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lst.Add(new Empleado
                    {
                        EmpleadoID = Convert.ToInt32(reader["EmpleadoID"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        Edad = Convert.ToInt32(reader["Edad"]),
                        Estado_Civil = reader["Estado_Civil"].ToString(),
                        Pais = reader["Pais"].ToString(),
                    });
                }
                return lst;
            }
        }

        public int Add(Empleado empleado)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand command = new SqlCommand("InsertUpdateEmpleado", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", empleado.EmpleadoID);
                command.Parameters.AddWithValue("@Nombres", empleado.Nombres);
                command.Parameters.AddWithValue("@Apellidos", empleado.Apellidos);
                command.Parameters.AddWithValue("@Edad", empleado.Edad);
                command.Parameters.AddWithValue("@Estado_Civil", empleado.Estado_Civil);
                command.Parameters.AddWithValue("@Pais", empleado.Pais);
                command.Parameters.AddWithValue("@Action", "Insert");

                i = command.ExecuteNonQuery();
            }
            return i;
        }

        //Metodo para 
        public int Update(Empleado empleado)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand command = new SqlCommand("InsertUpdateEmpleado", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", empleado.EmpleadoID);
                command.Parameters.AddWithValue("@Nombres", empleado.Nombres);
                command.Parameters.AddWithValue("@Apellidos", empleado.Apellidos);
                command.Parameters.AddWithValue("@Edad", empleado.Edad);
                command.Parameters.AddWithValue("@Estado_Civil", empleado.Estado_Civil);
                command.Parameters.AddWithValue("@Pais", empleado.Pais);
                command.Parameters.AddWithValue("@Action", "Update");

                i = command.ExecuteNonQuery();
            }
            return i;
        }

        public int Delete(int id)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand command = new SqlCommand("DeleteEmpleado", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);
                i = command.ExecuteNonQuery();
            }
            return i;
        }

        public int InsertUser(Users user)
        {
            int i;
            using(SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand command = new SqlCommand("InsertUpdateUser", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", user.UserId);
                command.Parameters.AddWithValue("@Nombres", user.Nombres);
                command.Parameters.AddWithValue("@Apellidos", user.Apellidos);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Action", "Insert");

                i = command.ExecuteNonQuery();
            }
            return i;
        }

        public int UpdateUser(Users user)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand command = new SqlCommand("InsertUpdateUser", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Nombres", user.Nombres);
                command.Parameters.AddWithValue("@Apellidos", user.Apellidos);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@Action", "Update");

                i = command.ExecuteNonQuery();
            }
            return i;
        }

        public List<Users> Users()
        {
            List<Users> users = new List<Users>();
            using(SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Select * from Users", connection);
                command.CommandType = System.Data.CommandType.Text;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new Users
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        UserName = reader["UserName"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }
            }
            return users;
        }

        public Users User(int userId)
        {
            Users user = new Users();
            using(SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Users"
                    + "WHERE UserId = @userId", connection);
                command.Parameters.AddWithValue("@userId", userId);
                command.CommandType = System.Data.CommandType.Text;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user.UserId = Convert.ToInt32(reader["UserId"].ToString());
                    user.Nombres = reader["Nombres"].ToString();
                    user.Apellidos = reader["Apellidos"].ToString();
                    user.UserName = reader["UserName"].ToString();
                    user.Email = reader["Email"].ToString();
                }
            }


            return user;
        }
    }
}