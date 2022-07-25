using pedronogueira_d3_avaliacao.Models;

namespace pedronogueira_d3_avaliacao.Interfaces
{
    /// <summary>
    /// Interface com as operações básicas de manipulação do usuário
    /// </summary>
    internal interface IUser
    {
        public publicUser UserConnect(string login, string password);
    }
}
