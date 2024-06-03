using MRP_Black_Jewlery;
using MRP_Black_Jewlery.WPF.ENTRAR;
using System.Diagnostics.Eventing.Reader;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace BlackJewelryMRP
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AbrirNovaPagina()
        {
            // Cria uma nova instância da nova página
            frmMenu novaPagina = new frmMenu();
            novaPagina.Show();

            // Fecha a janela atual
            Close();
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Mude o foco para o campo de senha
                passwordBox.Focus();
            }
        }
        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Faça login quando Enter for pressionado no campo de senha
                Login();
            }
        }
        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            Login();
        }
        private void Login()
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;

            loginBusiness efetuaLogin = new loginBusiness();
            if (efetuaLogin.VerificaLogin(username, password))
            {
                MessageBox.Show("Login executado com sucesso!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                AbrirNovaPagina();
            }
            else
                MessageBox.Show("Login ou senha inválido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void OnSairClick(object sender, RoutedEventArgs e)
        {
            // Fechar o sistema
            Application.Current.Shutdown();
        }
    }
}
