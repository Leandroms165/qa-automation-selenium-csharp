using ProjetoTesteMantis.Bases;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteMantis.Page
{
    public class ChallengingPage: PageBase
    {
        private By acessarChallenging => By.XPath("//li/a[contains(text(),'Challenging DOM')]");

        public void AcessarChallenging()
        {
            webDriver.ClickBy(acessarChallenging);
        }
        public void ValidarTextoNaTabela()
        {
            // Localizar a tabela pelo ID (ou outro seletor adequado)
            IWebElement table = webDriver.FindElement(By.XPath("//table"));

            // Localizar todas as linhas do corpo da tabela
            IReadOnlyList<IWebElement> rows = table.FindElements(By.TagName("tr"));

            bool found = false; //Essa variável será usada para controlar se o texto "TESTE" foi encontrado em alguma célula da tabela. Se for encontrado, found será definido como true.

            for (int i = 1; i < rows.Count; i++) //O loop começa em i = 1 (pulando a primeira linha, que normalmente é o cabeçalho) e continua até i ser menor que rows.Count (número total de linhas).
            {
                // Localizar todas as células (colunas) dentro da linha atual
                IReadOnlyList<IWebElement> cells = rows[i].FindElements(By.TagName("td"));

                foreach (var cell in cells)
                {
                    if (cell.Text.Contains("Definiebas3", StringComparison.OrdinalIgnoreCase))
                    {
                        // Se o texto "TESTE" foi encontrado, define found como true
                        found = true;

                        // Exemplo: Clicar na célula, se necessário
                        // cell.Click();

                        break;
                    }
                }

                if (found)
                {
                    break;
                }
            }

            // Verificar se o texto foi encontrado
           Assert.That(found, "O texto 'TESTE' não foi encontrado em nenhuma célula da tabela.");
        }
    }
}
