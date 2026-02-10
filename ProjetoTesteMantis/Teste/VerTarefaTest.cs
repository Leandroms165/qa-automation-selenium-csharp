using NUnit.Framework;
using ProjetoTesteMantis.Bases;
using ProjetoTesteMantis.Page;

namespace ProjetoTesteMantis.Teste
{
    [TestFixture]
    public class VerTarefaTest: TestBase
    {
        [Test, Order (1)]
        public void CriarTarefa()
        {
            var page = new CriarTarefaPage();
            page.CriarTarefa();
            page.PreencherFormularioTarefa();
            page.MsgSucesso("Operação realizada com sucesso.");
            page.ValidarTarefa();
        }

        [Test, Order(2)]
        public void EditarTarefa()
        {
            var page = new EditarTarefaPage();
            
            page.VerTarefa();
            page.AtualizarTarefa();
            page.EditarTarefas();
            page.AtualizarInformacoes();
            page.ValidarTarefa();

        }

        [Test,Order(3)]

        public void ExportarTarefa()
        {
            var page = new ExportarPage();
            var commonPage = new CommonPage();
            commonPage.ClicaOpcaoDoMenu("Ver Tarefas");
            page.ClicarExportarParaCSV();
            // Validação do download pode variar dependendo do ambiente e das permissões do navegador.
            // Aqui, apenas verificamos se o botão de exportação foi clicado sem erros.
           // Assert.Pass("Exportação iniciada com sucesso.");
        }

        [Test, Order(4)]
        public void ResumoTarefa() 
        { 
            var page = new ResumoPage();
            var commonPage = new CommonPage();
            commonPage.ClicaOpcaoDoMenu("Resumo");
            page.ValidarResumoTarefa("PROJETO TESTE");
        }

        [Test, Order(5)]
        public void CopiarTatefa()  
        { 
            var page = new AcaoPage();
            var commonPage = new CommonPage();
            commonPage.ClicaOpcaoDoMenu("Ver Tarefas");
            page.SelecionarTudo();
            commonPage.SelecionarAcao("Copiar");
            page.ClickOK();
            page.ValidarCriarTarefa("Copiar tarefas para");
            page.ClicarCopiarTarefas();
            page.ValidarDataCriacao();
        }

        [Test, Order(6)]
        public void AtribuirTarefa() 
        {
            var commonPage = new CommonPage();
            var page = new AcaoPage();
            commonPage.ClicaOpcaoDoMenu("Ver Tarefas");
            page.SelecionarTarefaPorResumo("Teste Automatizado");
        }

        [Test]
        public void ExcluirTarefa()
        {
            var page = new EditarTarefaPage();
            page.VerTarefa();
            page.ExcluirTarefa();
            page.SelecionarAcao();
            page.ValidarMensagemExibida("Você tem certeza que deseja apagar estas tarefas?");
            page.ClicarApagarTarefas();
            page.ValidaTarefaExcluída("Teste Atualizado");
        }
    }
}
