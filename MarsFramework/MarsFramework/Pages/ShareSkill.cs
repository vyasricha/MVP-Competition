
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoItX3Lib;
using NUnit.Framework;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Pages
{
    class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 

        //Finding the Share Skill tab
        [FindsBy(How = How.XPath, Using = "//a[@class='ui basic green button']")]
        private IWebElement SkillTab { get; set; }

        //Finding the Share Skill Title
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement SkillTitle { get; set; }

        //Finding the Share Skill Discription
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement SkillDescription { get; set; }
        
        //Finding the Share Skill Categary dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement SkillCategory { get; set; }

        //Finding the Share Skill SubCategary dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SkillSubCategory { get; set; }

        //Finding the Share Skill tag1
        [FindsBy(How = How.XPath, Using = "(//INPUT[@class='ReactTags__tagInputField'])[1]")]
        private IWebElement SkillTag { get; set; }

        //Finding the Service Type redio button [One-off service]
        [FindsBy(How = How.XPath, Using = "//div[5]//div[2]//div[1]//div[2]//div[1]//input[1]")]
        private IWebElement ServiceType { get; set; }

        //Finding the Location Type redio button [On-site]
        [FindsBy(How = How.XPath, Using = "//div[6]//div[2]//div[1]//div[1]//div[1]//input[1]")]
        private IWebElement LocationType { get; set; }

        //Finding the Start Date
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDate { get; set; }

        //Finding the End Date
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDate { get; set; }

        //Finding the Skill Trade redio button [Credit]
        [FindsBy(How = How.XPath, Using = "(//INPUT[@name='skillTrades'])[2]")]
        private IWebElement SkillTrade { get; set; }

        //Finding the Credit textbox
        [FindsBy(How = How.Name, Using = "charge")]
        private IWebElement Credit { get; set; }

        //Finding Plus sign image
        [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")]
        private IWebElement UploadBtn { get; set; }

        //Finding the Active redio button [Active]
        [FindsBy(How = How.XPath, Using = "(//INPUT[@name='isActive'])[1]")]
        private IWebElement Active { get; set; }

        //Finding the Save button
        [FindsBy(How = How.XPath, Using = "(//INPUT[@type='button'])[1]")]
        private IWebElement SaveBtn { get; set; }

        #endregion

        internal void AddSkill()
        {
            //Click on ShareSkill Tab
            SkillTab.Click();

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
            Thread.Sleep(1000);

            //Add in ShareSkill Title
            SkillTitle.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            Assert.That(SkillTitle != null);
           
            //Add in ShareSkill Discription
            SkillDescription.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            Assert.That(SkillDescription != null);
   
            //Click on ShareSkill Category
            SkillCategory.Click();
            //Select Category
            SkillCategory.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            //Click on ShareSkill SubCategory
            SkillSubCategory.Click();
            //Select SubCategory
            SkillSubCategory.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

            for (int i = 1; i < 3; i++)
            {
                //Click on ShareSkill Tag
                SkillTag.Click();
                if (i == 1)
                {
                      //Add in Tag1
                      Thread.Sleep(1000);
                      SkillTag.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tag1") + Keys.Enter);
                }
                else
                {
                      //Add in Tag2
                      Thread.Sleep(1000);
                      SkillTag.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tag2") + Keys.Enter);
                } 
            }

            //Click on redio button [One-off service]
            ServiceType.Click();

            //Click on redio button [On-site]
            LocationType.Click();

            //Add Start Date
            StartDate.SendKeys("08/11/2019");
            //Add End Date
            EndDate.SendKeys("09/11/2019");

            //Tick on weekdays checkbox, Add Start time and End time
            for (int i = 1; i <= 7; i++)
            {
                Thread.Sleep(1000);
                GlobalDefinitions.driver.FindElement(By.XPath("(//INPUT[@tabindex='0'])["+ (i+4) + "]")).Click();
                Thread.Sleep(1000);
                GlobalDefinitions.driver.FindElement(By.XPath("(//INPUT[@name='StartTime'])[" + i + "]")).SendKeys("10:00AM");
                Thread.Sleep(1000);
                GlobalDefinitions.driver.FindElement(By.XPath("(//INPUT[@name='EndTime'])[" + i + "]")).SendKeys("08:00PM");                
            }

            //Click on Skill Trade [Credit]
            SkillTrade.Click();
            //Add value in Credit
            Credit.SendKeys("6"); 

            //Upload File using AutoIT
            UploadBtn.Click();
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            Thread.Sleep(1000);
            autoIt.Send(@"C:\Users\nilay\Documents\Richa 2019\Richa Vyas-Test Analyst.pdf");
            Thread.Sleep(1000);
            autoIt.Send("{ENTER}");

            //Click on Active [Active]
            Active.Click();

            //Click on Save Button
            SaveBtn.Click();
        }
        internal void ValidateAddedSkill()
        {
            try
            {
                //Go to Manage Listing Tab
                GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(text(),'Manage Listings')]")).Click();
                Thread.Sleep(1000);
                string ShareTitle = GlobalDefinitions.driver.FindElement(By.XPath("//tr[1]/td[3]")).Text;
                Thread.Sleep(1000);
                if (ShareTitle == "Testing")
                {
                    Assert.Fail("Skill is already Exist!");
                }
            }
            catch (Exception)
            {
                Base.test.Log(LogStatus.Info, "Can not find the Skill");
            }
        }
    }
}
