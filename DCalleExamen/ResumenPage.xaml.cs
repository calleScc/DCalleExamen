namespace DCalleExamen;

public partial class ResumenPage : ContentPage
{
    public ResumenPage(string usuario, string nombre, string apellido, string edad,
                       string fecha, string ciudad, string pais,
                       double monto, double mensual, double total)
    {
        InitializeComponent();
        lblUsuario.Text = $"Usuario conectado: {usuario}";
        lblNombre.Text = nombre;
        lblApellido.Text = apellido;
        lblEdad.Text = edad;
        lblFecha.Text = fecha;
        lblCiudad.Text = ciudad;
        lblPais.Text = pais;
        lblMonto.Text = monto.ToString("C2");
        lblMensual.Text = mensual.ToString("C2");
        lblTotal.Text = total.ToString("C2");
    }

    async void OnVolver(object s, EventArgs e) => await Navigation.PopAsync();
}