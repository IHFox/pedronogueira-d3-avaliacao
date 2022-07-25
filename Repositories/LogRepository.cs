using pedronogueira_d3_avaliacao.Interfaces;
using System.Text;

namespace pedronogueira_d3_avaliacao.Repositories
{
    internal class LogRepository : ILog
    {
        private const string path = ".\\log.txt";
        private readonly FileStream fileStream;
        private readonly StreamWriter streamWriter;

        public LogRepository()
        {
            CreateFolderAndFile(path);
            this.fileStream = new FileStream(path, FileMode.Append);
            this.streamWriter = new StreamWriter(this.fileStream, leaveOpen: true);
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
                    File.Create(path).Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro na criação: {0}", e.ToString());
            }
        }
        private static string PrepareLine(string name, string id, string state)
        {
            return $"O usuário {name} ({id}) {state} no sistema às {DateTime.Now.ToString("HH:mm:ss")} do dia {DateTime.Now.ToShortDateString()}.\n";
            
        }

        public void RegisterConnection(string name, string id, string state)
        {
            string line = PrepareLine(name, id, state);
            using (this.streamWriter)
            {
                streamWriter.WriteLine(line);
            }
        }
    }
}
