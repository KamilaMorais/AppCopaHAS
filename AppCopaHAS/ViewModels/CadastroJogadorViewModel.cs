using AppCopaHAS.Models;
using AppCopaHAS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppCopaHAS.ViewModels
{
    public class CadastroJogadorViewModel : BaseViewModel
    {
        private JogadorService _jogadorService;
        private SelecaoService _selecaoService;
        private Selecao selecaoSelecionada;
        private Selecao SelecaoSelecionada
        {
            get => selecaoSelecionada;
            set
            {
                if (value != null)
                {
                    selecaoSelecionada = value;
                    OnPropertyChanged();
                }
            }
        }
        private int id;
        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }
        private string nome;
        public string Nome
        {
            get => nome;
            set
            {
                nome = value;
                OnPropertyChanged();
            }
        }
        private int numeroCamisa;
        public int NumeroCamisa
        {
            get => numeroCamisa;
            set
            {
                numeroCamisa = value;
                OnPropertyChanged();
            }
        }
        private string posicao;
        public string Posicao
        {
            get => posicao;
            set
            {
                posicao = value;
                OnPropertyChanged();
            }
        }
        public ICommand SalvarCommand {  get; set; }

        public ObservableCollection<Selecao> Selecoes { get; set; }

        public CadastroJogadorViewModel()
        {
            _jogadorService = new JogadorService();
            _selecaoService = new SelecaoService();

            Selecoes = new ObservableCollection<Selecao>();

            ObterSelecoes();

            SalvarCommand = new Command(async () => { await SalvarJogador(); });
        }

        public async Task ObterSelecoes()
        {
            try
            {
                Selecoes = await _selecaoService.GetSelecoesAsync();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException?.Message, "Ok");
            }
        }

        public async Task SalvarJogador()
        {
            try
            {
                Jogador j = new Jogador();
                j.SelecaoId = selecaoSelecionada.Id;
                j.Nome = this.Nome;
                j.Posicao = this.Posicao;
                j.NumeroCamisa = this.NumeroCamisa;

                if (j.Id == 0)
                {
                    Jogador jogadorRetorno = await _jogadorService.PostJogadorAsync(j);
                    await Application.Current.MainPage.DisplayAlert("Mensagem", "Dados salvos com sucesso!", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }
    }
}
