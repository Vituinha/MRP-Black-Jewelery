using System.Windows;

namespace MRP_Black_Jewlery.WPF.CADASTRODEPARTAMENTO
{
    public partial class frmCadastroDepartamento : Window
    {
        public frmCadastroDepartamento()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // Aqui você pode adicionar lógica para manipular eventos KeyDown se necessário
        }

        private void CadastrarButton_Click(object sender, RoutedEventArgs e)
        {
            // Lógica de cadastro do departamento
            string nomeDepartamento = NomeDepartamentoTextBox.Text;
            string descricao = DescricaoTextBox.Text;

            // Validação simples
            if (string.IsNullOrEmpty(nomeDepartamento) || string.IsNullOrEmpty(descricao))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Lógica para salvar os dados (Exemplo: salvar no banco de dados)
            cadastrarBusiness cadastro = new cadastrarBusiness();
            var resultadoInsercao = cadastro.InserirDepartamento(nomeDepartamento, descricao);
            if (resultadoInsercao == 1)
            {
                MessageBox.Show("Cadastro realizado com sucesso!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else if (resultadoInsercao == 2)
                MessageBox.Show("Erro ao realizar cadastro!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                MessageBox.Show("Departamento já cadastrado no sistema!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            MessageBox.Show($"Departamento {nomeDepartamento} cadastrado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SairButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
