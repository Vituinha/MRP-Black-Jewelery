using System.Windows;
using System.Data;

namespace MRP_Black_Jewlery
{
    public partial class frmMostrarRelatorio : Window
    {
        private ReportService reportService = new ReportService();

        public frmMostrarRelatorio()
        {
            InitializeComponent();
            LoadReports();
        }

        private void LoadReports()
        {
            LoadGastoMaquinaFuncionario();
            LoadLucroPorMaquina();
            LoadProdutividadePorFuncionario();
            LoadRendaPorProducao();
        }

        private void LoadGastoMaquinaFuncionario()
        {
            DataTable dataTable = reportService.GetGastoMaquinaFuncionario();
            GastoMaquinaFuncionarioDataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void LoadLucroPorMaquina()
        {
            DataTable dataTable = reportService.GetLucroPorMaquina();
            LucroPorMaquinaDataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void LoadProdutividadePorFuncionario()
        {
            DataTable dataTable = reportService.GetProdutividadePorFuncionario();
            ProdutividadePorFuncionarioDataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void LoadRendaPorProducao()
        {
            DataTable dataTable = reportService.GetRendaPorProducao();
            RendaPorProducaoDataGrid.ItemsSource = dataTable.DefaultView;
        }
    }
}
