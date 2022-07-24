using pedronogueira_d3_avaliacao.Models;
using pedronogueira_d3_avaliacao.Repositories;

namespace pedronogueira_d3_avaliacao
{
    internal class Program
    {

        private const string path = "database/log.txt";

        static void Main(string[] args)
        {
            UserRepository _user = new();

            LogRepository _log = new();

            string option;

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
                                Console.WriteLine("\nLogin realizado com sucesso!\n");
                                _log.RegisterAccess(login, id);

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
                                            Console.WriteLine($"\nUsuário {login} deslogado com sucesso!\n");
                                            option = "e";
                                            break;

                                        case "e":
                                            Environment.Exit(0);
                                            break;

                                        default:
                                            Console.WriteLine("\nOpção inválida!\n");
                                            break;
                                    }
                                } while (option != "e");
                            }
                            else
                            {
                                Console.WriteLine("\nUsuário ou senha inválidos!\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nDigite um endereço de e-mail válido!\n");
                        }
                        break;

                    case "c":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida!\n");
                        break;
                }

            } while (option != "c");
        }
    }
}