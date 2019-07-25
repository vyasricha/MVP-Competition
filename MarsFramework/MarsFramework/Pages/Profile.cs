using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Threading;


namespace MarsFramework
{
    internal class Profile
    {

        public Profile()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 

        //Finding the write icon of Availability
        [FindsBy(How = How.XPath, Using = "(//I[@class='right floated outline small write icon'])[1]")]
        private IWebElement AvailablityIcon { get; set; }
        
        //Finding the type of Availability - Dropdown list
        [FindsBy(How = How.XPath, Using = "//select[@name='availabiltyType']")]
        private IWebElement AvailablityType { get; set; }
       
        //Finding Hour' write icon
        [FindsBy(How = How.XPath, Using = "(//I[@class='right floated outline small write icon'])[2]")]
        private IWebElement HoursIcon { get; set; }

        //Finding Hour dropdown list
        [FindsBy(How = How.XPath, Using = "//select[@name='availabiltyHour']")]
        private IWebElement Hours { get; set; }

        //Finding Earn Terget 
        [FindsBy(How = How.XPath, Using = "(//I[@class='right floated outline small write icon'])[3]")]
        private IWebElement EarnTargetIcon { get; set; }

        //Finding Earn Target dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='availabiltyTarget']")]
        private IWebElement EarnTarget { get; set; }

        //Finding Edit Button for Desctiption
        [FindsBy(How = How.XPath, Using = "(//I[@class='outline write icon'])[1]")]
        private IWebElement EditDescription { get; set; }

        //Finding Discription Textbox
        [FindsBy(How = How.Name, Using = "value")]
        private IWebElement Description { get; set; }

        //Finding Save Button for Discription
        [FindsBy(How = How.XPath, Using = "(//BUTTON[@class='ui teal button'][text()='Save'][text()='Save'])[2]")]
        private IWebElement Save { get; set; }

        //Finding Language Tab
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Languages')]")]
        private IWebElement LanguageTab { get; set; }

        //Finding Add new button in Language Tab
        [FindsBy(How =How.XPath,Using = "//div[@class='ui bottom attached tab segment active tooltip-target']//div[contains(@class,'ui teal button')][contains(text(),'Add New')]")]
        private IWebElement AddNewLangBtn { get; set; }

        //Finding the Language text box
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Add Language']")]
        private IWebElement AddLangText { get; set; }

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

        //Finding skill level dropdown
        [FindsBy(How = How.XPath, Using = "//div[@class='ui bottom attached tab segment tooltip-target active']//select[@name='level']")]
        private IWebElement ChooseSkill { get; set; }

        //Finding Add Button in Skill Tab
        [FindsBy(How = How.XPath, Using = "//span[@class='buttons-wrapper']//input[contains(@class,'ui teal button')]")]
        private IWebElement AddSkill { get; set; }

        //Finding Education Tab
        [FindsBy(How = How.XPath, Using = "//a[@class='item'][contains(text(),'Education')]")]
        private IWebElement EducationTab { get; set; }

        //Finding Add new Button in Educaiton Tab
        [FindsBy(How = How.XPath, Using = "(//DIV[@class='ui teal button '])[2]")]
        private IWebElement AddNewEducation { get; set; }

        //Finding University text box
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='College/University Name']")]
        private IWebElement EnterUniversity { get; set; }

        //Finding the country dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='country']")]
        private IWebElement ChooseCountry { get; set; }

        //Finding Title dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='title']")]
        private IWebElement ChooseTitle { get; set; }

        //Finding Degree Textbox
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Degree']")]
        private IWebElement Degree { get; set; }

        //Finding Year of graduation dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='yearOfGraduation']")]
        private IWebElement DegreeYear { get; set; }

        //Finding Add Button
        [FindsBy(How = How.XPath, Using = "//div[@class='sixteen wide field']//input[contains(@class,'ui teal button')]")]
        private IWebElement AddEdu { get; set; }

        //Finding Certificate Tab
        [FindsBy(How = How.XPath, Using = "//A[@class='item'][text()='Certifications']")]
        private IWebElement CertificateTab { get; set; }

        //Finding Add new Button in Certificate Tab
        [FindsBy(How = How.XPath, Using = "(//DIV[@class='ui teal button '][text()='Add New'][text()='Add New'])[3]")]
        private IWebElement AddNewCerti { get; set; }

        //Finding Certification Textbox
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Certificate or Award']")]
        private IWebElement EnterCerti { get; set; }

        //Finding Certified form
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Certified From (e.g. Adobe)']")]
        private IWebElement CertiForm { get; set; }

        //Finding Year dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='certificationYear']")]
        private IWebElement CertiYear { get; set; }

        //Finding Add Button in Ceritification Tab
        [FindsBy(How = How.XPath, Using = "//div[@class='five wide field']//input[contains(@class,'ui teal button')]")]
        private IWebElement AddCerti { get; set; }

        #endregion

        internal void EditProfile()
        {

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            Thread.Sleep(1000);
            // Click the write icon of Availability
            AvailablityIcon.Click();
            Thread.Sleep(1500);
            // Select the Availability
            AvailablityType.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "AvailableTime"));
            Base.test.Log(LogStatus.Info, "Availability updated");

            //Click on Hours write icon
            Thread.Sleep(1000);
            HoursIcon.Click();
            Thread.Sleep(1500);
            Hours.SendKeys(Keys.Down + Keys.Down + Keys.Enter);

            //Click on EarnTarget write icon
            Thread.Sleep(1000);
            EarnTargetIcon.Click();
            Thread.Sleep(1500);
            //Availability Hours option
            EarnTarget.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);

            //-----------------------------------------------------
            //Click on Edit button
            Thread.Sleep(1000);
            EditDescription.Click();
            Thread.Sleep(1500);
            //Add Description
            Description.Clear();
            Thread.Sleep(1000);
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Description"));
            Thread.Sleep(500);
            Save.Click();
            Base.test.Log(LogStatus.Info, "Added Description successfully");

            //---------------------------------------------------------   
            //Click on Language Tab
            LanguageTab.Click();
            Thread.Sleep(1000);
            //Click on Add New Language button
            AddNewLangBtn.Click();
            Thread.Sleep(1000);
            //Enter the Language
            AddLangText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Language"));
            //Choose LanguageLevel
            ChooseLang.Click();
            Thread.Sleep(1000);
            ChooseLang.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            AddLang.Click();
            Base.test.Log(LogStatus.Info, "Added Language successfully");

            //-----------------------------------------------------------
            //Click on Skill Tab
            Thread.Sleep(1000);
            SkillTab.Click();
            //Click on Add New Skill Button
            AddNewSkillBtn.Click();
            //Enter the skill 
            AddSkillText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Skill"));
            //Click the skill dropdown
            ChooseSkill.Click();
            Thread.Sleep(500);
            ChooseSkill.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            AddSkill.Click();
            Thread.Sleep(500);
            Base.test.Log(LogStatus.Info, "Added Skills successfully");

            //---------------------------------------------------------
            //Click on Education Tab
            Thread.Sleep(1000);
            EducationTab.Click();
            //Add Education
            AddNewEducation.Click();
            //Enter the University
            EnterUniversity.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"University"));
            //Select Country
            ChooseCountry.Click();
            Thread.Sleep(500);
            //Choose Country Level
            ChooseCountry.SendKeys("India");
            //Select Title
            ChooseTitle.Click();
            Thread.Sleep(500);
            //Choose Title
            ChooseTitle.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            //Enter Degree
            Degree.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Degree"));
            //Year of Graduation
            DegreeYear.Click();
            Thread.Sleep(500);
            DegreeYear.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            AddEdu.Click();
            Thread.Sleep(500);
            Base.test.Log(LogStatus.Info, "Added Education successfully");

            //-------------------------------------------------
            //Click on Certificate tab
            Thread.Sleep(1000);
            CertificateTab.Click();
            //Add new Certificate
            AddNewCerti.Click();
            //Enter Certificate Name
            EnterCerti.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Certificate"));
            //Enter Certified from
            CertiForm.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CertifiedForm"));
            //Enter the Year
            CertiYear.Click();
            Thread.Sleep(500);
            CertiYear.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            AddCerti.Click();
            Thread.Sleep(500);
            Base.test.Log(LogStatus.Info, "Added Certificate successfully");

        }
    }
}