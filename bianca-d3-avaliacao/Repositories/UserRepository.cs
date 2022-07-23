using AtividadeAutenticacao.Models;
using System.Data.SqlClient;

namespace AtividadeAutenticacao.Repositories
{
    internal class UserRepository
    {

        private readonly string connectionString = "Data source=DESKTOP-GC7NJRR\\SQLEXPRESS; initial catalog=bianca_d3_avaliacao; user id=sa; pwd=ifsp";

        public User GetUserByEmailAndPass(string email, string pass)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string querySelectAll = "SELECT Id, Name, Email, Password FROM [user] where Email = @Email and Password = @Pass;";

                using (SqlCommand cmd = new(querySelectAll, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Pass", pass);
                    con.Open();

                    SqlDataReader rdr;

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        User user = new()
                        {
                            Id = int.Parse(rdr[0].ToString()),
                            Name = rdr["Name"].ToString(),
                            Email = rdr["Email"].ToString(),
                            Password = rdr["Password"].ToString()
                        };
                        return user;
                    }
                }
            }

            return null;
        }
    }
}
