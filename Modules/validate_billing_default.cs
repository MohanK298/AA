/*
 * Created by Ranorex
 * User: qa
 * Date: 8/10/2020
 * Time: 5:38 PM
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
    /// Description of validate_billing_default.
    /// </summary>
    [TestModule("8BE6ACF4-F523-4790-A090-E5A85C8B1681", ModuleType.UserCode, 1)]
    public class validate_billing_default : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validate_billing_default()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        SecurityProfile sec=SecurityProfile.Instance;
        Common cmn=new Common();
        
        private void ValidateBillingDefault()
        {
        	sec.MainForm.Self.Activate();
        	sec.MainForm.PLeft.txtBILLING.Click();
        	sec.MainForm.PLeft.btnOffice.Click();
        	sec.MainForm.PLeft.lnkSecurityProfiles.Click();
        	
        	Delay.Seconds(1);
        	
        	sec.MainForm.SecurityProfileManagementForm.rdoBillingProfile.Select();
        	Report.Success("Billing Profile Radio button is selected");
        	sec.MainForm.SecurityProfileManagementForm.cmbbxProfile.Click();
        	sec.dpdwnValue="Billing User";
        	Delay.Milliseconds(300);
        	sec.DropDownForm.txtdpdwnitem.Click();
        	Delay.Milliseconds(300);
        	Report.Success("Billing User Profile is selected");
        	
        	sec.MainForm.SecurityProfileManagementForm.Billing.Click();
        	Report.Success("Billing link is selected");
        	Delay.Milliseconds(300);
        	sec.MainForm.SecurityProfileManagementForm.View.Click();
        	Report.Success("View link is clicked");
        	Delay.Milliseconds(200);
        	sec.modulename="Dailies";
        	Delay.Milliseconds(200);
        	Validate.NotExists(sec.MainForm.SecurityProfileManagementForm.cbValueInfo,"No Values are present in the View Links");
        	
        	sec.MainForm.SecurityProfileManagementForm.Action.Click();
        	Report.Success("Action link is clicked");
        	sec.modulename="Draft Bills";
        	Delay.Milliseconds(200);
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.cbValueInfo,"Checked","True","Draft Bills Checkbox is enabled by Default");
        	sec.modulename="Payments and General Retainers";
        	Delay.Milliseconds(200);
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.cbValueInfo,"Checked","True","Payment and General Retainers Checkbox is enabled by Default");
        	sec.modulename="Final Bills";
        	Delay.Milliseconds(200);
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.cbValueInfo,"Checked","True","Final Bills Checkbox is enabled by Default");
        	sec.modulename="General Retainer Refunds";
        	Delay.Milliseconds(200);
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.cbValueInfo,"Checked","True","General Retainer Refunds Checkbox is enabled by Default");
        	
        	sec.modulename="Other Firm Members Bills";
        	Delay.Milliseconds(200);
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.cbValueInfo,"Checked","True","Other Firm Members Bills Checkbox is enabled by Default");
        	
        	sec.modulename="Delete Finalized Bills";
        	Delay.Milliseconds(200);
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.cbValueInfo,"Checked","True","Delete Finalized Bills Checkbox is enabled by Default");
        	
        	sec.modulename="Edit Time Entries on Draft Bills";
        	Delay.Milliseconds(200);
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.cbValueInfo,"Checked","False","Edit Time Entries on Draft Bills Checkbox is disabled by Default");
        	
        	
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
            ValidateBillingDefault();
        }
    }
}
