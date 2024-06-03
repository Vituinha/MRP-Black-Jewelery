using MRP_Black_Jewlery.WPF.CADASTROUSUARIO;
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

namespace MRP_Black_Jewlery
{
    /// <summary>
    /// Lógica interna para frmCadastroUsuario.xaml
    /// </summary>
    public partial class frmCadastroUsuario : Window
    {
        public frmCadastroUsuario()
        {
            InitializeComponent();
        }

        public bool ValidarInformacoes(string email, string senha, string usuario)
        {
            if(email.Length == 0)
            {
                MessageBox.Show("Email não preenchido!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if(senha.Length == 0)
            {
                MessageBox.Show("Senha não preenchida!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (usuario.Length == 0)
            {
                MessageBox.Show("Usuario não preenchida!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void OnCadastrarClick(object sender, RoutedEventArgs e)
        {
            // Lógica para cadastrar o usuário
            string nome = nomeTextBox.Text;
            string email = emailTextBox.Text;
            string senha = senhaPasswordBox.Password;

            if (!ValidarInformacoes(email, senha, nome))
                return;

            // Aqui você pode adicionar a lógica para salvar os dados do usuário
            cadastrarBusiness cadastro = new cadastrarBusiness();
            if (cadastro.InserirUsuario(nome, senha, email))
            {
                MessageBox.Show("Cadastro realizado com sucesso!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
                MessageBox.Show("Erro ao realizar cadastro!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (sender == nomeTextBox)
                {
                    emailTextBox.Focus();
                }
                else if (sender == emailTextBox)
                {
                    senhaPasswordBox.Focus();
                }
                else if (sender == senhaPasswordBox)
                {
                    OnCadastrarClick(sender, e);
                }
            }
        }
        private void OnSairClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
