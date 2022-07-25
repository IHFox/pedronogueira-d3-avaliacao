using pedronogueira_d3_avaliacao.Interfaces;
using pedronogueira_d3_avaliacao.Models;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;

namespace pedronogueira_d3_avaliacao.Repositories
{
    /// <summary>
    /// Repositório responsável pela manipulação da entidade usuário
    /// </summary>
    internal class UserRepository : IUser
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source = Nome do servidor
        /// initial catalog = Nome do banco de dados
        /// integrated security=true = Faz a autenticação com o usuário do sistema
        /// </summary>
        private readonly string stringConexao = "Data source=localhost\\SQLEXPRESS; initial catalog=pedronogueira-d3-avaliacao; integrated security=true;";

        public publicUser UserConnect(string login, string password)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelect = $"SELECT user_name, user_password, user_id FROM Users WHERE (user_email='{login}' AND user_password='{password}')";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new(querySelect, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        // Retorna usuário público
                        while (rdr.Read())
                        {
                            publicUser user = new() {
                            // Atribui à propriedade nome o valor da coluna "user_id" da tabela do banco de dados
                            IdUser = Guid.Parse((string)rdr["user_id"]),
                            
                            // Atribui à propriedade nome o valor da coluna "user_name" da tabela do banco de dados
                            Name = rdr["user_name"].ToString()
                            };

                            return user;
                        }
                        return null;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
