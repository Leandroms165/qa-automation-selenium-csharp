using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Network;
using ProjetoTesteMantis.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteMantis.Page
{
    public class CommonPage: PageBase
    { 
        private By acao => By.Name("action");

        public void ClicaOpcaoDoMenu(string opcao)
        {
            Thread.Sleep(3000);
            IWebElement menu = WebDriver.FindElement(By.XPath($"//*[@id=\"sidebar\"]/ul//a/span[contains(text(),'{opcao}')]"));
            menu.Click();
        }

        public void SelecionarAcao(string nomeAcao)
        { 
            WebDriver.SelectDropDownListByText(acao, nomeAcao);
        }

    }
}
