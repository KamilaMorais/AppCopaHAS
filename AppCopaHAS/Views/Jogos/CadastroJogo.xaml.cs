using AppCopaHAS.ViewModels.Jogos;

namespace AppCopaHAS.Views.Jogos;

public partial class CadastroJogo : ContentPage
{
	JogoViewModel viewModel;
	public CadastroJogo()
	{
		InitializeComponent();

		viewModel = new JogoViewModel();
		BindingContext = viewModel;
		Title = "Jogos";
	}
}