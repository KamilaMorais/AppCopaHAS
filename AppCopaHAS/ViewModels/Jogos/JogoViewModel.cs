using AppCopaHAS.Models;
using AppCopaHAS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppCopaHAS.ViewModels.Jogos
{
    public class JogoViewModel: BaseViewModel
    {
        private EstadioService _estadioService;
        private SelecaoService _selecaoService;
        private JogoService _jogoService;
        public ObservableCollection<Estadio> Estadios { get; set; }
        public ObservableCollection<Selecao> Selecoes { get; set; }
        public ObservableCollection<Jogo> Jogos { get; set; }

        public JogoViewModel()
        {
            _estadioService = new EstadioService();
            _selecaoService = new SelecaoService();
            _jogoService = new JogoService();

            Estadios = new ObservableCollection<Estadio>();
            Selecoes = new ObservableCollection<Selecao>();
            Jogos = new ObservableCollection<Jogo>();

            _ = ObterEstadios();
            _ = ObterSelecoes();
        }

        public async Task ObterEstadios()
        {
            try // Junto com o Catch evitará que erros fechem o aplicativo
            {
                Estadios = await _estadioService.GetEstadiosAsync();
                OnPropertyChanged(nameof(Estadios)); // Informará a view que houve carregamento
            }
            catch (Exception ex)
            {
                // Captara o erro para exibir em tela
                await Application.Current.MainPage
                    .DisplayAlertAsync("Ops",
                                       ex.Message,
                                       "Detalhes" + ex.InnerException,
                                       "Ok");
            }
        }

        public async Task ObterSelecoes()
        {
            try // Junto com o Catch evitará que erros fechem o aplicativo
            {
                Selecoes = await _selecaoService.GetSelecoesAsync();
                OnPropertyChanged(nameof(Selecoes)); // Informará a view que houve carregamento
            }
            catch (Exception ex)
            {
                // Captara o erro para exibir em tela
                await Application.Current.MainPage
                    .DisplayAlertAsync("Ops",
                                       ex.Message,
                                       "Detalhes" + ex.InnerException,
                                       "Ok");
            }
        }
    }
}
