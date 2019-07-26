using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class Tenant : Global.Base
        {

            [Test]
            public void AddProfile()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Search for a Property");

                // Create an class and object to call the method
                 Profile obj = new Profile();
                 obj.EditProfile();

                
            }
            [Test]
            public void AddValidSkill()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Save a valid skill in field");

                // Call the Share Skill method
                 ShareSkill skill = new ShareSkill();
                 skill.AddSkill();

                // Verify if add the skill successfully and navigate to ListingManagement
                Assert.IsNotNull(GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(text(),'Manage Listings')]")));
            }
            [Test]
            public void DeleteSelectedSkill()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Delete the last skill page");

                //Call the Manage Skill method
                ManageSkill manageskill = new ManageSkill();
                manageskill.DeleteManageSkill();
            }
        }
    }
}