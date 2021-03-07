using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace DesafioCSharp_Teylor.Models
{
    public class UserDAL
    {
        public const string CONNECTION_STRING = "server=localhost;user id=root;persistsecurityinfo=True;database=test;allowuservariables=True;pwd=Godsnotdead146";

        MySqlConnection conn = new MySqlConnection(CONNECTION_STRING);

        MySqlCommand cmd = new MySqlCommand();

        //Criação
        public string Insert(User user)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO user(Name, Birthdate, CPF, Address, City) values(@Name, @Birthdate, @CPF, @Address, @City)";
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Birthdate", user.Birthdate);
            cmd.Parameters.AddWithValue("@CPF", user.CPF);
            cmd.Parameters.AddWithValue("@Address", user.Address);
            cmd.Parameters.AddWithValue("@City", user.City);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Usuário cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    Console.WriteLine(ex.Message);
                    return ("Usuário já cadastrado.");
                }
                else
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.InnerException);
                    return ("Erro no Banco de dados. Contate o administrador.");
                }
            }
            finally
            {
                conn.Dispose();
            }
        }
        //Edição
        public string Edit(User user)
        {
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE user set Name = @Name,Birthdate = @Birthdate,CPF = @CPF,Address = @Address,City = @City WHERE id = @id";
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Birthdate", user.Birthdate);
            cmd.Parameters.AddWithValue("@CPF", user.CPF);
            cmd.Parameters.AddWithValue("@Address", user.Address);
            cmd.Parameters.AddWithValue("@City", user.City);
            cmd.Parameters.AddWithValue("@id", user.id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Usuário atualizado com sucesso!";
            }
            catch (Exception)
            {
                return ("Erro no Banco de dados. Contate o administrador.");
            }
            finally
            {
                conn.Dispose();
            }
        }
        //Exclusão
        public string Delete(User user)
        {
            cmd.Connection = conn;
            cmd.CommandText = "DELETE From user WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", user.id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Usuário deletado com sucesso!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return ("Erro no Banco de dados. Contate o administrador.");
            }
            finally
            {
                conn.Dispose();
            }
        }
        //Listagem
        public List<User> GetAll()
        {
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * From User";

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<User> users = new List<User>();

                while (reader.Read())
                {
                    User temp = new User();

                    temp.id = Convert.ToInt32(reader["Id"]);
                    temp.Name = Convert.ToString(reader["Name"]);
                    temp.Birthdate = Convert.ToDateTime(reader["Birthdate"]); /*Rever*/
                    temp.CPF = Convert.ToString(reader["CPF"]);
                    temp.Address = Convert.ToString(reader["Address"]);
                    temp.City = Convert.ToString(reader["City"]);

                    users.Add(temp);
                }

                return users;
            }
            catch (Exception)
            {
                throw new Exception("Erro no Banco de dados. Contate o administrador.");
            }
            finally
            {
                conn.Dispose();
            }

        }
    }
}

