using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TaskBoardWebUiTest
{
    public class Tests
    {

        private WebDriver driver;

        [SetUp]
        public void SetUp()
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://taskboard-212f.onrender.com/");
            driver.Manage().Window.Maximize();
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Dispose();
        }

        [TestCase("non-existing", "No results found.")]
        [TestCase("Edit tasks", "1 tasks found.")]
        public void Search(string searchTerm, string expected)
        {
            driver.FindElement(By.LinkText("Search")).Click();
            driver.FindElement(By.Id("keyword")).SendKeys(searchTerm);
            driver.FindElement(By.Id("search")).Click();
            driver.FindElement(By.CssSelector("body")).Click();
            Assert.That(driver.FindElement(By.Id("searchResult")).Text, Is.EqualTo(expected));
        }
    }
}
