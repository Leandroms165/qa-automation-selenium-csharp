using ProjetoTesteMantis.Bases;
using ProjetoTesteMantis.Page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteMantis.Teste
{
    [TestFixture]
    public class TesteAdicionarRemover : TestBase
    {
        AcessoPage acessoPage;

        [Test]
        public void AdiconarRemover()
        {
            acessoPage = new AcessoPage();

            acessoPage.AcessarMenuAddRemover();
            acessoPage.ClicarEmAddElement();
            acessoPage.ValidarButtonDelete();
        }
    }
}
