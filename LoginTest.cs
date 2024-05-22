using OpenQA.Selenium;

namespace WebSite.Tests;

public class LoginTest : IClassFixture<WebDriverManager>
{
    private readonly WebDriverManager _manager;

    public LoginTest(WebDriverManager manager)
    {
        _manager = manager;
    }

    [Fact]
    public void Login()
    {
        _manager.Login();

        IWebElement element = _manager.Driver.FindElement(By.ClassName("top-bar-where-thicc"));
        Assert.True(element.Text.Equals("Dashboard"));
    }

    [Fact]
    public void Logout()
    {
        _manager.Logout();
        Assert.True(_manager.Driver.Url.Equals("https://www.devmedia.com.br/"));
    }
}