using Godot;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



public class TestManager : Node
{

        String test_url = "https://www.google.com";
        IWebDriver driver;

        public void start_Browser()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

        }

        public void test_search()
        {
            start_Browser();

            driver.Url = test_url;

            System.Threading.Thread.Sleep(2000);

            IWebElement searchText = driver.FindElement(By.CssSelector("[name = 'q']"));

            searchText.SendKeys("Godot game engine");

            IWebElement searchButton = driver.FindElement(By.XPath("//div[@class='FPdoLc tfB0Bf']//input[@name='btnK']"));

            searchButton.Click();

            IWebElement godotWebPage = driver.FindElement(By.ClassName("LC20lb"));

            godotWebPage.Click();

            IWebElement downloadPage = driver.FindElement(By.XPath("/html/body/header/div/nav/ul[2]/li[1]/a"));

            downloadPage.Click();

            System.Threading.Thread.Sleep(6000);

            GD.Print("Test Passed");

            close_Browser();
        }


                public void close_Browser()
        {
            driver.Quit();
        }





    public override void _Ready()
    {

        test_search();

    }

}
