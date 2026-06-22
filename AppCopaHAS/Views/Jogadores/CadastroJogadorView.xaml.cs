using AppCopaHAS.ViewModels;

namespace AppCopaHAS.Views.Jogadores;

public partial class CadastroJogadorView : ContentPage
{
	CadastroJogadorViewModel viewModel;
	public CadastroJogadorView()
	{
		InitializeComponent();

		viewModel = new CadastroJogadorViewModel();
		BindingContext = viewModel;
		Title = "CadastroJogador";
	}
}