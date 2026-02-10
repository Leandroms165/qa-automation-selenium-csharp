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
    public class AcaoPage: PageBase
    {
        private readonly CommonPage _commonPage;
        public AcaoPage()
        {
            _commonPage = new CommonPage();
        }
        
        private By selecionarTudo => By.XPath("//input[@id='bug_arr_all']");
        private By ok => By.XPath("//input[@value=\"OK\"]");
        private By copiarTarefa => By.XPath("//input[@value=\"Copiar Tarefas\"]");

        public void SelecionarTudo()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;

            js.ExecuteScript("document.getElementById('bug_arr_all').click();");
        }

        public void ClickOK()
        {
            WebDriver.ClickBy(ok);
        }

        public bool ValidarCriarTarefa(string titleEsperado)
        {
            IWebElement title = WebDriver.FindElement(By.XPath("//h4"));

            try
            {
                return title.Text.Trim() == titleEsperado;
            }
            catch
            {
                return false;
            }
            
        }
        
        public void ClicarCopiarTarefas()
        {
            WebDriver.ClickBy(copiarTarefa);
        }

        public void ValidarDataCriacao()
        {
            IWebElement table = WebDriver.FindElement(By.Id("buglist"));

            var linhasTabela = table.FindElements(By.TagName("tr"));

            bool encontrouDataCriacao = false;

            foreach(var linha in linhasTabela)
            {
                string dataAtual = DateTime.Now.ToString("yyyy-MM-dd");

                if (linha.Text.Contains(dataAtual))
                {
                    encontrouDataCriacao = true;
                    break;
                }
            }

            Assert.That(encontrouDataCriacao, "Encontrou a data da copia !!!");

        }

        public void SelecionarTarefaPorResumo(string resumo)
        {
            IWebElement checkbox = WebDriver.FindElement(By.XPath($"//tr[td[contains(text(),'{resumo}')]]//input[@name='bug_arr[]']" ));

            ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].click();", checkbox);
        }


    }
}
