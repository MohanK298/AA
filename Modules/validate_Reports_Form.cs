/*
 * Created by Ranorex
 * User: qa
 * Date: 7/16/2020
 * Time: 12:38 PM
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
    /// Description of validate_Reports_Form.
    /// </summary>
    [TestModule("4BAFEDFC-B899-4EB0-BA7C-93D0888C4DF9", ModuleType.UserCode, 1)]
    public class validate_Reports_Form : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validate_Reports_Form()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        FirmSettings firm=FirmSettings.Instance;
        Reports report=Reports.Instance;
        Common cmn=new Common();
        string[] reportItems={"Accounts Receivable by Client","Bill Journal","Cash Receipts Reports","Client Accounting Ledger","Client Listing","Payment Distribution","Client Profitability Report","Client Transactions","Client Trust Listing","GL Transaction Report","Invoice History","Monthly Time Summary by Timekeeper","Retainer Replenishment","Settlement Statement","Time and Fee Journal","Time Billing and Collections","Trust Bank Journal","WIP Report","Write Up/Down Journal"};
        private void ReportFormValidation()
        {
        	
        	firm.MainForm.Self.Activate();
        	firm.MainForm.txtBilling.Click();
        	
        	Delay.Seconds(2);
        	report.MainForm.btnReports.Click();
        	Delay.Seconds(2);
        	Validate.Exists(report.MainForm.RoundedPanelControl.BillsInfo,"Bill Links is seen in the Report as expected");
        	Validate.Exists(report.MainForm.RoundedPanelControl.ReportsInfo,"Reports Links is seen in the Report as expected");
        	Validate.Exists(report.MainForm.RoundedPanelControl.ReminderStatementsInfo,"Remainder Statements Links is seen in the Report as expected");
        	Validate.Exists(report.MainForm.RoundedPanelControl.EMailCoverSheetsInfo,"Email Cover Sheets Links is seen in the Report as expected");
        	
        	report.MainForm.RoundedPanelControl.Reports.Click();
        	Delay.Seconds(1);
        	cmn.VerifyDataExistsInTable(report.MainForm.RoundedPanelControl.tblReports,reportItems,"Reports Table");
        	
        	
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
            ReportFormValidation();
        }
    }
}
