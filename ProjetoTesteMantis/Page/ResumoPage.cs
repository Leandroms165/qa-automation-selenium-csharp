using NUnit.Framework;
using OpenQA.Selenium;
using ProjetoTesteMantis.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteMantis.Page
{
    public class ResumoPage: PageBase
    {
        private readonly CommonPage commonPage;
        public ResumoPage()
        {
            commonPage = new CommonPage();
        }

        public void ValidarResumoTarefa(string porProjeto) 
        {
            // Localizar a tabela de Resumo por Projeto
            IWebElement tabelaPorProjeto = WebDriver.FindElement(By.XPath("(//*[@class=\"table table-hover table-bordered table-condensed table-striped\"])[1]"));

            // Buscar todas as linhas da tabela (tr) dentro da tabela localizada acima
            var linhasTabela = tabelaPorProjeto.FindElements(By.TagName("tr"));

            // Variavel igual a false para saber se o texto foi encontrado
            var encontrouTexto = false;

            foreach(var recebeValorLinhas in linhasTabela) 
            {
                if (recebeValorLinhas.Text.Contains(porProjeto)) 
                {
                    encontrouTexto = true;
                    break;
                }
            }
            // Valida se encontrou, se nao encontrou, o teste falha e exibe a mensagem informada
            Assert.That(encontrouTexto,$"O texto '{porProjeto}' não foi encontrado na tabela de Resumo por Projeto."
            );

        }
    }
}
