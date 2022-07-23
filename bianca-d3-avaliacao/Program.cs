using AtividadeAutenticacao.Controllers;
using AtividadeAutenticacao.Models;

namespace AtividadeAutenticacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserController controller = new();
            User userLogged = null;
            string option;

            do
            {
                Console.WriteLine("1 - acessar ");
                Console.WriteLine("2 - cancelar ");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("digite o e-mail");
                        string email = Console.ReadLine();
                        Console.WriteLine("digite a senha");
                        string pass = Console.ReadLine();
                        userLogged = controller.login(email, pass);
                        if(userLogged != null)
                        {
                            Console.WriteLine($"Bem-vindo, {userLogged.Name}!...");
                            string option2;
                            do
                            {
                                Console.WriteLine("1 - deslogar \n");
                                Console.WriteLine("2 - encerrar sistema \n");

                                option2 = Console.ReadLine();

                                switch (option2)
                                {
                                    case "1":
                                        Console.WriteLine($"Até breve, {userLogged.Name}!...");
                                        if (controller.logout(userLogged))
                                        {
                                            userLogged = null;
                                        }
                                        break;
                                    case "2":
                                        return;
                                }
                            } while (option2 != "1" && option2 != "2");
                        }
                        else
                        {
                            Console.WriteLine("E-mail ou senha incorretos \n");
                        }
                        break;

                    case "2":
                        return;
                }

            } while ((option != "1" && option != "2") || userLogged == null);
        }
    }
}