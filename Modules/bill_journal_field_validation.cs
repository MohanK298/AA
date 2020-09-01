/*
 * Created by Ranorex
 * User: qa
 * Date: 7/22/2020
 * Time: 9:39 AM
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
    /// Description of bill_journal_field_validation.
    /// </summary>
    [TestModule("3F5495B5-B2A9-40B0-ADD2-67D0A0022B89", ModuleType.UserCode, 1)]
    public class bill_journal_field_validation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public bill_journal_field_validation()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        FirmSettings firm=FirmSettings.Instance;
        Reports report=Reports.Instance;
        Common cmn=new Common();
        private void bill_journal_Fields_Validation()
        {
        	
        	firm.MainForm.Self.Activate();
        	firm.MainForm.txtBilling.Click();
        	
        	Delay.Seconds(2);
        	report.MainForm.btnReports.Click();
        	Delay.Seconds(2);
        	
        	report.MainForm.RoundedPanelControl.Reports.Click();
        	Delay.Seconds(1);
        	cmn.SelectItemFromTableSingleClick(report.MainForm.RoundedPanelControl.tblReports,"Bill Journal","Reports Table");
        	report.MainForm.RoundedPanelControl.btnRun.Click();
        	
        	if(report.SQLReportForm.SelfInfo.Exists(60000))
        	{
        		Report.Success("Bill Journal Form is displayed as expected");
        		Report.Success(String.Format("Title - {0} is displayed",report.SQLReportForm.txtTitle.GetAttributeValue<String>("Text")));
        		Validate.Exists(report.SQLReportForm.PnlBase.txtStartDateJournalInfo,"From Date is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.txtEndDateInfo,"End Date is displayed as expected");
        	
        		Validate.Exists(report.SQLReportForm.PnlBase.txtReceiptUptoDateInfo,"Receipts Upto Date is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.txtWriteUpWriteDownDateInfo,"Write Up/Down up to Date is displayed as expected");
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.btnResponsibleLawyerInfo,"Responsible Lawyer button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnAssignedFirmMemberInfo,"Assigned Firm Member button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnIntroducingLawyerInfo,"Introducing Lawyer button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnFeeCreditLawyerInfo,"Fee Credit Lawyer button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnClientInfo,"Client button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnFilesInfo,"File button is displayed as expected");
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.cmbbxBillingCategoryInfo,"Billing Category Combobox is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.cmbbxFileTypeInfo,"File Type Combobox is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoIncludeClosedFilesYesInfo,"Include Closed Files Yes Radio Button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoIncludeClosedFilesNoInfo,"Include Closed Files No Radio Button is displayed as expected");
        		
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.txtInvoiceNumberInfo,"Invoice Number Textbox is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoIncludeCorrectionsYesInfo,"Include Corrections Yes Radio Button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoIncludeCorrectionsNoInfo,"Include Corrections No Radio Button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoIncludePaidYesInfo,"Include Paid Yes Radio Button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoIncludePaidNoInfo,"Include Paid No Radio  Button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.txtMinimumARBalanceInfo,"Minimum AR Balance is displayed as expected");
        		
        		
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
            bill_journal_Fields_Validation();
        }
    }
}
