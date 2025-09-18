using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using NUnit.Framework;
using OpenQA.Selenium;

public static class ExtentManager
{
    public static ExtentReports extentReports;
    public static ExtentTest currentTest;

    public static void ExtentReportInit(string testName)
    {
        string data = DateTime.Now.ToString("yyyy_MM_dd");
        string hora = DateTime.Now.ToString("HH_mm_ss");

        var reportDir = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestResults", data);
        Directory.CreateDirectory(reportDir);

        string reportFile = Path.Combine(reportDir, $"Relatorio_{testName}_{hora}.html");

        var sparkReporter = new ExtentSparkReporter(reportFile);
        sparkReporter.Config.DocumentTitle = "Relatório de Testes";
        sparkReporter.Config.ReportName = "Execução de Testes Automatizados";
        sparkReporter.Config.Theme = Theme.Standard;

        extentReports = new ExtentReports();
        extentReports.AttachReporter(sparkReporter);
        extentReports.AddSystemInfo("Navegador", "Chrome");
        extentReports.AddSystemInfo("Ambiente", "Homologação");
    }
    public static string AdicionarScreenshot(IWebDriver driver, string nomeCenario)
    {
        var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

        string pasta = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestResults", DateTime.Now.ToString("yyyy_MM_dd"));
        Directory.CreateDirectory(pasta);

        string caminho = Path.Combine(pasta, $"{nomeCenario}_{DateTime.Now:HH_mm_ss}.png");

        // ✅ Salva o print apenas com o caminho — Selenium salva como PNG automaticamente
        screenshot.SaveAsFile(caminho);

        currentTest.AddScreenCaptureFromPath(caminho);

        return caminho;
    }


    public static void ExtentReportFlush()
    {
        extentReports.Flush();
    }

    public static void LogInfo(string mensagem)
    {
        currentTest.Log(Status.Info, mensagem);
    }

    public static void LogPass(string mensagem)
    {
        currentTest.Pass(mensagem);
    }

    public static void LogFail(string mensagem)
    {
        currentTest.Fail(mensagem);
    }

    public static void CriarTeste(string nome)
    {
        currentTest = extentReports.CreateTest(nome);
    }
}
