using AppCopaHAS.Models;
using AppCopaHAS.Services;
using AppCopaHAS.ViewModels;
using System;
using System.Collections.ObjectModel;

public class ListagemJogadorViewModel: BaseViewModel
{
	private JogadorService _jogadorService;
	
	public ObservableCollection<Jogador> Jogadores { get; set; }

	public ListagemJogadorViewModel()
	{
		_jogadorService = new JogadorService();
		Jogadores = new ObservableCollection<Jogador>();

		ObterJogadores();
	}

	public async Task ObterJogadores()
	{
		try
		{
			Jogadores = await _jogadorService.GetJogadoresAsync();
			OnPropertyChanged(nameof(Jogadores));
		}
		catch (Exception ex)
        {
			await Application.Current.MainPage
               .DisplayAlert("Ops", ex.Message, "Detalhes" + ex.InnerException, "Ok");
		}
	}
}
