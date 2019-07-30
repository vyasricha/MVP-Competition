using MarsFramework.Global;
using NUnit.Framework;
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

        #endregion

        internal void EditProfile()
        {

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            Thread.Sleep(1000);

            // Click the write icon of Availability
            AvailablityIcon.Click();
            // Select the Availability
            AvailablityType.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "AvailableTime"));
            Base.test.Log(LogStatus.Info, "Availability updated");

            //Click on Hours write icon
            HoursIcon.Click();
            Thread.Sleep(1500);
            Hours.SendKeys(Keys.ArrowDown + Keys.Enter);

            //Click on EarnTarget write icon
            EarnTargetIcon.Click();
            //Availability Hours option
            //EarnTarget.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
            EarnTarget.SendKeys("More than $1000 per month");
            
            //Click on Discription Edit button
            EditDescription.Click();
            //Add Description
            Description.Clear();
            Thread.Sleep(1000);
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Description"));
            Save.Click();
            Assert.That(Description != null);
            Base.test.Log(LogStatus.Info, "Added Description successfully");
        }
    }
}