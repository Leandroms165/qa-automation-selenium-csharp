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

        public void SelecionarTudo()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;

            js.ExecuteScript("document.getElementById('bug_arr_all').click();");
        }

        public void ClickOK()
        {
            WebDriver.ClickBy(ok);
        }
    }
}
