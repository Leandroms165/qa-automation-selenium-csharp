using AngleSharp.Css;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Support.UI;
using ProjetoTesteMantis.Page;

namespace ProjetoTesteMantis.Bases
{
    public class DriverFactory
    {
        public static IWebDriver Webdriver { get; set; }
        public static WebDriverWait Wait { get; set; }


        public static void CreateINTANCE()
        {
            var browser = BuilderJson.ParamentsAppSettings("BROWSER");
            var defaultUrl = BuilderJson.ParamentsAppSettings("DEFAULT_APPLICATION_URL");
            bool headless = bool.Parse(BuilderJson.ParamentsAppSettings("HEADLESS"));

            switch (browser)
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    var chromeOptions = Browsers.OptionsChrome(headless);
                    Webdriver = new ChromeDriver(chromeOptions);
                    break;

                case "edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    
                    Webdriver = new EdgeDriver();
                    var edgeOptions = Browsers.OptionsEdge(headless);
                    Webdriver.Manage().Window.Maximize();
                    break;

                case "Firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    Webdriver = new FirefoxDriver();
                    break;

                default: throw new Exception("Navegador não disponível");
            }
            Wait = new WebDriverWait(Webdriver, TimeSpan.FromSeconds(Convert.ToDouble(BuilderJson.ParamentsAppSettings("DEFAULT_TIMEOUT_IN_SECONDS"))));

        }

        public static void Login()
        {
            var username = BuilderJson.ParamentsAppSettings("USERNAME");
            var password = BuilderJson.ParamentsAppSettings("PASSWORD");

            var loginPage = new LoginPage();
            loginPage.Login(username, password);
        }
        public static void QuitDriver()
        {
            Webdriver.Quit();
            Webdriver.Dispose();
            Webdriver = null;
        }

    }
}
