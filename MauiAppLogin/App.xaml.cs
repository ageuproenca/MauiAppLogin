namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            string? usuarioLogado = null;

            // se não for inicializado o manpage, dá erro de thread. Nao sei pq!!!!
            MainPage = new Login();

            try
            {
                Task.Run(async () =>
                        {
                            usuarioLogado = await SecureStorage.Default.GetAsync("usuario");


                            if (usuarioLogado == null)
                            {
                                MainPage = new Login();
                            }
                            else
                            {
                                MainPage = new Protegida();
                            }

                        });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = 400;
            window.Height = 700;


            //return new Window(new AppShell());
            return window;
        }
    }


}