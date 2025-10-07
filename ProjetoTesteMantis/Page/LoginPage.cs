using OpenQA.Selenium;
using ProjetoTesteMantis.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteMantis.Page
{
    public class LoginPage: PageBase
    {
        #region Fields
        private By usuario => By.Id("username");
        private By senha => By.Id("password");
        private By entrar => By.XPath("//*[@id=\"login-form\"]//input[@value='Entrar']");
        #endregion

        public void Login(string username, string password)
        {
            WebDriver.SendKeys(usuario, username);
            WebDriver.ClickBy(entrar);
            WebDriver.SendKeys(senha, password);
            WebDriver.ClickBy(entrar);
        }
    }
}
