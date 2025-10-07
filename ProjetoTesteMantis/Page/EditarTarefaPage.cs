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
    public class EditarTarefaPage: PageBase
    {
        private readonly CommonPage commonPage;
        

        public EditarTarefaPage()
        {
            commonPage = new CommonPage();
        }

        private By atualizarTarefa => By.XPath("//tr[1]/td[2]/a/i");
        private By resumo => By.Id("summary");
        private By gravidade => By.Name("severity");
        private By atualizarInformacoes => By.XPath("//input[@value='Atualizar Informação']");
        private By ok => By.XPath("//input[@value='OK']");
        private By acao => By.Name("action");
        private By apagarTarefas => By.XPath("//input[@value=\"Apagar Tarefas\"]");
        public void VerTarefa()
        {
            commonPage.ClicaOpcaoDoMenu("Ver Tarefas");
        }
        public void AtualizarTarefa()
        {
            WebDriver.ClickBy(atualizarTarefa);
        }

        public void EditarTarefas()
        {
            WebDriver.SelectDropDownListByText(gravidade, "recurso");
            WebDriver.SendKeys(resumo, "Teste Atualizado", clearBefore: true);
        }
        public void AtualizarInformacoes()
        {
            WebDriver.ClickBy(atualizarInformacoes);
        }
        public void ValidarTarefa()
        {
            Thread.Sleep(7000);
            IWebElement tabela = WebDriver.FindElement(By.XPath("(//*[@class='table table-bordered table-condensed'])[1]"));
            var linhasTabela = tabela.FindElements(By.TagName("tr"));

            bool encontrou = false;

            foreach (var linha in linhasTabela)
            {
                if (linha.Text.Contains("Teste Atualizado"))
                {
                    encontrou = true;
                    break;
                }
            }
            Assert.That(encontrou, "Nenhuma linha da tabela contém o texto 'Garantia de qualidade de Software'.");

        }

        public void ExcluirTarefa()
        {
            var checkbox = WebDriver.FindElement(By.XPath("//tr[td[contains(normalize-space(.),'Teste Atualizado')]]//span[@class='lbl']"));
                checkbox.Click();
        }
        public void SelecionarAcao()
        {
            WebDriver.SelectDropDownListByText(acao, "Apagar");
            WebDriver.ClickBy(ok);
        }
        public bool ValidarMensagemExibida(string mensagem)
        {
            try
            {
               var elemento = WebDriver.FindElement(By.XPath($"//th[@class='category' and contains(text(),'{mensagem}')]"));
               return elemento.Displayed;
            }
            catch (NoSuchElementException)
            {
               return false;
            }

        }
        public void ClicarApagarTarefas()
        {
            WebDriver.ClickBy(apagarTarefas);
        }
        public bool ValidaTarefaExcluída(string resumo)
        {
            try
            {
                var elemento = WebDriver.FindElement(By.XPath($"//tr[td[contains(normalize-space(.),'{resumo}')]]"));
                return elemento.Enabled;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
