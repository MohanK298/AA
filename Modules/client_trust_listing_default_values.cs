/*
 * Created by Ranorex
 * User: qa
 * Date: 7/24/2020
 * Time: 6:46 PM
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
    /// Description of client_trust_listing_default_values.
    /// </summary>
    [TestModule("FE304E75-0C91-4CC2-9240-8F296EE63517", ModuleType.UserCode, 1)]
    public class client_trust_listing_default_values : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public client_trust_listing_default_values()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        int lstcount=0;
       	int frstindex,lastindex=0;
        FirmSettings firm=FirmSettings.Instance;
        Reports report=Reports.Instance;
        Common cmn=new Common();
        string[] billingCategory={"All","Billable","Fixed Fee","Contingency","Non-bill.- Client Dev.","Non-bill.- Firm Admin.","Non-bill.- Prof Dev.","Non-bill.- Other","Vacation","Personal"};
        
        private void client_trust_listing_Default_Values_Validation()
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
        		
        		Validate.AttributeContains(report.SQLReportForm.PnlBase.txtReceiptUptoDateInfo,"UIAutomationValueValue","","Receipts Upto Date Value is empty as expected");
        		
        		report.SQLReportForm.PnlBase.cmbbxFileType.Click();
        		Delay.Milliseconds(500);
        		lstcount=cmn.GetListCount(report.ListFileType.Self);
        		Report.Success(lstcount.ToString());
        		Delay.Milliseconds(500);
        		frstindex=cmn.GetIndex(report.ListFileType.Self,"All");
        		lastindex=cmn.GetIndex(report.ListFileType.Self,"Other");
        		
        		
        		if(frstindex==0)
        		{
        			Report.Success("First Item of the List is 'All' as expected");
        		}
        		if(lastindex==lstcount-1)
        		{
        			Report.Success("Last Item of the List is 'Other' as expected");
        		}
        		
        		report.SQLReportForm.PnlBase.cmbbxFileType.Click();
        	
        		
        		report.SQLReportForm.PnlBase.cmbbxBillingCategory.Click();
        		Delay.Milliseconds(500);
        		cmn.VerifyListItemsInDropdown(report.ListBillingCategory.Self,billingCategory,"Billing Category Dropdown");
        		report.SQLReportForm.PnlBase.cmbbxBillingCategory.Click();
        		Delay.Milliseconds(500);
        		
        		
        		
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
            client_trust_listing_Default_Values_Validation();
        }
    }
}
