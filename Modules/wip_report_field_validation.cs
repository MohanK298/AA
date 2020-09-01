/*
 * Created by Ranorex
 * User: qa
 * Date: 7/25/2020
 * Time: 8:28 PM
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
    /// Description of wip_report_field_validation.
    /// </summary>
    [TestModule("8B1432AB-06FA-4A81-8913-7CD86977A2F4", ModuleType.UserCode, 1)]
    public class wip_report_field_validation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public wip_report_field_validation()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        FirmSettings firm=FirmSettings.Instance;
        Reports report=Reports.Instance;
        Common cmn=new Common();
        private void WIP_Report_Fields_Validation()
        {
        	
        	firm.MainForm.Self.Activate();
        	firm.MainForm.txtBilling.Click();
        	
        	Delay.Seconds(2);
        	report.MainForm.btnReports.Click();
        	Delay.Seconds(2);
        	
        	report.MainForm.RoundedPanelControl.Reports.Click();
        	Delay.Seconds(1);
        	cmn.SelectItemFromTableSingleClick(report.MainForm.RoundedPanelControl.tblReports,"WIP Report","Reports Table");
        	report.MainForm.RoundedPanelControl.btnRun.Click();
        	
        	if(report.SQLReportForm.SelfInfo.Exists(60000))
        	{
        		Report.Success("WIP Report Form is displayed as expected");
        		Report.Success(String.Format("Title - {0} is displayed",report.SQLReportForm.txtTitle.GetAttributeValue<String>("Text")));
        		Validate.Exists(report.SQLReportForm.PnlBase.txtWIP_Start_DateInfo,"From Date is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.txtEndDateInfo,"End Date is displayed as expected");
        	
        		
        		
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.btnResponsibleLawyerInfo,"Responsible Lawyer button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnAssignedFirmMemberInfo,"Assigned Firm Member button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnIntroducingLawyerInfo,"Introducing Lawyer button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnWorkingLawyerInfo,"Working Timekeeper button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnClientInfo,"Client button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnFilesInfo,"File button is displayed as expected");
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.cmbbxBillingCategoryInfo,"Billing Category Combobox is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.cmbbxFileTypeInfo,"File Type Combobox is displayed as expected");
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.cmbbxAgingCategoryInfo,"Aging Category Combobox is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoIncludeClosedFilesYesInfo,"Include Closed Files Yes Radio Button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoIncludeClosedFilesNoInfo,"Include Closed Files No Radio Button is displayed as expected");
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.cmbbxBillingBehaviourInfo,"Billing Behavior Combobox is displayed as expected");
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.txtMinimumFeeAmountInfo,"Minimum File WIP Amount Textbox is displayed as expected");
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoIncludeZeroBalancesYesInfo,"Include Zero Balances Yes Radio Button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoIncludeZeroBalancesNoInfo,"Include Zero Balances No Radio Button is displayed as expected");
        		
        		
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
            WIP_Report_Fields_Validation();
        }
    }
}
