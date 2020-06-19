/*
 * Created by Ranorex
 * User: kumar
 * Date: 6/16/2020
 * Time: 3:21 PM
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
    /// Description of filterValidationInTimeEntries.
    /// </summary>
    [TestModule("5B03E115-FB57-4C12-B7AA-73D2806120CC", ModuleType.UserCode, 1)]
    public class filterValidationInTimeEntries : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public filterValidationInTimeEntries()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        BillingTE te=BillingTE.Instance;
        Common cmn=new Common();
        
        private void filterValidation()
        {
        
        	te.MainForm.btnTimeFeesExpenses.Click();
        	
        	te.MainForm.rdbtnTimeFees.Select();
        	Report.Success("Time Entries Radio button is selected");
        	Validate.Exists(te.MainForm.LeftPanel.rdoTypeAllInfo,"All Radio Button exists under Type as expected");
        	Validate.Exists(te.MainForm.LeftPanel.rdoTimeInfo,"Time Radio Button exists under Type as expected");
        	Validate.Exists(te.MainForm.LeftPanel.rdoFlatFeeInfo,"Flat Fee Radio Button exists under Type as expected");
        	
        	Validate.Exists(te.MainForm.LeftPanel.rdoStatusAllInfo,"All Radio Button exists under Status as expected");
        	Validate.Exists(te.MainForm.LeftPanel.rdoUnbilledInfo,"Unbilled Radio Button exists under Status as expected");
        	Validate.Exists(te.MainForm.LeftPanel.rdoBilled,"Billed Fee Radio Button exists under Status as expected");
        	
        	
        	te.MainForm.rdbtnClientExpenses.Select();
        	Report.Success("Client Expenses Radio button is selected");
        	Validate.Exists(te.MainForm.LeftPanel.rdoAllClientExpensesInfo,"All Radio Button exists under Type as expected");
        	Validate.Exists(te.MainForm.LeftPanel.rdoHardInfo,"Hard Radio Button exists under Type as expected");
        	Validate.Exists(te.MainForm.LeftPanel.rdoSoftInfo,"Soft Fee Radio Button exists under Type as expected");
        	
        	Validate.Exists(te.MainForm.LeftPanel.rdoStatusAllInfo,"All Radio Button exists under Status as expected");
        	Validate.Exists(te.MainForm.LeftPanel.rdoUnbilledInfo,"Unbilled Radio Button exists under Status as expected");
        	Validate.Exists(te.MainForm.LeftPanel.rdoBilled,"Billed Fee Radio Button exists under Status as expected");
        	
        	
        	
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
            filterValidation();
        }
    }
}
