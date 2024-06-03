using System.Windows;
using System.Windows.Input;

namespace MRP_Black_Jewlery
{
    public partial class frmConfiguracoes : Window
    {
        public frmConfiguracoes()
        {
            InitializeComponent();
        }

        private void AdicionarDepartamento_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(novoDepartamentoTextBox.Text))
            {
                departamentosListBox.Items.Add(novoDepartamentoTextBox.Text);
                novoDepartamentoTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, insira o nome do departamento.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para salvar as configurações
            string nomeEmpresa = nomeEmpresaTextBox.Text;
            string emailEmpresa = emailEmpresaTextBox.Text;
            string cnpj = cnpjTextBox.Text;

            // Aqui você pode adicionar a lógica para salvar os dados em um banco de dados ou arquivo

            MessageBox.Show("Configurações salvas com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void Sair_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para sair da aplicação
            this.Close();
        }

        private void MoveNext_OnEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                var request = new TraversalRequest(FocusNavigationDirection.Next);
                (sender as UIElement)?.MoveFocus(request);
            }
        }
    }
}
