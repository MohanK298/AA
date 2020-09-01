/*
 * Created by Ranorex
 * User: qa
 * Date: 8/10/2020
 * Time: 5:28 PM
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
    /// Description of validate_billing_time_fee_expenses_default.
    /// </summary>
    [TestModule("0C1A5899-F3A3-40B3-948B-D15CF976F846", ModuleType.UserCode, 1)]
    public class validate_billing_time_fee_expenses_default : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validate_billing_time_fee_expenses_default()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        SecurityProfile sec=SecurityProfile.Instance;
        Common cmn=new Common();
        
        private void ValidateTimeFeesExpenseDefault()
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
        	
        	sec.MainForm.SecurityProfileManagementForm.TimeFeesExpenses.Click();
        	Report.Success("Time Fees Expenses link is selected");
        	Delay.Milliseconds(300);
        	sec.MainForm.SecurityProfileManagementForm.View.Click();
        	Report.Success("View link is clicked");
        	Delay.Milliseconds(200);
        	sec.modulename="Dailies";
        	Delay.Milliseconds(200);
        	Validate.NotExists(sec.MainForm.SecurityProfileManagementForm.cbValueInfo,"No Values are present in the View Links");
        	
        	sec.MainForm.SecurityProfileManagementForm.Action.Click();
        	Report.Success("Action link is clicked");
        	sec.modulename="Mass Time Entry Changes";
        	Delay.Milliseconds(200);
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.cbValueInfo,"Checked","False","Mass Time Entry Changes Checkbox is disabled by Default");
        	sec.modulename="Client Expenses";
        	Delay.Milliseconds(200);
        	Validate.AttributeContains(sec.MainForm.SecurityProfileManagementForm.cbValueInfo,"Checked","True","Client Expenses Checkbox is enabled by Default");
        	
        	
        	
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
            ValidateTimeFeesExpenseDefault();
        }
    }
}
