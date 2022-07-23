

namespace AtividadeAutenticacao.Utils
{
    internal class FileManager
    {
        public static void CreateFolderAndFile(string path)
        {
            string folder = path.Split("/")[0]; 

            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

        }
        public static void WriteFile(string path, string text)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(text);
            }
        }
     
    }
}
