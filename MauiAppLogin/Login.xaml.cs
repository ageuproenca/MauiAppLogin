namespace MauiAppLogin;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try 
		{
			List<DadosUsuario> listaUsuarios = new List<DadosUsuario>()
			{
				new DadosUsuario() { Usuario = "admin", Senha = "admin" },
				new DadosUsuario() { Usuario = "jose", Senha = "123" },
                new DadosUsuario() { Usuario = "maria", Senha = "321" }
            };

			DadosUsuario dadosDigitados = new DadosUsuario()
			{
				Usuario = txtUsuario.Text,
				Senha = txtSenha.Text
            };

			//LINQ para verificar se o usuário e senha existem na lista
			if (listaUsuarios.Any(u => u.Usuario == dadosDigitados.Usuario && u.Senha == dadosDigitados.Senha))
			{
				await SecureStorage.Default.SetAsync("usuario", dadosDigitados.Usuario);

				App.Current.MainPage = new Protegida();
			}
			else 
			{
				throw new Exception("Usuário ou senha inválidos");
            }

        }
        catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "Fechar");
        }
    }
}