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

                        Console.WriteLine("\nDigite seu nome de usuário:");
                        login = Console.ReadLine();

                        Console.WriteLine("\nDigite sua senha:");
                        password = Console.ReadLine();

                        if (true) // Checar se é um endereço de e-mail
                        {
                            id = _user.UserConnect(login, password); // Acessar banco de dados
                            if (id != "0") // Checar acesso
                            {
                                Console.Clear();
                                Console.WriteLine("\nLogin realizado com sucesso!\n");
                                _log.RegisterConnection(login, id, "logou");

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
                                            Console.WriteLine($"\nUsuário {login} deslogado com sucesso!\n");
                                            _log.RegisterConnection(login, id, "deslogou");
                                            option = "e";
                                            break;

                                        case "e":
                                            Environment.Exit(0);
                                            break;

                                        default:
                                            Console.Clear();
                                            Console.WriteLine("\nOpção inválida!\n");
                                            break;
                                    }
                                } while (option != "e");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("\nUsuário ou senha inválidos!\n");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\nDigite um endereço de e-mail válido!\n");
                        }
                        break;

                    case "c":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("\nOpção inválida!\n");
                        break;
                }

            } while (option != "c");
        }
    }
}