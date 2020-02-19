using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common
{
    public class ContactEpiqPage : UnityPageBase
    {
        private static string pageTitle = "UNITY";
        public ContactEpiqPage(IWebDriver driver) : base(driver, pageTitle)
        {
        }
        public void HelpHeading(string expectedTitle)
        {
            var actualTitle = driver.FindElement(By.XPath($"//div[@class='modal-body']//div[@class='epiq-help-contact-info']/p[text()='{expectedTitle}']"));
            var finalHeading = actualTitle.Text;
            expectedTitle = expectedTitle.Trim();
            Assert.AreEqual(finalHeading.ToLower(), expectedTitle.ToLower());
        }
        public void HelpText(string expectedText)
        {
            var actualText = driver.FindElement(By.XPath($"//div[@class='modal-body']//div[@class='epiq-help-contact-info']/p[text()='{expectedText}']"));
            var finalText = actualText.Text;
            expectedText = expectedText.Trim();
            Assert.AreEqual(finalText.ToLower(), expectedText.ToLower());
        }
        public void EpiqEmailLink(string ExpectedEmailLink)
        {
            var actualEmailLink = driver.FindElement(By.XPath($"//div[@class='modal-body']//div[@class='epiq-help-contact-info']//div[@class='epiq-help-icons']/a[text()='{ExpectedEmailLink}']"));
            var finalLink = actualEmailLink.Text;
            ExpectedEmailLink = ExpectedEmailLink.Trim();
            Assert.AreEqual(finalLink.ToLower(), ExpectedEmailLink.ToLower());
        }
        public void EpiqContactNo(string ExpectedContactNo)
        {
            var actualContactNo = driver.FindElement(By.XPath($"//div[@class='modal-body']//div[@class='epiq-help-contact-info']//div[@class='epiq-help-icons']/a[text()='{ExpectedContactNo}']"));
            var finalContactNo = actualContactNo.Text;
            ExpectedContactNo = ExpectedContactNo.Trim();
            Assert.AreEqual(finalContactNo.ToLower(), ExpectedContactNo.ToLower());
        }
    }
}
