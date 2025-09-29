using Microsoft.EntityFrameworkCore;

namespace MauiAppLogin;

public partial class Login : ContentPage
{
	private LoginContext? dbLogin;
	public Login()
	{
		InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try 
		{
			List<DadosUsuario> listaUsuarios = new List<DadosUsuario>();

			listaUsuarios = await Task.Run(() =>
			{
				using (var db = new LoginContext())
				{
					return db.Users.ToList();
				}
			})

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

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
		base.OnAppearing();

        this.dbLogin = new LoginContext();
        this.dbLogin.Database.EnsureCreated();
        this.dbLogin.Users.Load();
    }
}