using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V136.CSS;
using ProjetoTesteMantis.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteMantis.Page
{
    public class CriarTarefaPage: PageBase
    {

        private readonly CommonPage _commonPage;
        public void CriarTarefa()
        {
            _commonPage.ClicaOpcaoDoMenu("Criar Tarefa");
        }
        private By frequencia => By.Name("reproducibility");
        private By gravidade => By.Id("severity");
        private By prioridade => By.Id("priority");
        private By resumo => By.Id("summary");
        private By descricao => By.Id("description");
        private By passosParaReproduzir => By.Id("steps_to_reproduce");
        private By informacoes => By.Id("additional_info");
        private By anexarArquivo => By.XPath("//*[@data-default-message=\"Anexe arquivos arrastando e soltando, selecionando e colando-os.\"]");
        private By buttonCriarTarefa => By.XPath("//input[@value='Criar Nova Tarefa']");
        By msgsucesso = By.XPath("/html/body/div[2]");
        public CriarTarefaPage()
        {
            _commonPage = new CommonPage();
        }

        
        public void PreencherFormularioTarefa()
        {
            WebDriver.SelectDropDownListByText(frequencia, "sempre");
            WebDriver.SelectDropDownListByText(gravidade, "pequeno");
            WebDriver.SelectDropDownListByText(prioridade, "normal");
            WebDriver.SendKeys(resumo, "Teste Automatizado");
            WebDriver.SendKeys(descricao, "Garantia de qualidade de Software");
            WebDriver.SendKeys(passosParaReproduzir, "Teste > Automatizado > Mantis");
            WebDriver.SendKeys(informacoes, "Aprendizado");
            AnexarDocumento();
            WebDriver.ClickBy(buttonCriarTarefa);
        }
        public void AnexarDocumento()
        {
            string caminhoDoArquivo = @"C:\ProjetoTesteMantis\ProjetoTesteMantis\Documents\Screenshot_1.png";
            IWebElement fileInput = WebDriver.FindElement(By.CssSelector("input.dz-hidden-input"));
            fileInput.SendKeys(caminhoDoArquivo);
        }
        public bool MsgSucesso(string mensagemEsperada)
        {
            try
            {
                var mensagem = WebDriver.FindElement(By.CssSelector("div.alert.alert-success.center p"));
                return mensagem.Text.Trim() == mensagemEsperada;
            }
            catch
            {
                return false;
            }
        }
        public void ValidarTarefa()
        {
            Thread.Sleep(7000);
            IWebElement tabela = WebDriver.FindElement(By.XPath("(//*[@class='table table-bordered table-condensed'])[1]"));
            var linhasTabela = tabela.FindElements(By.TagName("tr"));
            
            bool encontrou = false;

            foreach (var linha in linhasTabela)
            {
                if (linha.Text.Contains("Garantia de qualidade de Software"))
                {
                    encontrou = true;
                    break;
                }
            }
            Assert.That(encontrou, "Nenhuma linha da tabela contém o texto 'Garantia de qualidade de Software'.");

        }
    }
}
