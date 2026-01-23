using NUnit.Framework;
using ProjetoTesteMantis.Bases;
using ProjetoTesteMantis.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteMantis.Teste
{
    [TestFixture]
    public class TarefaTest: TestBase
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
        [Test, Order(3)]
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
