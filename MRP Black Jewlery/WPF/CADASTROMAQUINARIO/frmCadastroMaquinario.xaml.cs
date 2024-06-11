using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MRP_Black_Jewlery.WPF.CADASTROMAQUINARIO
{
    public partial class frmCadastroMaquinario : Window
    {
        public frmCadastroMaquinario()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var textBox = sender as TextBox;
                if (textBox != null && textBox.Tag != null)
                {
                    var nextElement = GetNextElement(textBox.Tag.ToString());
                    if (nextElement != null)
                    {
                        nextElement.Focus();
                    }
                }
            }
        }

        private void ValorTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Permitir apenas valores numéricos com duas casas decimais
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string text = textBox.Text;
                if (System.Text.RegularExpressions.Regex.IsMatch(text, @"^[0-9]*(?:\.[0-9]{0,2})?$"))
                {
                    // Texto válido, nada a fazer
                }
                else
                {
                    textBox.Text = text.Remove(text.Length - 1);
                    textBox.SelectionStart = textBox.Text.Length;
                }
            }
        }

        private void CadastrarButton_Click(object sender, RoutedEventArgs e)
        {
            // Lógica de cadastro da máquina
            string nomeMaquina = NomeMaquinaTextBox.Text;
            string modelo = ModeloTextBox.Text;
            string numeroSerie = NumeroSerieTextBox.Text;
            string dataAquisicao = DataAquisicaoDatePicker.SelectedDate?.ToString("dd/MM/yyyy");

            decimal valor;
            if (!decimal.TryParse(ValorTextBox.Text, out valor))
            {
                MessageBox.Show("Valor inválido.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Validação simples
            if (string.IsNullOrEmpty(nomeMaquina) || string.IsNullOrEmpty(modelo) ||
                string.IsNullOrEmpty(numeroSerie) || string.IsNullOrEmpty(dataAquisicao))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Lógica para salvar os dados (Exemplo: salvar no banco de dados)
            cadastrarBusiness cadastro = new cadastrarBusiness();
            var resultadoInsercao = cadastro.InserirMaquinario(nomeMaquina, modelo, numeroSerie, dataAquisicao, valor);
            if (resultadoInsercao == 1)
            {
                MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else if (resultadoInsercao == 2)
                MessageBox.Show("Erro ao realizar cadastro!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                MessageBox.Show("Maquinário já cadastrado no sistema!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private UIElement GetNextElement(string tagName)
        {
            var nextElement = FindName(tagName) as UIElement;
            return nextElement;
        }

        private void SairButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DatePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var datePicker = sender as DatePicker;
                if (datePicker != null && datePicker.Tag != null)
                {
                    var nextElement = GetNextElement(datePicker.Tag.ToString());
                    if (nextElement != null)
                    {
                        nextElement.Focus();
                    }
                }
            }
        }
    }
}
