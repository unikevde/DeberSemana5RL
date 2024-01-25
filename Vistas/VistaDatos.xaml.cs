using cinchiglemaMS6.Modelos;

namespace cinchiglemaMS6.Vistas;

public partial class VistaDatos : ContentPage
{
	public VistaDatos()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        StatusMessage.Text = "";
        App.PersonR.AddNewPerson(txtNombre.Text);
        StatusMessage.Text = App.PersonR.StatusMessage;
    }

    private void btnMostrar_Clicked(object sender, EventArgs e)
    {
        StatusMessage.Text = "";
        List<Persona> lista = App.PersonR.GetAllPeople();
        listaPersonas.ItemsSource = lista;
    }
}