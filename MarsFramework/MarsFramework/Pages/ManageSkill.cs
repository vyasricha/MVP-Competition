using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MarsFramework.Pages
{
    class ManageSkill
    {

        public ManageSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 

        //Finding the Manage Listing tab
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Manage Listings')]")]
        private IWebElement ManageSkillTab { get; set; }

        //Finding the Next Page Button [>]
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'>')]")]
        private IWebElement NextPageBtn { get; set; }

        #endregion

        internal void DeleteManageSkill()
        {
            //Click on ShareSkill Tab
            ManageSkillTab.Click();

            //Page Nevigation and Delete Selected Skill
            try
            {
                while (true)
                {
                    for (var i = 1; i <= 5; i++)
                    {
                        Thread.Sleep(500);
                        string Title = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + i + "]/td[3]")).Text;
                        if (Title == "xyz")
                        {
                            // Click on the selected skill' Delete icon
                            GlobalDefinitions.driver.FindElement(By.XPath("//tr[" + i + "]//td[8]//i[3]")).Click();
                            Thread.Sleep(1000);

                            // Click on the "Yes" button of the popup Dialog box
                            GlobalDefinitions.driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']")).Click();
                            Thread.Sleep(500);
                            return;
                        }
                    }
                    //Click on Next Page Button [>]
                    NextPageBtn.Click();
                }
            }
            catch (Exception)
            {
                Assert.Fail("Title is not there !");
                Base.test.Log(LogStatus.Info, "Can not find the Title");
            }
        }
    }
}
