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
    public class AcessoPage : PageBase
    {
        private By acessarButton => By.XPath("//li/a[contains(text(),'Add/Remove Elements')]");
        private By buttonAddElement => By.XPath("//button[contains(text(),'Add Element')]");
        private By buttonDelete => By.XPath("//button[contains(text(),'Delete')]");

        public void AcessarMenuAddRemover()
        {
            webDriver.ClickBy(acessarButton);
        }

        public void ClicarEmAddElement()
        {
            webDriver.ClickBy(buttonAddElement);
        }
        public void ValidarButtonDelete()
        {
            webDriver.IsElementPresent(buttonDelete);
        }

        
    }
}
