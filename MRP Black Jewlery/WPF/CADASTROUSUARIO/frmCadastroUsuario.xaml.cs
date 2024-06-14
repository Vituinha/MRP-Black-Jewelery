using MRP_Black_Jewlery.WPF.CADASTROFUNCIONARIO;
using MRP_Black_Jewlery.WPF.CADASTROUSUARIO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            string funcionario = FuncionarioComboBox.Text;

            if (!ValidarInformacoes(email, senha, nome))
                return;

            // Aqui você pode adicionar a lógica para salvar os dados do usuário
            WPF.CADASTROUSUARIO.cadastrarBusiness cadastro = new WPF.CADASTROUSUARIO.cadastrarBusiness();
            if (cadastro.InserirUsuario(nome, senha, email, funcionario))
            {
                MessageBox.Show("Cadastro realizado com sucesso!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
                MessageBox.Show("Erro ao realizar cadastro!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void LoadUserData()
        {
            WPF.CADASTROUSUARIO.cadastrarBusiness selecionar = new WPF.CADASTROUSUARIO.cadastrarBusiness();
            UserDataGrid.ItemsSource = selecionar.ListarUsuarios();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUserData();
            LoadFuncionarioData();
        }
        private void LoadFuncionarioData()
        {
            WPF.CADASTROUSUARIO.cadastrarBusiness funcionarioService = new WPF.CADASTROUSUARIO.cadastrarBusiness();
            List<Funcionario> funcionarios = funcionarioService.listarFuncionario();
            FuncionarioComboBox.ItemsSource = funcionarios;
        }
    }

    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }

    public class User
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Funcionario { get; set; }
    }
}
