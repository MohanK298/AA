/*
 * Created by Ranorex
 * User: qa
 * Date: 7/22/2020
 * Time: 4:15 PM
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
    /// Description of trust_bank_journal_fields.
    /// </summary>
    [TestModule("DF711B65-3039-4378-8C63-CC8D1CDB9EE6", ModuleType.UserCode, 1)]
    public class trust_bank_journal_fields : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public trust_bank_journal_fields()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        FirmSettings firm=FirmSettings.Instance;
        Reports report=Reports.Instance;
        Common cmn=new Common();
        private void trust_bank_journal_Fields()
        {
        	
        	firm.MainForm.Self.Activate();
        	firm.MainForm.txtBilling.Click();
        	
        	Delay.Seconds(2);
        	report.MainForm.btnReports.Click();
        	Delay.Seconds(2);
        	
        	report.MainForm.RoundedPanelControl.Reports.Click();
        	Delay.Seconds(1);
        	cmn.SelectItemFromTableSingleClick(report.MainForm.RoundedPanelControl.tblReports,"Trust Bank Journal","Reports Table");
        	report.MainForm.RoundedPanelControl.btnRun.Click();
        	
        	if(report.SQLReportForm.SelfInfo.Exists(60000))
        	{
        		Report.Success("Trust Bank Journal Form is displayed as expected");
        		Report.Success(String.Format("Title - {0} is displayed",report.SQLReportForm.txtTitle.GetAttributeValue<String>("Text")));
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.txtTrustStartDateInfo,"From Date is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.txtEndDateInfo,"End Date is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.txtReceiptCheckNumberInfo,"Receipt Check Number is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoIncludeCorrectionsNoInfo,"Include Correct No Radio Button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoIncludeCorrectionsYesInfo,"Include Correct Yes Radio Button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.txtReceivedFromPaidToContainsInfo,"Received From/ Paid To Contains is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.cmbbxTrustBankAccountInfo,"Trust Bank Account Combobox is displayed as expected");
        		
        		report.SQLReportForm.Toolbar1.btnCancel.Click();
        	}
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
            trust_bank_journal_Fields();
        }
    }
}
