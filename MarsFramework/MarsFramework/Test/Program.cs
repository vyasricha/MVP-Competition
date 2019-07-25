using MarsFramework.Pages;
using NUnit.Framework;
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
            public void UserAccount()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Search for a Property");

                // Create an class and object to call the method
                //  Profile obj = new Profile();
                // obj.EditProfile();

                // Call the Share Skill method
                //  ShareSkill skill = new ShareSkill();
                //skill.AddSkill();

                //Call the Manage Skill method
                 ManageSkill manageskill = new ManageSkill();
                 manageskill.DeleteManageSkill();
            }
        }
    }
}