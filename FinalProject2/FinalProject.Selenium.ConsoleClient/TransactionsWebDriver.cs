using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace FinalProject.Selenium.ConsoleClient;

public class TransactionsWebDriver
{
    public IWebDriver driver { get; set;}

    public void Start()
    {
        driver = new ChromeDriver();
        Thread.Sleep(1500);
        
        driver.Navigate().GoToUrl("https://finalproject.dotnet.gg");
    }

    public void Stop()
    {
        driver.Quit();
    }
}