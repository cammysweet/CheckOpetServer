using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using Handlenium;
using System.Configuration;

namespace CheckOpetServer
{
    [TestClass]
    public class AlunoOnlineTest
    {
        #region Variáveis
        ChromeDriver chromedriver;
        private String chromedriverPath = (ConfigurationManager.AppSettings["chromedriverPath"]);
        private String urlAlunoOnline = (ConfigurationManager.AppSettings["urlAlunoOnline"]);
        private String urlEntrada = (ConfigurationManager.AppSettings["urlEntrada"]);
        private String login = (ConfigurationManager.AppSettings["login"]);
        private String senha = (ConfigurationManager.AppSettings["senha"]); 
        #endregion

        #region arranging tests
        [TestInitialize]
        public void SyncDriver()
        {
            chromedriver = new ChromeDriver(chromedriverPath);
            chromedriver.Manage().Window.Maximize();
            chromedriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));

        }

        [TestCleanup]
        public void afterTests()
        {
            chromedriver.Close();
        }

        #endregion

        #region Methods
        [TestMethod]
        public void AlunoOnlineTestMethod()
        {
            chromedriver.Navigate().GoToUrl(urlAlunoOnline);
            AjustSendKeys.SendKeysById("txtnumero_matricula", login, chromedriver);
            AjustSendKeys.SendKeysById("txtsenha_tac", senha, chromedriver);
            AjustClick.ClickById("cmdEnviar", chromedriver);
            var wait = new WebDriverWait(chromedriver, TimeSpan.FromSeconds(120));
            try
            {
                wait.Until(ExpectedConditions.UrlContains(urlEntrada));
                WriteLog.SalvaLog("S");
            }
            catch (Exception)
            {
                WriteLog.SalvaLog("N");
                throw;
            }

        } 
        #endregion
    }
}
