using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Aduana_Nacional
{
    class ClsMetodos
    {
        public String url;
        public ChromeOptions chromeOptions = new ChromeOptions();
        public ChromeDriverService chromeDriverService;
        public ChromeDriver driver;
        
        public ClsMetodos()
        {
            this.url = "http://anbsw01.aduana.gob.bo:7601/click/login.do";
            //this.chromeOptions.AddArguments(new List<string>() { "headless" });
            this.chromeOptions.AddArguments(new List<string>() { "no-sandbox" });
            //this.chromeOptions.AddArguments(new List<string>() { "use-gl=desktop" });
            //--enable - webgl            
            this.chromeDriverService = ChromeDriverService.CreateDefaultService();
            this.driver = new ChromeDriver(chromeDriverService, chromeOptions/*, TimeSpan.FromMinutes(3)*/);
            //driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
        }   

        public void Conectar()
        {
            //Ejecutando el navegador en modo headless, sin interfaz de usuario, en segundo plano
            //String url = "http://anbsw01.aduana.gob.bo:7601/click/login.do";
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments(new List<string>() { "headless" });

            //var chromeDriverService = ChromeDriverService.CreateDefaultService();
            //ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);
            driver.Navigate().GoToUrl(url);
        }        
    }
}
