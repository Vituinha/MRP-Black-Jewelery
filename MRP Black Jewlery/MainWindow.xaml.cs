using MRP_Black_Jewlery;
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

            // Simulação de validação de login (substituir por lógica real de autenticação)
            if (username == "admin" && password == "password")
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                // Aqui você pode redirecionar para outra janela ou realizar outras ações de pós-login
                AbrirNovaPagina();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnSairClick(object sender, RoutedEventArgs e)
        {
            // Fechar o sistema
            Application.Current.Shutdown();
        }
    }
}
