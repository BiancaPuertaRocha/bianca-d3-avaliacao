using AtividadeAutenticacao.Models;
using AtividadeAutenticacao.Repositories;
using AtividadeAutenticacao.Utils;

namespace AtividadeAutenticacao.Controllers
{
    internal class UserController
    {
        private UserRepository userRepository = new();
        private string path = "database/";


        public User login(string email, string pass)
        {
            User user = userRepository.GetUserByEmailAndPass(email, pass);
            if (user != null)
            {
                string userpath = $"{path}{Convert.ToString(user.Id)}.txt";
                string text = $"User {user.Name} ({user.Id})  logged in at {DateTime.Now}";

                FileManager.CreateFolderAndFile(userpath);
                FileManager.WriteFile(userpath, text);
                return user;
            }
            return null;
        }

        public bool logout(User user)
        {
            if (user != null)
            {
                string userpath = $"{path}{Convert.ToString(user.Id)}.txt";
                string text = $"User {user.Name} ({user.Id})  logged out at {DateTime.Now}";

                FileManager.CreateFolderAndFile(userpath);
                FileManager.WriteFile(userpath, text);
                return true;
            }
            return false;
        }

    }
}
