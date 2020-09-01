/*
 * Created by Ranorex
 * User: qa
 * Date: 8/10/2020
 * Time: 1:35 PM
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
    /// Description of validate_billing_office.
    /// </summary>
    [TestModule("699DD159-CF9E-4778-9294-59D86F84C58D", ModuleType.UserCode, 1)]
    public class validate_billing_office : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validate_billing_office()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        SecurityProfile sec=SecurityProfile.Instance;
        Common cmn=new Common();
        
        private void ValidateBillingOfficeDefault()
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
        	sec.MainForm.SecurityProfileManagementForm.View.Click();
        	Delay.Milliseconds(200);
        	sec.modulename="Dailies";
        	Delay.Milliseconds(200);
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.cbValueInfo,"Checked","False","Dailies Checkbox is disabled by Default");
        	
        	sec.MainForm.SecurityProfileManagementForm.Action.Click();
        	sec.modulename="Reminder Statement";
        	Delay.Milliseconds(200);
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.cbValueInfo,"Checked","True","Reminder Statement Checkbox is enabled by Default");
        	sec.modulename="Startup Balance";
        	Delay.Milliseconds(200);
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.cbValueInfo,"Checked","True","Startup Balance Checkbox is enabled by Default");
        	sec.modulename="Accounting Exchange";
        	Delay.Milliseconds(200);
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.cbValueInfo,"Checked","False","Accounting Exchange Checkbox is disabled by Default");
        	sec.modulename="Billing Exchange";
        	Delay.Milliseconds(200);
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.cbValueInfo,"Checked","False","Billing Exchange Checkbox is disabled by Default");
        	sec.modulename="Import QuickBooks Costs";
        	Delay.Milliseconds(200);
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.cbValueInfo,"Checked","False","Import QuickBooks Costs Checkbox is disabled by Default");
        	sec.modulename="Import Fees";
        	Delay.Milliseconds(200);
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.cbValueInfo,"Checked","False","Import Fees Checkbox is disabled by Default");
        	sec.modulename="Import Expenses";
        	Delay.Milliseconds(200);
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.cbValueInfo,"Checked","False","Import Expenses Checkbox is disabled by Default");
        	
        	
        	
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
            ValidateBillingOfficeDefault();
        }
    }
}
