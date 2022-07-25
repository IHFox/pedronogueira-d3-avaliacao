using System.Globalization;
using System.Text.RegularExpressions;

namespace pedronogueira_d3_avaliacao.Repositories
{
    internal class SecurityRepository
    {
        /// <summary>
        /// Verifica se o e-mail digitado é um e-mail válido (possui @ e .)
        /// </summary>
        /// <param name="email">E-mail a ser verificado</param>
        /// <returns>True caso o parâmetro email seja um e-mail válido</returns>
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normaliza o domínio
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examina a parte de domínio do e-mail e normaliza ela
                string DomainMapper(Match match)
                {
                    // Usa classe IdnMapping para converter nomes de domínio em Unicode
                    var idn = new IdnMapping();

                    // Pega e processa o nome de domínio (dispara ArgumentException quando inválido)
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

        /// <summary>
        /// Esconde a senha quando a mesma está sendo escrita no console com *
        /// </summary>
        /// <returns>Senha digitada como "plain text"</returns>
        public string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        // Remove um caracter da lista de caracteres da senha
                        password = password.Substring(0, password.Length - 1);
                        // Pega a posição do cursor
                        int pos = Console.CursorLeft;
                        // Move o cursor para a esqurda por um caracter
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // Substitui com espço
                        Console.Write(" ");
                        // Move o cursor para a esquerda por um caracter de novo
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            // Adiciona uma nova linha pois o usuário pressionou enter no fim de sua senha
            Console.WriteLine();
            return password;
        }

        /// <summary>
        /// Geração da Hash com o BCrypt
        /// </summary>
        /// <param name="password">senha em formato "plain text"</param>
        /// <returns>Senha em formato Hash</returns>
        public string HashGeneration(string password)
        {
            int workfactor = 10; // 2^10 = 1024 iterações

            string salt = BCrypt.Net.BCrypt.GenerateSalt(workfactor);
            string hash = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hash;
        }

        /// <summary>
        /// Comparação de hash com senha em "plain text"
        /// </summary>
        /// <param name="hash">senha em formato hash</param> 
        /// <param name="password">senha em formato "plain text"</param> 
        /// <returns>True caso a senha em formato "plain text" seja verificada com a senha em formato hash</returns>
        public bool PasswordCompare(string hash, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
