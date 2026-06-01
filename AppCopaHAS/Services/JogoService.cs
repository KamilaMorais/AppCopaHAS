using AppCopaHAS.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AppCopaHAS.Services
{
    public class JogoService : Request
    {
        private readonly Request _request;
        private const string _apiUrlBase = "https://copaapi3ai.azurewebsites.net/Jogos";

        public JogoService()
        {
            _request = new Request();
        }

        public async Task<ObservableCollection<Jogo>> GetJogosAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");

            ObservableCollection<Jogo> lista =
                await _request.GetAsync<ObservableCollection<Jogo>>(
                    _apiUrlBase + urlComplementar,
                    string.Empty);

            return lista;
        }
    }
}