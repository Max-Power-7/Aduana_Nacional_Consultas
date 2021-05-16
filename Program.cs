using System;
using System.IO;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Aduana_Nacional
{
    class Aduana
    {
        static void Main(string[] args)
        {
            ClsMetodos met = new ClsMetodos();

            Console.WriteLine("Ingresando a la Web...");

            met.Conectar();

            //Enviando los valores de cada comboBox y TextBox al portal web de Aduana
            met.driver.FindElement(By.Name("gestion")).SendKeys("2021");

            //Seleccionando un "select" con múltiple opciones en HTML (Una tipo lista)
            IWebElement selectElement = met.driver.FindElement(By.Id("aduana"));
            var selectObject = new SelectElement(selectElement);

            // Selecciona una <option> basándose en el indice interno del elemento <select>
            selectObject.SelectByValue("301");

            //Enviando los valores de cada comboBox y TextBox al portal web de Aduana
            met.driver.FindElement(By.Name("serie")).SendKeys("C");
            met.driver.FindElement(By.Name("numero")).SendKeys("2097092");

            //Mostrando URL actual
            Console.WriteLine(met.driver.Url);

            //Tiempo de espera
            var timeout = 1000; // en milisegundos
            var wait = new WebDriverWait(met.driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("consulta")));

            //Dando clic al botón de consultar
            IWebElement aux = met.driver.FindElement(By.Id("consulta"));
            aux.Click();


            //Mostrando fechas con foreach y Classname
            /*var aux3 = met.driver.FindElements(By.ClassName("xxx"));
            foreach (var item in aux3)
            {
                Console.WriteLine(" ");

                Console.WriteLine(item.Text);

                Console.WriteLine(" ");
            }*/

            //Mostrando el último registro de fecha pero uno específico seleccionado con Path
            var aux2 = met.driver.FindElementByXPath("/html/body/div[2]/div[2]/table/tbody/tr[5]/th[1]/b");
            Console.WriteLine(" ");

            Console.WriteLine(aux2.Text);
            Console.WriteLine(" ");

            //Cerrar la sesión del navegador totalmente
            met.driver.Quit();
        }
    }
}
