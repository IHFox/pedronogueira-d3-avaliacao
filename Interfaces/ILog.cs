using pedronogueira_d3_avaliacao.Models;

namespace pedronogueira_d3_avaliacao.Interfaces
{
    internal interface ILog
    {
        void RegisterConnection(string name, Guid id, string state);
    }
}
