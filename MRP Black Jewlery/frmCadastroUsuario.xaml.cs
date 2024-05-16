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
        private void OnCadastrarClick(object sender, RoutedEventArgs e)
        {
            // Lógica para cadastrar o usuário
            string nome = nomeTextBox.Text;
            string email = emailTextBox.Text;
            string senha = senhaPasswordBox.Password;

            // Aqui você pode adicionar a lógica para salvar os dados do usuário
            MessageBox.Show("Usuário cadastrado com sucesso!");
            this.Close();
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
