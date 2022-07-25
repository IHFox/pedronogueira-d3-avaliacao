using pedronogueira_d3_avaliacao.Interfaces;

namespace pedronogueira_d3_avaliacao.Repositories
{
    internal class LogRepository : ILog
    {
        private const string path = ".\\log.txt"; // Salvar arquivo no mesmo diretório
        private readonly FileStream fileStream;
        private readonly StreamWriter streamWriter;

        public LogRepository()
        {
            CreateFolderAndFile(path);
            this.fileStream = new FileStream(path, FileMode.Append);
            this.streamWriter = new StreamWriter(this.fileStream, leaveOpen: true);
        }

        /// <summary>
        /// Criação de pasta e arquivo caso os mesmos não existam
        /// </summary>
        /// <param name="path">Caminho para a criação do arquivo</param>
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

        /// <summary>
        /// Preparação da linha a ser escrita no arquivo de texto
        /// </summary>
        /// <param name="name">Nome do usuário</param> 
        /// <param name="id">ID do usuário (GUID)</param> 
        /// <param name="state">Ação do usuário (logar, deslogar, etc)</param> 
        /// <returns>Linha formatada para ser colocada no arquivo</returns>
        private static string PrepareLine(string name, Guid id, string state)
        {
            return $"O usuário {name} ({id}) {state} no sistema às {DateTime.Now.ToString("HH:mm:ss")} do dia {DateTime.Now.ToShortDateString()}.\n";
            
        }

        /// <summary>
        /// Escrita da linha no arquivo de texto
        /// </summary>
        /// <param name="name">Nome do usuário</param> 
        /// <param name="id">ID do usuário (GUID)</param> 
        /// <param name="state">Ação do usuário (logar, deslogar, etc)</param> 
        public void RegisterConnection(string name, Guid id, string state)
        {
            string line = PrepareLine(name, id, state);
            using (this.streamWriter)
            {
                streamWriter.WriteLine(line);
            }
        }
    }
}
