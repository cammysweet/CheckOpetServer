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

        private String urlLogin = (ConfigurationManager.AppSettings["urlLogin"]);
        private String LoginOs = (ConfigurationManager.AppSettings["loginOs"]);
        private String SenhaOs = (ConfigurationManager.AppSettings["senhaOs"]);

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
        [TestMethod] 
        public void OpenSubtitleTeste()
        {
            chromedriver.Navigate().GoToUrl(urlLogin);
            AjustClick.ClickByClassName("bt-dwl", chromedriver);
            AjustClick.ClickByClassName("disable_ad", chromedriver);
            AjustSendKeys.SendKeysByName("user", LoginOs, chromedriver);
            AjustSendKeys.SendKeysById("password", SenhaOs, chromedriver);
            AjustClick.ClickByXPath("//*[@id=\"loginform\"]/table/tbody/tr[4]/td/input", chromedriver);
            var wait = new WebDriverWait(chromedriver, TimeSpan.FromSeconds(60));
            try
            {
                //wait.Until(ExpectedConditions.ElementIsVisible(d => d.FindElement(By.XPath("//div[@id='timeLeft']")("//*[@id=\"logindetail\"]/a[2]"));
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
