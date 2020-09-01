/*
 * Created by Ranorex
 * User: qa
 * Date: 8/10/2020
 * Time: 11:52 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using SmokeTest.Repositories;
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of create_NewProfile.
    /// </summary>
    [TestModule("3412ACE9-9C6A-49D4-BC04-7EEE988E3999", ModuleType.UserCode, 1)]
    public class create_NewProfile : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public create_NewProfile()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        SecurityProfile sec=SecurityProfile.Instance;
        Common cmn=new Common();
        string txtProfile="Billing AdminA";
        string txtDescription="Billing AdminA Profile";
        private void Create_NewProfile()
        {
        	sec.MainForm.Self.Activate();
        	sec.MainForm.PLeft.txtBILLING.Click();
        	sec.MainForm.PLeft.btnOffice.Click();
        	sec.MainForm.PLeft.lnkSecurityProfiles.Click();
        	
        	Delay.Seconds(1);
        	
        	sec.MainForm.SecurityProfileManagementForm.rdoBillingProfile.Select();
        	Report.Success("Billing Profile Radio button is selected");
        	
        	sec.MainForm.SecurityProfileManagementForm.cmbbxProfile.Click();
        	sec.dpdwnValue=txtProfile;
        	Delay.Milliseconds(300);
        	if(!sec.DropDownForm.txtdpdwnitemInfo.Exists())
        	{
        		sec.MainForm.SecurityProfileManagementForm.cmbbxProfile.Click();
	        	sec.MainForm.SecurityProfileManagementForm.btnNew.Click();
	        	Report.Success("New Button is clicked");
        	   	sec.MainForm.SecurityProfileManagementForm.txtProfileEdit.PressKeys(txtProfile);
        	   	sec.MainForm.SecurityProfileManagementForm.txtDescription.PressKeys(txtDescription);
        	   	sec.MainForm.SecurityProfileManagementForm.btnSave.Click();
        	   	Report.Success("New Billing Profile created successfully");
        	}
        	else
        	{
        		Report.Success("Billing Profile already exists for the name -"+txtProfile);
        		sec.MainForm.SecurityProfileManagementForm.cmbbxProfile.Click();
        	}
        	sec.MainForm.SecurityProfileManagementForm.cmbbxProfile.Click();
        	sec.dpdwnValue=txtProfile;
        	Delay.Milliseconds(300);
        	Validate.Exists(sec.DropDownForm.txtdpdwnitemInfo,String.Format("Dropdown value of {0} exists as expected",txtProfile));
        	sec.MainForm.SecurityProfileManagementForm.cmbbxProfile.Click();
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            Create_NewProfile();
        }
    }
}
