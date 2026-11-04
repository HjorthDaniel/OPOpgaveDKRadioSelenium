using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace DRMusicRecordsUITests;

public class MusicRecordsTests
{
	[Fact]
	public void Website_ShouldOpen()
	{
		// Arrange - Start Google Chrome
		using IWebDriver driver = new ChromeDriver();

		// Act - Open our frontend
		driver.Navigate().GoToUrl(
			"http://127.0.0.1:5500/OPOpgaveDKRadioFrontEnd-main/index.html"
		);

		// Assert - Check that the website contains its name
		string pageText =
			driver.FindElement(By.TagName("body")).Text;

		Assert.Contains("DR Music Collection", pageText);
	}
	[Fact]
	public void Website_ShouldDisplayRecords()
	{
		using IWebDriver driver = new ChromeDriver();

		driver.Navigate().GoToUrl(
			"http://127.0.0.1:5500/OPOpgaveDKRadioFrontEnd-main/index.html"
		);

		var wait = new WebDriverWait(
			driver, TimeSpan.FromSeconds(10)
		);

		var records = wait.Until(d =>
		{
			var rows = d.FindElements(
				By.CssSelector("#records tbody tr")
			);

			return rows.Count > 0 ? rows : null;
		});

		Assert.NotEmpty(records);
	}


}