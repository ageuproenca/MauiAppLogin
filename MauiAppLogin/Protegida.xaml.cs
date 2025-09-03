namespace MauiAppLogin;

public partial class Protegida : ContentPage
{
	public Protegida()
	{
		InitializeComponent();

		string? usuarioLogado = null;

		Task.Run(async () =>
		{
			usuarioLogado = await SecureStorage.Default.GetAsync("usuario");
            lblBoasVindas.Text = $"Usu�rio: {usuarioLogado}";
        });
		
        
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		bool confirmacao = await DisplayAlert("Aten��o", "Deseja realmente sair?", "Sim", "N�o");

		if (confirmacao)
		{

			SecureStorage.Default.Remove("usuario");
			App.Current.MainPage = new Login();
        }
    }
}