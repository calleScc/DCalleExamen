namespace DCalleExamen;

public partial class RegistroPage : ContentPage
{
    string usuario;
    const double COSTO = 1500;
    double pagoMensual, total, montoInicial;

    Dictionary<string, List<string>> ciudades = new()
    {
        { "Ecuador",  new() { "Cuenca", "Quito", "Guayaquil" } },
        { "Colombia", new() { "Bogotá", "Medellín", "Cali" } },
        { "Perú",     new() { "Lima", "Cusco", "Arequipa" } }
    };

    public RegistroPage(string usuario)
    {
        InitializeComponent();
        this.usuario = usuario;
        lblUsuario.Text = $"Usuario conectado: {usuario}";
        pkPais.ItemsSource = ciudades.Keys.ToList();
    }

    void OnPaisChanged(object sender, EventArgs e)
    {
        if (pkPais.SelectedItem is string pais)
            pkCiudad.ItemsSource = ciudades[pais];
    }

    async void OnCalcular(object sender, EventArgs e)
    {
        if (!double.TryParse(txtMonto.Text, out montoInicial) ||
            montoInicial < 0 || montoInicial > COSTO)
        {
            await DisplayAlert("Error", "Monto inicial no válido", "OK");
            return;
        }
        pagoMensual = (COSTO - montoInicial) / 4 + COSTO * 0.04;
        total = montoInicial + pagoMensual * 4;
        txtPagoMensual.Text = pagoMensual.ToString("F2");
    }

    async void OnResumen(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
            string.IsNullOrWhiteSpace(txtApellido.Text) ||
            string.IsNullOrWhiteSpace(txtEdad.Text) ||
            pkPais.SelectedItem == null || pkCiudad.SelectedItem == null ||
            string.IsNullOrWhiteSpace(txtPagoMensual.Text))
        {
            await DisplayAlert("Error", "Complete todos los campos y calcule el pago", "OK");
            return;
        }

        await Navigation.PushAsync(new ResumenPage(
            usuario, txtNombre.Text, txtApellido.Text, txtEdad.Text,
            (dpFecha.Date ?? DateTime.Today).ToString("dd/MM/yyyy"),
            pkCiudad.SelectedItem.ToString(), pkPais.SelectedItem.ToString(),
            montoInicial, pagoMensual, total));
    }
}