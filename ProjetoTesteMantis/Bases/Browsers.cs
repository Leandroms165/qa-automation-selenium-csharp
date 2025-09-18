using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V136.Runtime;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteMantis
{
    public class Browsers
    {
        private static ChromeOptions chromeOptions;
        private static EdgeOptions edgeOptions;

        public static ChromeOptions OptionsChrome(bool headless)
        {
            chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            chromeOptions.AddArgument("enable-automation");
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--disable-infobars");
            chromeOptions.AddArgument("--disable-dev-shm-usage");
            chromeOptions.AddArgument("--disable-browser-side-navigation");
            chromeOptions.AddArgument("--disable-gpu");

            // Verifica se o modo headless está ativado
            if (headless)
            {
                chromeOptions.AddArgument("--headless");
            }
            return chromeOptions; // Retorna o objeto configurado

        }

        public static EdgeOptions OptionsEdge(bool headless) 
        {
            edgeOptions  = new EdgeOptions();
            edgeOptions.AddArgument("--start-maximized");
            edgeOptions.AddArgument("enable-automation");
            edgeOptions.AddArgument("--no-sandbox");
            edgeOptions.AddArgument("--disable-infobars");
            edgeOptions.AddArgument("--disable-dev-shm-usage");
            edgeOptions.AddArgument("--disable-browser-side-navigation");
            edgeOptions.AddArgument("--disable-gpu");

            if (headless) 
            {
                edgeOptions.AddArgument("--headless");
            }
            return edgeOptions;
            
        }
    }
}
