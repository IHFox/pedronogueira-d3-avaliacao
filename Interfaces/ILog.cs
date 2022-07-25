using pedronogueira_d3_avaliacao.Models;

namespace pedronogueira_d3_avaliacao.Interfaces
{
    /// <summary>
    /// Interface com as operações básicas de escrever o arquivo de log
    /// </summary>
    internal interface ILog
    {
        void RegisterConnection(string name, Guid id, string state);
    }
}
