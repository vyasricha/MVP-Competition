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
    class LanguageAndSkill
    {
        public LanguageAndSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 

        //Finding Language Tab
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Languages')]")]
        private IWebElement LanguageTab { get; set; }

        //Finding Add new button in Language Tab
        [FindsBy(How = How.XPath, Using = "//div[@class='ui bottom attached tab segment active tooltip-target']//div[contains(@class,'ui teal button')][contains(text(),'Add New')]")]
        private IWebElement AddNewLangBtn { get; set; }

        //Finding the Language text box
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Add Language']")]
        private IWebElement AddLangText { get; set; }

        //Finding the Added Language [ex. 'English' ]
     //   [FindsBy(How = How.XPath, Using = "//td[contains(text(),'English')]")]
//private IWebElement AddedLangEng { get; set; }

        //Finding the Language Lavel Dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='level']")]
        private IWebElement ChooseLang { get; set; }

        //Finding the Add Button in Language tab
        [FindsBy(How = How.XPath, Using = "//input[@class='ui teal button']")]
        private IWebElement AddLang { get; set; }

        //Finding the Skill Tab 
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Skills')]")]
        private IWebElement SkillTab { get; set; }

        //Finding Textbox to add new skill
        [FindsBy(How = How.XPath, Using = "//div[@class='ui teal button']")]
        private IWebElement AddNewSkillBtn { get; set; }

        //Finding the Skill on text box
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Add Skill']")]
        private IWebElement AddSkillText { get; set; }

        //Finding the Skill on text box
        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Automation Testing')]")]
        private IWebElement AddedSkillAT { get; set; }

        //Finding skill level dropdown
        [FindsBy(How = How.XPath, Using = "//div[@class='ui bottom attached tab segment tooltip-target active']//select[@name='level']")]
        private IWebElement ChooseSkill { get; set; }

        //Finding Add Button in Skill Tab
        [FindsBy(How = How.XPath, Using = "//span[@class='buttons-wrapper']//input[contains(@class,'ui teal button')]")]
        private IWebElement AddSkill { get; set; }

        #endregion

        internal void AddLanguageAndSkill()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            Thread.Sleep(1000);

            //---------------------------------------------------------   
            //Click on Language Tab
            LanguageTab.Click();
            //Click on Add New Language button
            AddNewLangBtn.Click();
            //Enter the Language
            AddLangText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Language"));
            Assert.That(AddLangText != null);
            try
            {
                var Lang = GlobalDefinitions.driver.FindElement(By.XPath("//td[contains(text(),'Japanese')]")).Text;
                if (Lang == "Japanese")
                {
                    // Base.test.Log(LogStatus.Info, "Language is already Exist!");
                    Assert.Fail("Language is already Exist!");
                }
            }
            catch(Exception)
            {
                Base.test.Log(LogStatus.Info, "Can not find the Language ");

            }
            //Choose LanguageLevel
            ChooseLang.Click();
            ChooseLang.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            //Click on Add Button in Language Tab
            AddLang.Click();
            Base.test.Log(LogStatus.Info, "Added Language successfully");
            
            //-----------------------------------------------------------
            //Click on Skill Tab
            SkillTab.Click();
            //Click on Add New Skill Button
            AddNewSkillBtn.Click();
            //Enter the skill 
            AddSkillText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill"));
            Assert.That(AddSkillText != null);
            try
            {
                var Skill = GlobalDefinitions.driver.FindElement(By.XPath("//td[contains(text(),'Automation Testing')]")).Text;
                if (Skill == "Automation Testing")
                {
                    // Base.test.Log(LogStatus.Info, "Language is already Exist!");
                    Assert.Fail("Skill is already Exist!");
                }
            }
            catch (Exception)
            {
                Base.test.Log(LogStatus.Info, "Can not find the Language ");

            }
            //Click the skill dropdown
            ChooseSkill.Click();
            ChooseSkill.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            //Click on Add Button in Skill Tab
            AddSkill.Click();
            Base.test.Log(LogStatus.Info, "Added Skills successfully");
        }
    }
}
