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
    class EducationAndCertification
    {
        public EducationAndCertification()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 

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

        internal void AddEducationAndCertification()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            Thread.Sleep(1000);

            //---------------------------------------------------------
            //Click on Education Tab
            EducationTab.Click();
            //Add Education
            AddNewEducation.Click();
            //Enter the University
            EnterUniversity.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "University"));
            Assert.That(EnterUniversity != null);

            //Select Country
            ChooseCountry.Click();
            //Choose Country Level
            ChooseCountry.SendKeys("India");
            //Select Title
            ChooseTitle.Click();
            //Choose Title
            ChooseTitle.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            //Enter Degree
            Degree.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Degree"));
            Assert.That(Degree != null);
            try
            {
                var Title = GlobalDefinitions.driver.FindElement(By.XPath("(//TD[text()='B.A'])[1]")).Text;
                var Degree = GlobalDefinitions.driver.FindElement(By.XPath("(//TD[text()='B.Tech'])[2]")).Text;

                if (Title == "B.A" && Degree == "B.Tech")
                {
                    // Base.test.Log(LogStatus.Info, "Language is already Exist!");
                    Assert.Fail("Education Information is already Exist!");
                }
            }
            catch (Exception)
            {
                Base.test.Log(LogStatus.Info, "Can not find Information ");

            }
            //Year of Graduation
            DegreeYear.Click();
            DegreeYear.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            //Click on Add Button in Education Tab
            AddEdu.Click();
            Base.test.Log(LogStatus.Info, "Added Education successfully");

            //-------------------------------------------------
            //Click on Certificate tab
            CertificateTab.Click();
            //Add new Certificate
            AddNewCerti.Click();
            //Enter Certificate Name
            EnterCerti.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Certificate"));
            Assert.That(EnterCerti != null);
            try
            {
                var Certi = GlobalDefinitions.driver.FindElement(By.XPath("//TD[text()='ISTQB1']")).Text;
                if (Certi == "ISTQB1")
                {
                    // Base.test.Log(LogStatus.Info, "Language is already Exist!");
                    Assert.Fail("Certificate is already Exist!");
                }
            }
            catch (Exception)
            {
                Base.test.Log(LogStatus.Info, "Can not find the Certificate ");

            }
            //Enter Certified from
            CertiForm.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CertifiedForm"));
            Assert.That(CertiForm != null);

            //Enter the Year
            CertiYear.Click();
            CertiYear.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            //Click on Add Button in Certification Tab
            AddCerti.Click();        
            Base.test.Log(LogStatus.Info, "Added Certificate successfully");
        }
    }
}
