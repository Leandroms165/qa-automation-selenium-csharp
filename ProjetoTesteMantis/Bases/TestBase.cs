using NUnit.Framework;
using OpenQA.Selenium;
using ProjetoTesteMantis.Page;


namespace ProjetoTesteMantis.Bases
{
    public class TestBase
    {
        [SetUp]
        public void Setup()
        {
            // Inicia WebDriver
            DriverFactory.CreateINTANCE();
            DriverFactory.Webdriver.Navigate().GoToUrl(BuilderJson.ParamentsAppSettings("DEFAULT_APPLICATION_URL"));

            DriverFactory.Login();


            // Inicia o relat�rio Extent
            string testName = TestContext.CurrentContext.Test.Name;
            ExtentManager.ExtentReportInit(testName);
            ExtentManager.CriarTeste(testName);
        }

        [TearDown]
        public void TearDown()
        {
            var result = TestContext.CurrentContext.Result;

            // Captura resultado e adiciona no relat�rio
            if (result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                ExtentManager.LogFail(result.Message);
                ExtentManager.AdicionarScreenshot(DriverFactory.Webdriver, TestContext.CurrentContext.Test.Name);
            }
            else
            {
                ExtentManager.LogPass("Teste executado com sucesso.");
            }

            // Finaliza relat�rio
            ExtentManager.ExtentReportFlush();

            // Fecha o navegador
            DriverFactory.QuitDriver();
        }
    }
}
