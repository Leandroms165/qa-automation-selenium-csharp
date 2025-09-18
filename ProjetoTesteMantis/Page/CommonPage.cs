using OpenQA.Selenium;
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
        //
        public void ClicaOpcaoDoMenu(string opcao)
        {
            Thread.Sleep(3000);
            IWebElement menu = webDriver.FindElement(By.XPath($"//*[@id=\"sidebar\"]/ul//a/span[contains(text(),'{opcao}')]"));
            menu.Click();
        }
    }
}
