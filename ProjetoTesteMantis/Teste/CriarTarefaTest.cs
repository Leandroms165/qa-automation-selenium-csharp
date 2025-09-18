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
    public class CriarTarefaTest: TestBase
    {

        [Test]
        public void CriarTarefa()
        {
            var page = new CriarTarefaPage();
            page.CriarTarefa();
            page.PreencherFormularioTarefa();
            page.MsgSucesso("Operação realizada com sucesso.");
            page.ValidarTarefa();
        }
    }
}
