using MRP_Black_Jewlery.WPF.CADASTRODEPARTAMENTO;
using MRP_Black_Jewlery.WPF.CADASTROFUNCIONARIO;
using MRP_Black_Jewlery.WPF.CADASTROMAQUINARIO;
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
    /// Lógica interna para frmMenu.xaml
    /// </summary>
    public partial class frmMenu : Window
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                try
                {
                    this.DragMove();
                }
                catch(Exception ex)
                {
                    //IGNORED
                }
            }
        }

        private void NavBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ContentGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void MenuItemHome_Click(object sender, RoutedEventArgs e)
        {
        }

        private void MenuItemProdutos_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para lidar com o clique no item "Produtos"
            MessageBox.Show("Você clicou em Produtos!");
        }

        private void MenuItemFornecedores_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para lidar com o clique no item "Fornecedores"
            MessageBox.Show("Você clicou em Fornecedores!");
        }

        private void MenuItemOrdensProducao_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para lidar com o clique no item "Ordens de Produção"
            MessageBox.Show("Você clicou em Ordens de Produção!");
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }
        private void MenuItemCadastroUsuario_Click(object sender, RoutedEventArgs e)
        {
            // Abra a janela de cadastro de usuário
            frmCadastroUsuario cadastroUsuarioWindow = new frmCadastroUsuario();
            cadastroUsuarioWindow.Show();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItemCadastroMaquinario_Click(object sender, RoutedEventArgs e)
        {
            // Abra a janela de cadastro de maquinario
            frmCadastroMaquinario cadastroMaquinarioWindow = new frmCadastroMaquinario();
            cadastroMaquinarioWindow.Show();
        }

        private void MenuItemCadastroFuncionario_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroFuncionario cadastroFuncionarioWindow = new frmCadastroFuncionario();
            cadastroFuncionarioWindow.Show();
        }

        private void MenuItemCadastroDepartamento_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroDepartamento cadastroDepartamentoWindow = new frmCadastroDepartamento();
            cadastroDepartamentoWindow.Show();
        }
    }
}
