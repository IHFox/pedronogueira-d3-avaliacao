using pedronogueira_d3_avaliacao.Interfaces;
using pedronogueira_d3_avaliacao.Models;
using System.Text;

namespace pedronogueira_d3_avaliacao.Repositories
{
    internal class LogRepository : ILog
    {
        private const string path = "database\\log.txt";
        private readonly FileStream fileStream;

        public LogRepository()
        {
            CreateFolderAndFile(path);
            this.fileStream = File.OpenWrite(path);
        }

        public static void CreateFolderAndFile(string path)
        {
            string folder = path.Split("\\")[0];
            try {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                if (!File.Exists(path))
                {
                    File.Create(path);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro na criação: {0}", e.ToString());
            }
        }
        private static string PrepareLine(string name, string id)
        {
            return $"O usuário {name} ({id}) acessou o sistema às {DateTime.Now.TimeOfDay} do dia {DateTime.Now.Date}.\n";
        }

        public void RegisterAccess(string name, string id)
        {
            string line = PrepareLine(name, id);
            byte[] info = new UTF8Encoding(true).GetBytes(line);
            Console.WriteLine("Passou por aqui");
            fileStream.Write(info);
        }
    }
}
