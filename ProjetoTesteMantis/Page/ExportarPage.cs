using OpenQA.Selenium;
using ProjetoTesteMantis.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteMantis.Page
{
    public class ExportarPage: PageBase
    {
        private readonly CommonPage commonPage;

        public ExportarPage()
        {
            commonPage = new CommonPage();
        }

        private By exportarParaCSV => By.XPath("//a[contains(text(),'Exportar para Arquivo CSV')]");

        public void ClicarExportarParaCSV() 
        {
            WebDriver.ClickBy(exportarParaCSV);
        }
    }
}
