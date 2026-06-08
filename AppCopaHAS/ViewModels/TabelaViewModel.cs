

using AppCopaHAS.Models.DTOs;
using AppCopaHAS.Services;
using System.Collections.ObjectModel;

namespace AppCopaHAS.ViewModels
{
    public class TabelaViewModel : BaseViewModel
    {
        JogoService _jogoService;
        public ObservableCollection<JogoDTO> Jogos { get; set; }

        public TabelaViewModel()
        {
            _jogoService = new JogoService();
            Jogos = new ObservableCollection<JogoDTO>();
            _ = ObterJogos();
        }

        public async Task ObterJogos()
        {
            try
            {
                Jogos = await _jogoService.GetJogosDTOAsync();
                OnPropertyChanged(nameof(Jogos));
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException?.Message, "Ok");
            }
        }
    }
}
