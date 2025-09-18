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
        protected IWebDriver webDriver { get; set; }
        protected WebDriverWait wait { get; set; }
        protected IJavaScriptExecutor javaScript { get; set; }

        public PageBase()
        {
            //wait = new WebDriverWait(DriverFactory.Webdriver, TimeSpan.FromSeconds(Convert.ToDouble(BuilderJson.ParamentsAppSettings("DEFAULT_TIMEOUT_IN_SECONDS"))));
            webDriver = DriverFactory.Webdriver;
            javaScript = (IJavaScriptExecutor)webDriver;
        }
       
    }
}
