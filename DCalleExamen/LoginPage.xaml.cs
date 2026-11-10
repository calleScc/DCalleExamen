namespace DCalleExamen;

public partial class LoginPage : ContentPage
{
    string[,] credenciales = {
        { "estudiante", "moviles" },
        { "suda",       "2025"    }
    };

    public LoginPage() { InitializeComponent(); }

    async void OnLogin(object sender, EventArgs e)
    {
        string user = txtUsuario.Text?.Trim() ?? "";
        string pass = txtClave.Text ?? "";
        bool ok = false;

        for (int i = 0; i < 2; i++)
            if (credenciales[i, 0] == user && credenciales[i, 1] == pass)
                ok = true;

        if (!ok)
        {
            await DisplayAlert("Error", "Dato incorrecto", "OK");
            return;
        }
        await Navigation.PushAsync(new RegistroPage(user));
    }
}