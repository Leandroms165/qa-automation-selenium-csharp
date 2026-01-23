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
            // Aguarda 7 segundos para garantir que a página e a tabela carreguem completamente
            Thread.Sleep(7000);

            // Localiza a primeira tabela da página que possui as classes:
            // 'table table-bordered table-condensed'
            IWebElement tabela = WebDriver.FindElement(
                By.XPath("(//*[@class='table table-bordered table-condensed'])[1]")
            );

            // Busca todas as linhas (tr) dentro da tabela encontrada
            var linhasTabela = tabela.FindElements(By.TagName("tr"));

            // Variável de controle para saber se o texto foi encontrado ou não
            bool encontrou = false;

            // Percorre todas as linhas da tabela
            foreach (var linha in linhasTabela)
            {
                // Verifica se o texto da linha contém a frase desejada
                if (linha.Text.Contains("Garantia de qualidade de Software"))
                {
                    // Se encontrou o texto, marca como true
                    encontrou = true;

                    // Interrompe o loop, pois não precisa continuar verificando
                    break;
                }
            }

            // Valida o resultado:
            // Se 'encontrou' for false, o teste falha e exibe a mensagem informada
            Assert.That(
                encontrou,
                "Nenhuma linha da tabela contém o texto 'Garantia de qualidade de Software'."
            );
        }

    }
}
