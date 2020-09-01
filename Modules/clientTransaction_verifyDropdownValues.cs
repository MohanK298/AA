/*
 * Created by Ranorex
 * User: qa
 * Date: 7/21/2020
 * Time: 4:51 PM
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
    /// Description of clientTransaction_verifyDropdownValues.
    /// </summary>
    [TestModule("ADC8A8D5-B6DC-4C76-B909-521DFBFE2867", ModuleType.UserCode, 1)]
    public class clientTransaction_verifyDropdownValues : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public clientTransaction_verifyDropdownValues()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        FirmSettings firm=FirmSettings.Instance;
        Reports report=Reports.Instance;
        Common cmn=new Common();
        string[] billingCategory={"All","Billable","Fixed Fee","Contingency","Non-bill.- Client Dev.","Non-bill.- Firm Admin.","Non-bill.- Prof Dev.","Non-bill.- Other","Vacation","Personal"};
        string[] billingStatus={"All","Unbilled","Billed"};
        
        
        private void clientTransactions_VerifyDropdownValues()
        {
        	
        	firm.MainForm.Self.Activate();
        	firm.MainForm.txtBilling.Click();
        	
        	Delay.Seconds(2);
        	report.MainForm.btnReports.Click();
        	Delay.Seconds(2);
        	
        	report.MainForm.RoundedPanelControl.Reports.Click();
        	Delay.Seconds(1);
        	cmn.SelectItemFromTableSingleClick(report.MainForm.RoundedPanelControl.tblReports,"Client Transactions","Reports Table");
        	report.MainForm.RoundedPanelControl.btnRun.Click();
        	
        	if(report.SQLReportForm.SelfInfo.Exists(60000))
        	{
        		Report.Success("Client Transactions Form is displayed as expected");
        		Report.Success(String.Format("Title - {0} is displayed",report.SQLReportForm.txtTitle.GetAttributeValue<String>("Text")));
        		
        		report.SQLReportForm.PnlBase.cmbbxBillingCategory.Click();
        		Delay.Milliseconds(500);
        		cmn.VerifyListItemsInDropdown(report.ListBillingCategory.Self,billingCategory,"Billing Category Dropdown");
        		report.SQLReportForm.PnlBase.cmbbxBillingCategory.Click();
        		Delay.Milliseconds(500);
        		
        		
        		report.SQLReportForm.PnlBase.cmbbxBillingStatus.Click();
        		Delay.Milliseconds(500);
        		cmn.VerifyListItemsInDropdown(report.ListBillingStatus.Self,billingStatus,"Billing Status Dropdown");
        		report.SQLReportForm.PnlBase.cmbbxBillingStatus.Click();
        		Delay.Milliseconds(500);
        		
        		report.SQLReportForm.PnlBase.cmbbxTransactionType.Click();
        		Delay.Milliseconds(500);
        		report.var="True";
        		Delay.Milliseconds(500);
        		Validate.Exists(report.DropDownForm.TreeItemInfo,String.Format("All is set as True in the Transactions Dropdown."));
        		report.SQLReportForm.PnlBase.cmbbxTransactionType.Click();
        		
        		
        		Validate.AttributeContains(report.SQLReportForm.PnlBase.rdoShowDetalsYesInfo,"Checked","True","Show Details Yes Radio Button by default is set to True as expected");
        		Validate.AttributeContains(report.SQLReportForm.PnlBase.rdoShowDetailsNoInfo,"Checked","False","Show Details No Radio Button default values is set to False as expected");
        		
        		Validate.AttributeContains(report.SQLReportForm.PnlBase.rdoShowBalancesYesInfo,"Checked","False","Show Balance/Files with Trust or Retainer Only Yes Radio Button by default is set to True as expected");
        		Validate.AttributeContains(report.SQLReportForm.PnlBase.rdoShowBalancesNoInfo,"Checked","True","Show Balance/Files with Trust or Retainer Only No Radio Button default values is set to False as expected");
        		
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
            clientTransactions_VerifyDropdownValues();
        }
    }
}
