using ProyectoFinal23CV.Context;
using ProyectoFinal23CV.Entities;
using ProyectoFinal23CV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoFinal23CV.VistasWPF
{
    /// <summary>
    /// Lógica de interacción para Sistema.xaml
    /// </summary>
    public partial class Sistema : Window
    {
        public Sistema()
        {
            InitializeComponent();
            GetUserTable();
            GetRoles();
        }

        UsuarioServices services = new UsuarioServices();

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario(); 
            if (txtPkUser.Text == "")
            {
                usuario.Nombre = txtNombre.Text;
                usuario.UserName = txtUserName.Text;
                usuario.Password = txtPassword.Text;
                usuario.FkRol = int.Parse(SelecRol.SelectedValue.ToString());
                services.AddUser(usuario);

                txtNombre.Clear();
                txtUserName.Clear();
                txtPassword.Clear();

                MessageBox.Show("Se agrego correctamente");
                GetUserTable();


            }


        }

        public void GetUserTable()
        {
            UserTable.ItemsSource = services.GetUsers();

        }
        public void GetRoles() 
        {
            SelecRol.ItemsSource = services.GetRoles();
            SelecRol.DisplayMemberPath = "Nombre";
            SelecRol.SelectedValue = "PkRol";

        }
        public void EditItem (object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario ();
            usuario = (sender as FrameworkElement).DataContext as Usuario;  

            txtPkUser.Text = usuario.PkUsuario.ToString();
            txtNombre.Text = usuario.Nombre.ToString();
            txtUserName.Text = usuario.UserName.ToString();
            txtPassword.Text = usuario.Password.ToString();
        }
    }
}
