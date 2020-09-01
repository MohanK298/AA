/*
 * Created by Ranorex
 * User: qa
 * Date: 7/24/2020
 * Time: 6:06 PM
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
    /// Description of client_trust_listing_field_validation.
    /// </summary>
    [TestModule("4F0DAFD7-7D39-419A-8A25-C91E9783A499", ModuleType.UserCode, 1)]
    public class client_trust_listing_field_validation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public client_trust_listing_field_validation()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        FirmSettings firm=FirmSettings.Instance;
        Reports report=Reports.Instance;
        Common cmn=new Common();
        private void client_trust_listing_Field_Validation()
        {
        	
        	firm.MainForm.Self.Activate();
        	firm.MainForm.txtBilling.Click();
        	
        	Delay.Seconds(2);
        	report.MainForm.btnReports.Click();
        	Delay.Seconds(2);
        	
        	report.MainForm.RoundedPanelControl.Reports.Click();
        	Delay.Seconds(1);
        	cmn.SelectItemFromTableSingleClick(report.MainForm.RoundedPanelControl.tblReports,"Client Trust Listing","Reports Table");
        	report.MainForm.RoundedPanelControl.btnRun.Click();
        	
        	if(report.SQLReportForm.SelfInfo.Exists(60000))
        	{
        		Report.Success("Client Trust Listing Form is displayed as expected");
        		Report.Success(String.Format("Title - {0} is displayed",report.SQLReportForm.txtTitle.GetAttributeValue<String>("Text")));
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.txtReceiptUptoDateInfo,"Trusts Upto Date is displayed as expected");
        		
        	
        		
        		
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.btnResponsibleLawyerInfo,"Responsible Lawyer button is displayed as expected");
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.btnIntroducingLawyerInfo,"Introducing Lawyer button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnAssignedFirmMemberInfo,"Assigned Firm Member button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnClientInfo,"Client button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.btnFilesInfo,"File button is displayed as expected");
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.cmbbxBillingCategoryInfo,"Billing Category Combobox is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.cmbbxFileTypeInfo,"File Type Combobox is displayed as expected");
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoIncludeClosedFilesYesInfo,"Include Closed Files Yes Radio Button is displayed as expected");
        		Validate.Exists(report.SQLReportForm.PnlBase.rdoIncludeClosedFilesNoInfo,"Include Closed Files No Radio Button is displayed as expected");
        		
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.cmbbxTrustBankAccountInfo,"Trust Bank Account Combobox is displayed as expected");
        		
        		Validate.Exists(report.SQLReportForm.PnlBase.txtMinimumEntryAmountInfo,"Minimum Entry Amount Textbox is displayed as expected");
        		
        		
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
            client_trust_listing_Field_Validation();
        }
    }
}
