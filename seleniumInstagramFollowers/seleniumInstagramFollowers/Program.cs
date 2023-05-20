using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
namespace seleniumInstagramFollowers;

static class Program
{
    static void Main(string[] args)
    {
        //driver eklendi
        IWebDriver driver = new ChromeDriver();
        
        //yönlendirilecek site ekleniyor
        driver.Navigate().GoToUrl("https://www.instagram.com");

        Console.WriteLine("-----------------------------");
        Console.WriteLine("Siteye girildi.");
        Thread.Sleep(2000);
        
        //bir html elementi seçmek için
        // bir element seçtiğimiz için FindElement dedik
        IWebElement userName = driver.FindElement(By.Name("username"));
        IWebElement password = driver.FindElement(By.Name("password"));
        IWebElement loginBtn = driver.FindElement(By.CssSelector("._acan._acap._acas._aj1-"));
        
        userName.SendKeys("aleynamey");
        password.SendKeys("aliveli4950");
        Console.WriteLine("Hesap bilgileri girildi.");
        loginBtn.Click();
        Thread.Sleep(10000);
        Console.WriteLine("Girildi.");
        
        driver.Navigate().GoToUrl("https://www.instagram.com/aleynamey");

    }

}



