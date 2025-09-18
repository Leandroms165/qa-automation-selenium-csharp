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
    public class ChallengingTeste: TestBase
    {
        ChallengingPage challengingPage;

        [Test]
        public void ChallengindTest()
        {
            challengingPage = new ChallengingPage();

            challengingPage.AcessarChallenging();
            challengingPage.ValidarTextoNaTabela();
        }
    }
}
