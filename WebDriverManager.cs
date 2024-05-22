using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace WebSite.Tests;

public class WebDriverManager : IDisposable
{
    public WebDriver Driver;

    public WebDriverManager()
    {
        Driver = new EdgeDriver();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        Driver.Manage().Window.Maximize();
    }

    public void Login()
    {
        Driver.Url = "https://www.devmedia.com.br/login";
        
        IWebElement element = Driver.FindElement(By.Id("usuario"));
        element.SendKeys("dummy");

        element = Driver.FindElement(By.XPath("//*[@id=\"login-form\"]/div/section/form/div[2]/input"));
        element.SendKeys("*****");

        element = Driver.FindElement(By.ClassName("login-button"));
        element.Click();
    }

    public void Logout()
    {
        Driver.Navigate().GoToUrl("https://www.devmedia.com.br/login/logout.php");
    }

    public void Dispose()
    {
        Driver.Quit();
    }
}
