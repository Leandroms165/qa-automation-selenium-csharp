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
    public class ResolverPage: PageBase
    {
        private readonly CommonPage commonPage;

        public ResolverPage()
        {
            commonPage = new CommonPage();
        }

        public void ResolverTarefa (string nomeResumoResolver)
        {
            IWebElement tabela = WebDriver.FindElement(By.Id("buglist"));

            var linhasTabela = WebDriver.FindElements(By.TagName("tr"));

            var encontrouTarefa = false;

            foreach(var linhas in linhasTabela)
            {
                if (linhas.Text.Contains(nomeResumoResolver))
                {
                    encontrouTarefa = true;
                    IWebElement element = WebDriver.FindElement(By.XPath($"//tr[td[contains(normalize-space(.),'{nomeResumoResolver}')]]//span[@class='lbl']"));
                    element.Click();
                    break;

                }
            }

        }
    }
}
