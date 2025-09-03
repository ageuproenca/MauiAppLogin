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
            lblBoasVindas.Text = $"Usuário: {usuarioLogado}";
        });
		
        
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		bool confirmacao = await DisplayAlert("Atenção", "Deseja realmente sair?", "Sim", "Não");

		if (confirmacao)
		{

			SecureStorage.Default.Remove("usuario");
			App.Current.MainPage = new Login();
        }
    }
}