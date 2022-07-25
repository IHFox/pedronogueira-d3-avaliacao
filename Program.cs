using pedronogueira_d3_avaliacao.Models;
using pedronogueira_d3_avaliacao.Repositories;

namespace pedronogueira_d3_avaliacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserRepository _user = new();

            LogRepository _log = new();

            string option;
            Console.WriteLine("\n\n");

            do
            {
                // --------------------------------------------------
                // Tela inicial
                // --------------------------------------------------
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("\ta - Acessar");
                Console.WriteLine("\tc - Cancelar");

                option = Console.ReadLine().ToLower();

                switch (option)
                {
                    case "a":
                        string id;
                        string login;
                        string password;
                        publicUser user = new();

                        Console.WriteLine("\nDigite seu nome de usuário:");
                        login = Console.ReadLine();

                        if (_user.IsValidEmail(login)) // Checar se é um endereço de e-mail
                        {

                            Console.WriteLine("\nDigite sua senha:");
                            password = Console.ReadLine();


                            user = _user.UserConnect(login, password); // Acessar banco de dados
                            if (user != null) // Checar acesso
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\nLogin realizado com sucesso!\n");
                                Console.ResetColor();
                                _log.RegisterConnection(user.Name, user.IdUser, "logou");

                                do
                                {
                                    // --------------------------------------------------
                                    // Tela após login
                                    // --------------------------------------------------
                                    Console.WriteLine("Escolha uma opção:");
                                    Console.WriteLine("\td - Deslogar");
                                    Console.WriteLine("\te - Encerrar sistema");

                                    option = Console.ReadLine().ToLower();

                                    switch (option)
                                    {
                                        case "d":
                                            Console.Clear();
                                            Console.WriteLine($"\nUsuário {user.Name} deslogado com sucesso!\n");
                                            _log.RegisterConnection(user.Name, user.IdUser, "deslogou");
                                            option = "e";
                                            break;

                                        case "e":
                                            Environment.Exit(0);
                                            break;

                                        default:
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\nOpção inválida!\n");
                                            Console.ResetColor();
                                            break;
                                    }
                                } while (option != "e");
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nUsuário ou senha inválidos!\n");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nDigite um endereço de e-mail válido!\n");
                            Console.ResetColor();
                        }
                        break;

                    case "c":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpção inválida!\n");
                        Console.ResetColor();
                        break;
                }

            } while (option != "c");
        }
    }
}