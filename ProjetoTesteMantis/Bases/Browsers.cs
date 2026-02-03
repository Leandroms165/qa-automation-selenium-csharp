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
            ChromeOptions chromeOptions = new ChromeOptions();

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

            // ===== CONFIGURAÇÃO DE DOWNLOAD =====
            string pasta = @"C:\ProjetoTesteMantis\ProjetoTesteMantis\bin\Debug\net8.0\Download";

            string pastaDownload = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
               pasta
            );

            Directory.CreateDirectory(pastaDownload);

            chromeOptions.AddUserProfilePreference(
                "download.default_directory",
                pastaDownload
            );

            chromeOptions.AddUserProfilePreference(
                "download.prompt_for_download",
                false
            );

            chromeOptions.AddUserProfilePreference(
                "download.directory_upgrade",
                true
            );

            chromeOptions.AddUserProfilePreference(
                "safebrowsing.enabled",
                true
            );

            // Retorna o objeto configurado
            return chromeOptions;
        }
        public static EdgeOptions OptionsEdge(bool headless) 
        {
            edgeOptions  = new EdgeOptions();
            edgeOptions.AddArgument("--headless=new");
            edgeOptions.AddArgument("--no-sandbox");
            edgeOptions.AddArgument("--disable-dev-shm-usage");
            edgeOptions.AddArgument("--disable-gpu");


            if (headless) 
            {
                edgeOptions.AddArgument("--headless");
            }
            return edgeOptions;
            
        }
    }
}
