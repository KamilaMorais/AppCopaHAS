using AppCopaHAS.Models;
using AppCopaHAS.ViewModels;

namespace AppCopaHAS.Views.Jogadores;

public partial class AlbumView : ContentPage
{
	AlbumViewModel viewModel;
	public AlbumView()
	{
        InitializeComponent();

		viewModel = new AlbumViewModel();
		BindingContext = viewModel;
		Title = "Álbum";
	}

    private static string _conexaoAzureBlobStorage = "COLE a chave de acesso da conta de armazenamento";
    private static string _container = "arquivos";

    private async Task SelecionarFoto(Jogador jogador)
    {
        try
        {
            // Código ficará aqui
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage
                .DisplayAlert("Ops", ex.Message, "Detalhes" + ex.InnerException, "Ok");
        }
    }
}