using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MRP_Black_Jewlery.WPF.CADASTROFUNCIONARIO
{
    public partial class frmCadastroFuncionario : Window
    {
        public frmCadastroFuncionario()
        {
            InitializeComponent();
        }

        private void CadastrarButton_Click(object sender, RoutedEventArgs e)
        {
            string nome = NomeTextBox.Text;
            string idadeText = IdadeTextBox.Text;
            string cargo = CargoTextBox.Text;
            string salarioText = SalarioTextBox.Text;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(idadeText) ||
                string.IsNullOrWhiteSpace(cargo) || string.IsNullOrWhiteSpace(salarioText))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(idadeText, out int idade))
            {
                MessageBox.Show("Idade deve ser um número inteiro.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!decimal.TryParse(salarioText, out decimal salario))
            {
                MessageBox.Show("Salário deve ser um número decimal.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Aqui você pode adicionar a lógica para salvar os dados do funcionário, como inserir em um banco de dados.
            // Por exemplo:
            // Funcionario novoFuncionario = new Funcionario(nome, idade, cargo, salario);
            // FuncionarioRepository.Adicionar(novoFuncionario);
            cadastrarBusiness cadastro = new cadastrarBusiness();
            var resultadoInsercao = cadastro.InserirFuncionario(nome, idade, cargo, salario);
            if (resultadoInsercao == 1)
            {
                MessageBox.Show("Cadastro realizado com sucesso!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else if (resultadoInsercao == 2)
                MessageBox.Show("Erro ao realizar cadastro!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                MessageBox.Show("Funcionário já cadastrado no sistema!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            MessageBox.Show($"Funcionário {nome} cadastrado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

            // Limpar os campos após cadastro
            NomeTextBox.Clear();
            IdadeTextBox.Clear();
            CargoTextBox.Clear();
            SalarioTextBox.Clear();
        }

        private void SairButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                // Move to the next control on Enter key press
                e.Handled = true; // Prevents the default behavior
                var request = new TraversalRequest(System.Windows.Input.FocusNavigationDirection.Next);
                request.Wrapped = true;
                (sender as UIElement).MoveFocus(request);
            }
        }

        private void IdadeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Permite apenas números no campo Idade
            e.Handled = !int.TryParse(e.Text, out _);
        }

        private void SalarioTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Permite apenas números e ponto decimal no campo Salário
            if (!decimal.TryParse(e.Text, out _) && e.Text != ".")
            {
                e.Handled = true;
            }
        }

        private void SalarioTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string text = textBox.Text;

            // Mantém apenas até duas casas decimais
            if (decimal.TryParse(text, out decimal value))
            {
                int decimalCount = BitConverter.GetBytes(decimal.GetBits(value)[3])[2];
                if (decimalCount > 2)
                {
                    textBox.Text = value.ToString("F2", CultureInfo.InvariantCulture);
                    textBox.CaretIndex = textBox.Text.Length;
                }
            }
        }
        private void LoadDadoFuncionario()
        {
            cadastrarBusiness funcionarioService = new cadastrarBusiness();
            List<Funcionario> machines = funcionarioService.ListaFuncionarios();
            FuncionarioDataGrid.ItemsSource = machines;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDadoFuncionario();
        }
    }

    public class Funcionario
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
    }
}
