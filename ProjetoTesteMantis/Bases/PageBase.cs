using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteMantis.Bases
{
    public partial class PageBase
    {
        protected IWebDriver WebDriver { get; set; }
        protected WebDriverWait wait { get; set; }
        protected IJavaScriptExecutor javaScript { get; set; }

        public PageBase()
        {
            WebDriver = DriverFactory.Webdriver;
            javaScript = (IJavaScriptExecutor)WebDriver;
        }
       
    }
}
