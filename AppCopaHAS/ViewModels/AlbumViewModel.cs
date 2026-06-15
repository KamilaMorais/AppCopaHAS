using AppCopaHAS.Models;
using AppCopaHAS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCopaHAS.ViewModels
{
    public class AlbumViewModel : BaseViewModel
    {
        private SelecaoService _selecaoService;
        private JogadorService _jogadorService;

        public ObservableCollection<Selecao> Selecoes { get; set; }
        public ObservableCollection<Jogador> Jogadores { get; set; }

        private Selecao selecaoSelecionada;

        public Selecao SelecaoSelecionada
        {
            get => selecaoSelecionada;
            set
            {
                selecaoSelecionada = value;
                OnPropertyChanged();

                if (value != null)
                    _ = ObterJogadores(value.Id);
            }
        }

        public AlbumViewModel()
        {
            _selecaoService = new SelecaoService();
            _jogadorService = new JogadorService();

            Selecoes = new ObservableCollection<Selecao>();
            Jogadores = new ObservableCollection<Jogador>();

            _ = ObterSelecoes();
        }

        public async Task ObterSelecoes()
        {
            try
            {
                Selecoes = await _selecaoService.GetSelecoesAsync();
                OnPropertyChanged(nameof(Selecoes));
            }
            catch (Exception ex)
            {
                // Captura o erro para exibir em tela
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message, "Detalhes" + ex.InnerException, "Ok");
            }
        }

        public async Task ObterJogadores(int selecaoId)
        {
            try
            {
                var jogadoresApi = await _jogadorService.GetJogadoresAsync();
                Jogadores.Clear();

                foreach (var jogador in jogadoresApi.Where(x => x.SelecaoId == selecaoId))
                    Jogadores.Add(jogador);

                OnPropertyChanged(nameof(Jogadores));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message, "Detalhes" + ex.InnerException, "Ok");
            }
        }
    }
}
