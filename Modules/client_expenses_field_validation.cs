/*
 * Created by Ranorex
 * User: qa
 * Date: 7/24/2020
 * Time: 1:53 PM
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
    /// Description of client_expenses_field_validation.
    /// </summary>
    [TestModule("8A3316AA-E9CF-409A-B701-6B85AF22BAF4", ModuleType.UserCode, 1)]
    public class client_expenses_field_validation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public client_expenses_field_validation()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        FirmSettings firm=FirmSettings.Instance;
        Reports report=Reports.Instance;
        Common cmn=new Common();
        private void clientExpensesFields()
        {
        	
        	firm.MainForm.Self.Activate();
        	firm.MainForm.txtBilling.Click();
        	
        	Delay.Seconds(2);
        	report.MainForm.btnReports.Click();
        	Delay.Seconds(2);
        	
        	report.MainForm.RoundedPanelControl.Reports.Click();
        	Delay.Seconds(1);
        	cmn.SelectItemFromTableSingleClick(report.MainForm.RoundedPanelControl.tblReports,"Client Expense Report","Reports Table");
        	report.MainForm.RoundedPanelControl.btnRun.Click();
        	
        	if(report.SQLReportForm.SelfInfo.Exists(60000))
        	{
        		Report.Success("Client Expense Report Form is displayed as expected");
        		Report.Success(String.Format("Title - {0} is displayed",report.SQLReportForm.txtTitle.GetAttributeValue<String>("Text")));
        		Validate.Exists(report.SQLReportForm.PnlBase.txt_Expense_StartDateInfo,"From Date is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.txtEndDateInfo,"End Date is displayed as expected");
        	
        		Validate.Exists(report.SQLReportForm.PnlBase.btnWorkingLawyerInfo,"Working Lawyer button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnResponsibleLawyerInfo,"Responsible Lawyer button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnAssignedFirmMemberInfo,"Assigned Firm Member button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnIntroducingLawyerInfo,"Introducing Lawyer button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnClientInfo,"Client button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnFilesInfo,"File button is displayed as expected");
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.cmbbxBillingCategoryInfo,"Billing Category Combobox is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.cmbbxMultipleFileTypeInfo,"File Type Combobox is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoIncludeClosedFilesYesInfo,"Include Closed Files Yes Radio Button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoIncludeClosedFilesNoInfo,"Include Closed Files No Radio Button is displayed as expected");
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoTaskBasedBillingFileYesInfo,"Task Based Files Yes Radio Button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoTaskBasedBillingFileNoInfo,"Task Based Files No Radio Button is displayed as expected");
        		
        		
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.cmbbxBillingStatusInfo,"Billing Status Combobox is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.cmbbxExpenseTypeInfo,"Expense Type Combobox is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.cmbbxExpenseCodeInfo,"Expense Code Combobox is displayed as expected");
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoIncludeCorrectionsYesInfo,"Include Corrections Yes Radio Button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoIncludeCorrectionsNoInfo,"Include Corrections No Radio Button is displayed as expected");
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.txtMinimumFeeAmountInfo,"Minimum Amount Textbox is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.txtReferenceNumberInfo,"Reference Number Textbox is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.txtDescriptionInfo,"Description Contains Textbox is displayed as expected");
        		
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
            clientExpensesFields();
        }
    }
}
