namespace pedronogueira_d3_avaliacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                        string login;
                        string password;

                        Console.WriteLine("\nDigite seu e-mail:");
                        login = Console.ReadLine();

                        Console.WriteLine("\nDigite sua senha:");
                        password = Console.ReadLine();

                        if (true) // Checar se é um endereço de e-mail
                        {
                            if (true) // Checar acesso com banco de dados
                            {
                                Console.WriteLine("\nLogin realizado com sucesso!\n");

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
                                            Console.WriteLine("\nUsuário {login} deslogado com sucesso!\n");
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